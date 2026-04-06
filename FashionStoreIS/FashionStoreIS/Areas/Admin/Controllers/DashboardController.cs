using FashionStoreIS.Areas.Admin.ViewModels;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel();

            // Basic Statistics
            model.TotalRevenue = await _db.Orders
                .Where(o => o.Status != OrderStatus.Cancelled)
                .SumAsync(o => o.TotalAmount);

            model.TotalOrders = await _db.Orders.CountAsync();

            // Đếm ApplicationUser có role "User"
            var userRole = await _roleManager.FindByNameAsync("User");
            model.TotalCustomers = userRole != null 
                ? await _db.UserRoles.CountAsync(ur => ur.RoleId == userRole.Id)
                : 0;

            model.TotalProducts = await _db.Products.CountAsync();

            // Monthly Revenue Trend (Last 12 months)
            var monthlyData = await GetMonthlyRevenueData();
            model.MonthlyRevenueData = monthlyData;

            // Order Status Distribution
            model.OrderStatusData = await GetOrderStatusData();

            // Top Products
            model.TopProducts = await GetTopProducts();

            // Top Customers
            model.TopCustomers = await GetTopCustomers();

            return View(model);
        }

        private async Task<List<MonthlyRevenueData>> GetMonthlyRevenueData()
        {
            // Optimize memory payload: only take dates and amounts
            var orders = await _db.Orders
                .Where(o => o.Status != OrderStatus.Cancelled && 
                           o.CreatedAt >= DateTime.Now.AddMonths(-12))
                .Select(o => new { o.CreatedAt, o.TotalAmount })
                .OrderBy(o => o.CreatedAt)
                .ToListAsync();

            // Group by month in memory for Oracle 11g compatibility
            var monthlyData = orders
                .GroupBy(o => new { o.CreatedAt.Year, o.CreatedAt.Month })
                .Select(g => new MonthlyRevenueData
                {
                    Month = $"{g.Key.Month}/{g.Key.Year}",
                    Revenue = g.Sum(o => o.TotalAmount)
                })
                .ToList();

            // Ensure we have all 12 months
            var result = new List<MonthlyRevenueData>();
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            for (int i = 11; i >= 0; i--)
            {
                var targetDate = DateTime.Now.AddMonths(-i);
                var monthKey = $"{targetDate.Month}/{targetDate.Year}";
                var existing = monthlyData.FirstOrDefault(m => m.Month == monthKey);
                
                result.Add(new MonthlyRevenueData
                {
                    Month = monthKey,
                    Revenue = existing?.Revenue ?? 0
                });
            }

            return result;
        }

        private async Task<List<OrderStatusData>> GetOrderStatusData()
        {
            var statusCounts = await _db.Orders
                .GroupBy(o => o.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync();

            return statusCounts
                .Select(x => new OrderStatusData
                {
                    Status = x.Status switch
                    {
                        OrderStatus.Pending => "Chờ xử lý",
                        OrderStatus.Processing => "Đang xử lý",
                        OrderStatus.Shipped => "Đã giao hàng",
                        OrderStatus.Completed => "Đã nhận hàng",
                        OrderStatus.Cancelled => "Đã hủy",
                        _ => x.Status.ToString()
                    },
                    Count = x.Count
                })
                .ToList();
        }


        private async Task<List<TopProductData>> GetTopProducts()
        {
            // Filter out items with null navigation properties to avoid "Nullable object must have a value" errors
            var query = _db.OrderDetails
                .Where(oi => oi.ProductSkuId != null && oi.ProductSku != null && oi.ProductSku.Product != null);

            var data = await query
                .GroupBy(oi => new { 
                    ProductId = oi.ProductSku!.ProductId, 
                    ProductName = oi.ProductSku!.Product.Name, 
                    ImageUrl = oi.ProductSku!.Product.ImageUrl 
                })
                .Select(g => new TopProductData
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName ?? "",
                    ImageUrl = g.Key.ImageUrl ?? "",
                    TotalQuantity = g.Sum(oi => oi.Quantity),
                    TotalRevenue = g.Sum(oi => oi.Subtotal)
                })
                .OrderByDescending(p => p.TotalQuantity)
                .ToListAsync();

            return data.Take(5).ToList();
        }

        private async Task<List<TopCustomerData>> GetTopCustomers()
        {
            // Execute aggregation on server, but Take(5) in memory for Oracle 11g compatibility
            var data = await _db.Orders
                .Where(o => o.Status != OrderStatus.Cancelled)
                .GroupBy(o => new { o.CustomerName, o.Phone })
                .Select(g => new TopCustomerData
                {
                    CustomerName = g.Key.CustomerName ?? "",
                    Phone = g.Key.Phone ?? "",
                    OrderCount = g.Count(),
                    TotalSpent = g.Sum(o => o.TotalAmount)
                })
                .OrderByDescending(c => c.TotalSpent)
                .ToListAsync();

            return data.Take(5).ToList();
        }
    }
}
