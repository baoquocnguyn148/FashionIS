using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionStoreIS.Services
{
    public class InventoryInsight
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Type { get; set; } = "Info"; // Info, Warning, Success, Danger
        public string ActionUrl { get; set; } = "";
        public string ActionText { get; set; } = "";
    }

    public class InventoryIntelligenceViewModel
    {
        public decimal TotalAssetValue { get; set; }
        public decimal PotentialRevenue { get; set; }
        public decimal PotentialMargin => PotentialRevenue - TotalAssetValue;
        public decimal MarginPercentage => PotentialRevenue > 0 ? (PotentialMargin / PotentialRevenue) * 100 : 0;

        public int TotalSkus { get; set; }
        public int OutOfStockCount { get; set; }
        public int LowStockCount { get; set; }
        public int HealthyStockCount { get; set; }

        public List<InventoryInsight> Insights { get; set; } = new();
    }

    public class InventoryIntelligenceService
    {
        private readonly ApplicationDbContext _db;

        public InventoryIntelligenceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<InventoryIntelligenceViewModel> GetIntelligenceAsync(int lowStockThreshold = 10)
        {
            var skus = await _db.ProductSkus
                .Where(s => !s.IsDeleted)
                .Include(s => s.Product)
                .ToListAsync();

            var vm = new InventoryIntelligenceViewModel
            {
                TotalSkus = skus.Count,
                TotalAssetValue = skus.Sum(s => s.Stock * s.CostPrice),
                PotentialRevenue = skus.Sum(s => s.Stock * (s.PriceOverride > 0 ? s.PriceOverride.Value : s.SellingPrice)),
                OutOfStockCount = skus.Count(s => s.Stock <= 0),
                LowStockCount = skus.Count(s => s.Stock > 0 && s.Stock <= lowStockThreshold),
                HealthyStockCount = skus.Count(s => s.Stock > lowStockThreshold)
            };

            // Calculate Insights
            var now = DateTime.Now;
            var thirtyDaysAgo = now.AddDays(-30);

            // 1. Identify "Hot" but Low Stock items (Sold > 5 in last 30 days)
            var recentSales = await _db.OrderDetails
                .Include(od => od.Order)
                .Where(od => od.Order.CreatedAt >= thirtyDaysAgo && od.Order.Status != OrderStatus.Cancelled)
                .GroupBy(od => od.ProductSkuId)
                .Select(g => new { SkuId = g.Key, Qty = g.Sum(x => x.Quantity) })
                .ToListAsync();

            var hotSkus = recentSales.Where(s => s.Qty >= 5).Select(s => s.SkuId).ToList();
            var hotAndLow = skus.Where(s => hotSkus.Contains(s.Id) && s.Stock <= lowStockThreshold).ToList();

            if (hotAndLow.Any())
            {
                vm.Insights.Add(new InventoryInsight
                {
                    Title = "Cảnh báo: Hàng bán chạy sắp hết!",
                    Message = $"Có {hotAndLow.Count} mặt hàng bán chạy đang có tồn kho thấp (Dưới {lowStockThreshold}).",
                    Type = "Danger",
                    ActionUrl = "/Admin/Inventory?search=" + hotAndLow.First().SkuCode,
                    ActionText = "Nhập hàng ngay"
                });
            }

            // 2. Identify "Dead Stock" (Zero sales in 60 days, Stock > 20)
            var sixtyDaysAgo = now.AddDays(-60);
            var soldInSixtyDays = await _db.OrderDetails
                .Include(od => od.Order)
                .Where(od => od.Order.CreatedAt >= sixtyDaysAgo && od.Order.Status != OrderStatus.Cancelled)
                .Select(od => od.ProductSkuId)
                .Distinct()
                .ToListAsync();

            var deadStock = skus.Where(s => s.Stock > 20 && !soldInSixtyDays.Contains(s.Id)).ToList();
            if (deadStock.Any())
            {
                vm.Insights.Add(new InventoryInsight
                {
                    Title = "Cơ hội: Xả hàng tồn kho chậm",
                    Message = $"{deadStock.Count} mặt hàng chưa có đơn trong 60 ngày. Hãy cân nhắc chạy Campaign giảm giá.",
                    Type = "Warning",
                    ActionUrl = "/Admin/Campaign/Create",
                    ActionText = "Tạo Campaign"
                });
            }

            // 3. Out of stock alert
            if (vm.OutOfStockCount > 0)
            {
                vm.Insights.Add(new InventoryInsight
                {
                    Title = "Thông báo: Hàng đã hết",
                    Message = $"Hiện có {vm.OutOfStockCount} SKU đã hết hàng hoàn toàn.",
                    Type = "Info",
                    ActionUrl = "/Admin/Inventory",
                    ActionText = "Xem chi tiết"
                });
            }

            return vm;
        }
    }
}
