using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public ProductsController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkAction(List<int> productIds, string action)
        {
            if (productIds == null || !productIds.Any()) return RedirectToAction("Index");

            var products = await _db.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            if (action == "delete" && User.IsInRole("SuperAdmin"))
            {
                foreach (var p in products)
                {
                    p.IsDeleted = true;
                    p.IsActive = false;
                    p.UpdatedAt = DateTime.Now;
                }
            }
            else if (action == "hide")
            {
                foreach (var p in products) p.IsActive = false;
            }
            else if (action == "show")
            {
                foreach (var p in products) p.IsActive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Migrates all product ImageUrls from local /images/... paths to GitHub CDN URLs.
        /// Called from Admin UI to fix broken images on Render (ephemeral filesystem).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> FixImages()
        {
            const string CDN = "https://raw.githubusercontent.com/baoquocnguyn148/FashionIS/main/FashionStoreIS/FashionStoreIS/wwwroot/images/products/";

            // Map: filename -> CDN URL (handles case-sensitive filenames on Linux/Render)
            var filenameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["BLANKSHIRTBLACK_main.png"]                = CDN + "BLANKSHIRTBLACK_main.png",
                ["BlankShirtWhite_main.png"]               = CDN + "BlankShirtWhite_main.png",
                ["COACHSHIRT-GREEN_main.png"]              = CDN + "COACHSHIRT-GREEN_main.png",
                ["FW25OSMSWEATER_GRAY_main.png"]           = CDN + "FW25OSMSWEATER_GRAY_main.png",
                ["Coachtracksuitpant.png"]                 = CDN + "Coachtracksuitpant.png",
                ["sportsweetpant_gray.png"]                = CDN + "sportsweetpant_gray.png",
                ["vitaltrankpants_blue.png"]               = CDN + "vitaltrankpants_blue.png",
                ["vitaltrankpants_red.png"]                = CDN + "vitaltrankpants_red.png",
                ["BlackSBomber.png"]                       = CDN + "BlackSBomber.png",
                ["W25SSMAJEANSZIPHOODIE_BLACK_main.png"]   = CDN + "W25SSMAJEANSZIPHOODIE_BLACK_main.png",
                ["COWHIDELEATHERBAG-EMBOSSEDBLACK.png"]    = CDN + "COWHIDELEATHERBAG-EMBOSSEDBLACK.png",
                ["COWHIDELEATHERBAG-EMBOSSEDWHITE.png"]    = CDN + "COWHIDELEATHERBAG-EMBOSSEDWHITE.png",
                ["COWHIDELEATHERBAG-HAIRON BROWN.png"]     = CDN + "COWHIDELEATHERBAG-HAIRON BROWN.png",
                ["Papacap_red.png"]                        = CDN + "Papacap_red.png",
                ["igifms_cap.png"]                         = CDN + "igifms_cap.png",
            };

            var products = await _db.Products.ToListAsync();
            int fixedCount = 0;

            foreach (var p in products)
            {
                if (string.IsNullOrEmpty(p.ImageUrl)) continue;

                // Already a CDN URL — skip
                if (p.ImageUrl.StartsWith("https://raw.githubusercontent.com")) continue;

                // Extract filename from local path e.g. "/images/products/BlankShirtWhite_main.png"
                var filename = Path.GetFileName(p.ImageUrl);

                if (filenameMap.TryGetValue(filename, out var cdnUrl))
                {
                    p.ImageUrl = cdnUrl;
                    fixedCount++;
                }
            }

            await _db.SaveChangesAsync();

            TempData["Success"] = $"✅ Đã cập nhật {fixedCount} ảnh sản phẩm sang GitHub CDN. Trang web sẽ hiển thị ảnh đúng ngay bây giờ.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(string? search, int? categoryId)
        {
            var query = _db.Products.Include(p => p.Category).AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search));
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId);
            
            ViewBag.Search = search;
            ViewBag.CategoryId = categoryId;
            ViewBag.Categories = await _db.Categories.Where(c => c.IsActive).ToListAsync();
            
            return View(await query.OrderByDescending(p => p.CreatedAt).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            ViewBag.Categories = await _db.Categories.Where(c => c.IsActive).ToListAsync();
            ViewBag.Suppliers = await _db.Suppliers.ToListAsync();
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, string? ImageUrlInput, IFormFile? imageFile, List<IFormFile>? galleryFiles)
        {
            if (imageFile != null && imageFile.Length > 0)
                model.ImageUrl = await SaveImage(imageFile);
            else if (!string.IsNullOrWhiteSpace(ImageUrlInput))
                model.ImageUrl = ImageUrlInput;

            model.CreatedAt = DateTime.Now;
            if (string.IsNullOrWhiteSpace(model.Slug))
                model.Slug = GenerateSlug(model.Name);

            model.SupplierId = await EnsureSupplierIdAsync(model.SupplierId);

            var incomingSkus = NormalizeIncomingSkus(model);
            if (incomingSkus.Count > 0)
                model.Stock = incomingSkus.Sum(s => s.Stock);

            // Prevent EF from automatically inserting the raw, unnormalized Skus from the form
            model.Skus?.Clear();

            _db.Products.Add(model);
            await _db.SaveChangesAsync(); // Get Product ID

            // Handle Gallery
            if (galleryFiles != null)
            {
                foreach (var file in galleryFiles)
                {
                    var url = await SaveImage(file);
                    _db.ProductImages.Add(new ProductImage { ProductId = model.Id, ImageUrl = url });
                }
                await _db.SaveChangesAsync();
            }

            if (incomingSkus.Count > 0)
            {
                foreach (var sku in incomingSkus)
                {
                    sku.ProductId = model.Id;
                    _db.ProductSkus.Add(sku);
                }
                await _db.SaveChangesAsync();
            }
            
            TempData["Success"] = "Thêm sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.Products
                .Include(p => p.Images)
                .Include(p => p.Skus.Where(s => s.IsActive == true))
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if (product == null) return NotFound();
            
            ViewBag.Categories = await _db.Categories.Where(c => c.IsActive).ToListAsync();
            ViewBag.Suppliers = await _db.Suppliers.ToListAsync();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product model, string? ImageUrlInput, IFormFile? imageFile, List<IFormFile>? galleryFiles)
        {
            var existing = (await _db.Products
                .Include(p => p.Images)
                .Where(p => p.Id == model.Id)
                .ToListAsync()).FirstOrDefault();
            if (existing == null) return NotFound();

            existing.Name = model.Name;
            if (string.IsNullOrWhiteSpace(model.Slug))
                existing.Slug = GenerateSlug(model.Name);
            else
                existing.Slug = model.Slug;
            existing.Description = model.Description;
            existing.Price = model.Price;
            existing.CategoryId = model.CategoryId;
            existing.Stock = model.Stock;
            existing.IsActive = model.IsActive;
            existing.SupplierId = await EnsureSupplierIdAsync(model.SupplierId);

            if (imageFile != null && imageFile.Length > 0)
                existing.ImageUrl = await SaveImage(imageFile);
            else if (!string.IsNullOrWhiteSpace(ImageUrlInput))
                existing.ImageUrl = ImageUrlInput;

            // Handle Gallery
            if (galleryFiles != null)
            {
                foreach (var file in galleryFiles)
                {
                    var url = await SaveImage(file);
                    _db.ProductImages.Add(new ProductImage { ProductId = existing.Id, ImageUrl = url });
                }
            }

            var existingSkus = await _db.ProductSkus.Where(v => v.ProductId == model.Id).ToListAsync();
            var incomingSkus = NormalizeIncomingSkus(model);

            var incomingIds = incomingSkus.Where(s => s.Id > 0).Select(s => s.Id).Distinct().ToHashSet();
            var toRemove = existingSkus.Where(es => !incomingIds.Contains(es.Id)).ToList();
            
            // Use SOFT DELETE to prevent FOREIGN KEY constraint crashes if SKUs are in orders/carts
            foreach (var skuToRemove in toRemove)
            {
                skuToRemove.IsActive = false;
            }

            foreach (var incoming in incomingSkus)
            {
                if (incoming.Id > 0)
                {
                    var current = existingSkus.FirstOrDefault(es => es.Id == incoming.Id);
                    if (current == null) continue;

                    current.SKU = incoming.SKU;
                    current.SkuCode = incoming.SkuCode;
                    current.Size = incoming.Size;
                    current.Color = incoming.Color;
                    current.CostPrice = incoming.CostPrice;
                    current.SellingPrice = incoming.SellingPrice;
                    current.PriceOverride = incoming.PriceOverride;
                    current.Stock = incoming.Stock;
                    current.IsActive = incoming.IsActive;
                }
                else
                {
                    incoming.ProductId = existing.Id;
                    _db.ProductSkus.Add(incoming);
                }
            }

            if (incomingSkus.Count > 0)
                existing.Stock = incomingSkus.Sum(s => s.Stock);

            await _db.SaveChangesAsync();
            TempData["Success"] = "Cập nhật sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var img = (await _db.ProductImages.Where(i => i.Id == id).ToListAsync()).FirstOrDefault();
            if (img != null)
            {
                _db.ProductImages.Remove(img);
                await _db.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = (await _db.Products.Where(p => p.Id == id).ToListAsync()).FirstOrDefault();
            if (product != null)
            {
                product.IsDeleted = true;
                product.IsActive = false;
                product.UpdatedAt = DateTime.Now;
                await _db.SaveChangesAsync();
                TempData["Success"] = "Đã xóa sản phẩm.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleActive(int id)
        {
            var product = (await _db.Products.Where(p => p.Id == id).ToListAsync()).FirstOrDefault();
            if (product != null)
            {
                product.IsActive = !product.IsActive;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FixBrokenImages()
        {
            var brokenProducts = await _db.Products
                .Where(p => p.ImageUrl != null && p.ImageUrl.Contains("/uploads/products/"))
                .ToListAsync();

            if (brokenProducts.Any())
            {
                foreach (var p in brokenProducts)
                {
                    // Random unsplash placeholder based on category
                    string term = p.CategoryId == 1 ? "t-shirt" : (p.CategoryId == 2 ? "pants" : "jacket");
                    p.ImageUrl = $"https://source.unsplash.com/random/800x800/?{term},{p.Id}";
                }
                await _db.SaveChangesAsync();
                TempData["Success"] = $"Đã tự động sửa lỗi ảnh cho {brokenProducts.Count} sản phẩm!";
            }
            else
            {
                TempData["Info"] = "Không tìm thấy sản phẩm nào bị lỗi ảnh hệ thống cục bộ.";
            }

            return RedirectToAction("Index");
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "uploads", "products");
            Directory.CreateDirectory(uploads);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploads, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return "/uploads/products/" + fileName;
        }

        private async Task<int> EnsureSupplierIdAsync(int supplierId)
        {
            if (supplierId > 0) return supplierId;

            var suppliers = await _db.Suppliers.Take(1).ToListAsync();
            var existing = suppliers.FirstOrDefault();
            if (existing != null) return existing.Id;

            var created = new Supplier
            {
                Name = "Default Supplier",
                Phone = "N/A",
                Email = "noreply@example.com",
                CreatedAt = DateTime.Now
            };
            _db.Suppliers.Add(created);
            await _db.SaveChangesAsync();
            return created.Id;
        }

        private static List<ProductSku> NormalizeIncomingSkus(Product model)
        {
            var result = new List<ProductSku>();
            if (model.Skus == null) return result;

            foreach (var raw in model.Skus)
            {
                var color = (raw.Color ?? "").Trim();
                var size = (raw.Size ?? "").Trim();
                if (string.IsNullOrWhiteSpace(color) || string.IsNullOrWhiteSpace(size)) continue;

                // Respect DB restrictions (Color: 50, Size: 10)
                if (color.Length > 50) color = color.Substring(0, 50);
                if (size.Length > 10) size = size.Substring(0, 10);

                var skuCode = (raw.SKU ?? "").Trim();
                if (string.IsNullOrWhiteSpace(skuCode))
                    skuCode = GenerateSkuCode(model.Slug, color, size);

                var sellingPrice = raw.SellingPrice > 0 ? raw.SellingPrice : model.Price;
                var costPrice = raw.CostPrice >= 0 ? raw.CostPrice : 0;
                var stock = raw.Stock >= 0 ? raw.Stock : 0;

                result.Add(new ProductSku
                {
                    Id = raw.Id,
                    SKU = skuCode,
                    SkuCode = string.IsNullOrWhiteSpace(raw.SkuCode) ? skuCode : raw.SkuCode.Trim(),
                    Color = color,
                    Size = size,
                    CostPrice = costPrice,
                    SellingPrice = sellingPrice,
                    PriceOverride = raw.PriceOverride,
                    Stock = stock,
                    IsActive = raw.IsActive
                });
            }

            return result;
        }

        private static string GenerateSkuCode(string? slug, string color, string size)
        {
            var safeSlug = string.IsNullOrWhiteSpace(slug) ? "item" : slug.Trim();
            var safeColor = Regex.Replace(color.Trim().ToLowerInvariant(), @"\s+", "-");
            var safeSize = Regex.Replace(size.Trim().ToLowerInvariant(), @"\s+", "-");
            
            // Ensure prefix matches max lengths, allowing slug some space 
            // Total limit is 30, use up to 10 chars from slug, 8 from color, 4 from size
            var shortSlug = safeSlug.Length > 10 ? safeSlug.Substring(0, 10) : safeSlug;
            var shortColor = safeColor.Length > 8 ? safeColor.Substring(0, 8) : safeColor;
            var shortSize = safeSize.Length > 4 ? safeSize.Substring(0, 4) : safeSize;
            
            var raw = $"{shortSlug}-{shortColor}-{shortSize}";
            raw = Regex.Replace(raw, @"[^a-z0-9\-]", "");
            raw = Regex.Replace(raw, @"\-{2,}", "-").Trim('-');
            
            // Cap at 25 length so we can append 5 characters "-XXXX"
            if (raw.Length > 24)
            {
                raw = raw.Substring(0, 24).Trim('-');
            }
            
            var uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 4);
            raw = $"{raw}-{uniqueSuffix}";
            
            return raw.ToUpperInvariant();
        }

        private static string GenerateSlug(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "item";
            var normalized = input.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc == UnicodeCategory.NonSpacingMark) continue;
                sb.Append(c);
            }
            var withoutDiacritics = sb.ToString().Normalize(NormalizationForm.FormC);
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"[^a-z0-9\s-]", "");
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"\s+", "-").Trim('-');
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"\-{2,}", "-");
            return string.IsNullOrWhiteSpace(withoutDiacritics) ? "item" : withoutDiacritics;
        }
    }
}
