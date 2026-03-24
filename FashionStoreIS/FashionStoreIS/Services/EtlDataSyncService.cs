using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models.Analytics;
using FashionStoreIS.Models;

namespace FashionStoreIS.Services
{
    public class EtlDataSyncService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EtlDataSyncService> _logger;

        public EtlDataSyncService(IServiceProvider serviceProvider, ILogger<EtlDataSyncService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                // Initial delay to let the web server start up peacefully before doing heavy ETL
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("ETL Data Sync Process Starting...");
                    try
                    {
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var appDb = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                            var analyticsDb = scope.ServiceProvider.GetRequiredService<AnalyticsDbContext>();

                            await PerformEtlAsync(appDb, analyticsDb, stoppingToken);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "ETL Data Sync Process Failed.");
                    }

                    // Wait 24 hours before running again (simulating a nightly job)
                    await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("ETL Data Sync Service is stopping gracefully.");
            }
        }

        private async Task PerformEtlAsync(ApplicationDbContext appDb, AnalyticsDbContext analyticsDb, CancellationToken ct)
        {
            // Simple Extract, Transform, Load (ETL) Implementation
            // Find the last synced OrderId from Fact_Sales to only process new data consistently
            int lastSyncedOrderId = await analyticsDb.Fact_Sales.MaxAsync(x => (int?)x.OrderId, ct) ?? 0;

            // Extract Completed Orders that haven't been synced yet
            var newOrders = await appDb.Orders
                .AsNoTracking() // VERY IMPORTANT FOR REDUCING OLTP MEMORY USAGE
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductSku)
                .Where(o => o.Status == OrderStatus.Completed && o.Id > lastSyncedOrderId)
                .ToListAsync(ct);

            if (!newOrders.Any())
            {
                _logger.LogInformation("No new completed orders found for ETL.");
                return;
            }

            foreach (var order in newOrders)
            {
                // 1. Resolve Time Dimension
                int dateKey = int.Parse(order.CreatedAt.ToString("yyyyMMdd"));
                var dimDate = await analyticsDb.Dim_Date.FindAsync(new object[] { dateKey }, ct);
                if (dimDate == null)
                {
                    dimDate = new Dim_Date
                    {
                        DateKey = dateKey,
                        Date = order.CreatedAt.Date,
                        Day = order.CreatedAt.Day,
                        Month = order.CreatedAt.Month,
                        Year = order.CreatedAt.Year,
                        Quarter = (order.CreatedAt.Month - 1) / 3 + 1,
                        IsWeekend = order.CreatedAt.DayOfWeek == DayOfWeek.Saturday || order.CreatedAt.DayOfWeek == DayOfWeek.Sunday
                    };
                    analyticsDb.Dim_Date.Add(dimDate);
                    await analyticsDb.SaveChangesAsync(ct);
                }

                // 2. Resolve Customer Dimension (Matched by App UserId)
                Dim_Customer dimCustomer = null;
                if (!string.IsNullOrEmpty(order.UserId))
                {
                    dimCustomer = await analyticsDb.Dim_Customer.FirstOrDefaultAsync(c => c.CustomerId == order.UserId, ct);
                }
                if (dimCustomer == null)
                {
                    dimCustomer = new Dim_Customer
                    {
                        CustomerId = order.UserId ?? "GUEST",
                        FullName = order.CustomerName ?? "",
                        Phone = order.Phone ?? "",
                        Email = string.Empty, // Could join AspNetUsers but keep it simple
                        RegionOrCity = order.Address ?? "" // Standardized from Address if parser exists
                    };
                    analyticsDb.Dim_Customer.Add(dimCustomer);
                    await analyticsDb.SaveChangesAsync(ct);
                }

                // 3. Transform & Load Order Details (Line Items) into Facts
                decimal totalOrderValueBeforeDiscount = order.OrderDetails.Sum(od => od.Subtotal);
                
                foreach (var detail in order.OrderDetails)
                {
                    // Resolve Product Dimension
                    var dimProduct = await analyticsDb.Dim_Product.FirstOrDefaultAsync(p => 
                        p.ProductId == detail.ProductId && p.ProductSkuId == detail.ProductSkuId, ct);
                        
                    if (dimProduct == null)
                    {
                        dimProduct = new Dim_Product
                        {
                            ProductId = detail.ProductId ?? 0,
                            ProductSkuId = detail.ProductSkuId,
                            ProductName = detail.Product != null ? detail.Product.Name ?? "Unknown Product" : "Unknown Product",
                            CategoryName = "Unknown", // Would require extra Include for Category entity
                            Color = detail.ProductSku != null ? detail.ProductSku.Color ?? string.Empty : string.Empty,
                            Size = detail.ProductSku != null ? detail.ProductSku.Size ?? string.Empty : string.Empty,
                            ValidFrom = DateTime.UtcNow
                        };
                        analyticsDb.Dim_Product.Add(dimProduct);
                        await analyticsDb.SaveChangesAsync(ct); // Immediate save to get identity surrogate key
                    }

                    // Calculate Proportionate Financial Metrics
                    decimal proratedDiscount = 0;
                    if (order.DiscountAmount > 0 && totalOrderValueBeforeDiscount > 0)
                    {
                        proratedDiscount = order.DiscountAmount * (detail.Subtotal / totalOrderValueBeforeDiscount);
                    }

                    // Estimate COGS (Cost of goods sold). In a real system, this fetches from Inventory PO.
                    // Fake margin approx 60% of base retail price if actual unit cost missing
                    decimal unitCost = detail.Product != null ? detail.Product.Price * 0.4m : 0; 
                    decimal totalCogs = unitCost * detail.Quantity;
                    
                    var fact = new Fact_Sales
                    {
                        DateKey = dimDate.DateKey,
                        ProductSurrogateKey = dimProduct.ProductSurrogateKey,
                        CustomerSurrogateKey = dimCustomer.CustomerSurrogateKey,
                        OrderId = order.Id,
                        OrderCode = order.OrderCode,
                        Quantity = detail.Quantity,
                        UnitPrice = detail.UnitPrice,
                        SalesAmount = detail.Subtotal,
                        DiscountAmount = proratedDiscount,
                        COGS = totalCogs,
                        GrossProfit = detail.Subtotal - proratedDiscount - totalCogs
                    };
                    analyticsDb.Fact_Sales.Add(fact);
                }
            }

            // Commit final Fact payload
            await analyticsDb.SaveChangesAsync(ct);
            _logger.LogInformation($"ETL Data Sync completed successfully! Ingested {newOrders.Count} verified Orders into the Warehouse.");
        }
    }
}
