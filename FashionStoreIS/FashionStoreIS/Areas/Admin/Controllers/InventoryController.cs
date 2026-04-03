using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    // ViewModel for the inventory page
    public class InventoryGroupItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string? ImageUrl { get; set; }
        public List<ProductSku> Skus { get; set; } = new();
        public int TotalStock { get; set; }
    }

    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly InventoryIntelligenceService _intel;

        public InventoryController(ApplicationDbContext db, InventoryIntelligenceService intel)
        {
            _db = db;
            _intel = intel;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewBag.Search = search;

            var query = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Skus)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search));

            var products = await query.OrderBy(p => p.Name).ToListAsync();

            var groups = products.Select(p => new InventoryGroupItem
            {
                ProductId = p.Id,
                ProductName = p.Name,
                CategoryName = p.Category?.Name ?? "—",
                ImageUrl = p.ImageUrl,
                Skus = p.Skus.Where(s => !s.IsDeleted).OrderBy(s => s.Color).ThenBy(s => s.Size).ToList(),
                TotalStock = p.Skus.Where(s => !s.IsDeleted).Sum(s => s.Stock)
            }).ToList();

            ViewBag.InventoryItems = groups;
            ViewBag.Intelligence = await _intel.GetIntelligenceAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(int skuId, int stock)
        {
            var sku = await _db.ProductSkus.FirstOrDefaultAsync(s => s.Id == skuId);
            if (sku == null) return NotFound();

            sku.Stock = Math.Max(0, stock);

            // Sync Product.Stock aggregate
            var product = await _db.Products.FindAsync(sku.ProductId);
            if (product != null)
            {
                var allProductSkus = await _db.ProductSkus
                    .Where(s => s.ProductId == sku.ProductId && !s.IsDeleted)
                    .ToListAsync();
                product.Stock = allProductSkus.Sum(s => s.Stock);
            }

            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã cập nhật tồn kho: {sku.SkuCode} = {stock}";
            return RedirectToAction("Index");
        }
    }
}
