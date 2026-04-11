using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FashionStoreIS.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> List(string? cat, string? q, decimal? minPrice, decimal? maxPrice, string? sort, int page = 1, int pageSize = 40)
        {
            try
            {
                var query = _db.Products.Where(p => p.IsActive).AsQueryable();

                // 1. Search filter
                if (!string.IsNullOrEmpty(q))
                {
                    var searchLower = q.ToLower();
                    // Oracle 11g doesn't support ILIKE or case-insensitive EF contains well on some collations/versions
                    query = query.Where(p => p.Name.ToLower().Contains(searchLower));
                }

                // 2. Category filter
                Category? currentCategory = null;
                if (!string.IsNullOrEmpty(cat) && cat != "all-products" && cat != "new-arrival")
                {
                    currentCategory = (await _db.Categories.Where(c => c.Slug == cat).ToListAsync()).FirstOrDefault();
                    if (currentCategory != null)
                    {
                        var allCategories = await _db.Categories.ToListAsync();
                        var categoryIds = new List<int> { currentCategory.Id };
                        GetChildCategoryIds(currentCategory.Id, allCategories, categoryIds);
                        query = query.Where(p => p.CategoryId.HasValue && categoryIds.Contains(p.CategoryId.Value));
                    }
                }

                // 3. Price filter
                if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice.Value);
                if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice.Value);

                var productIdsForFilters = await query.Select(p => p.Id).ToListAsync();
                
                // 6. Sorting
                switch (sort)
                {
                    case "price-asc":
                        query = query.OrderBy(p => p.Price);
                        break;
                    case "price-desc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "name-a-z":
                        query = query.OrderBy(p => p.Name);
                        break;
                    case "name-z-a":
                        query = query.OrderByDescending(p => p.Name);
                        break;
                    case "best-selling":
                        // Using Stock ascending as a proxy for best selling since SoldCount isn't available
                        query = query.OrderBy(p => p.Stock);
                        break;
                    case "newest":
                        query = query.OrderByDescending(p => p.CreatedAt);
                        break;
                    default:
                        if (cat == "new-arrival")
                            query = query.OrderByDescending(p => p.CreatedAt);
                        else
                            query = query.OrderByDescending(p => p.Id); // Default sort
                        break;
                }

                if (string.IsNullOrWhiteSpace(cat) && string.IsNullOrWhiteSpace(q))
                    ViewBag.CategoryTitle = "TẤT CẢ SẢN PHẨM";
                else
                {
                    ViewBag.CategoryTitle = cat switch
                    {
                        "new-arrival" => "HÀNG MỚI VỀ",
                        "all-products" => "TẤT CẢ SẢN PHẨM",
                        _ => !string.IsNullOrEmpty(cat)
                            ? currentCategory?.Name?.ToUpper() ?? "SẢN PHẨM"
                            : "KẾT QUẢ TÌM KIẾM"
                    };
                }

                // Pass parameters back to view
                ViewBag.CurrentCat = cat;
                ViewBag.CurrentQ = q;
                ViewBag.MinPrice = minPrice;
                ViewBag.MaxPrice = maxPrice;
                ViewBag.CurrentSort = sort;

                // 7. Pagination and Execution
                var totalItems = await query.CountAsync();
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                ViewBag.CurrentPage = page;

                var products = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            
                if (cat == "new-arrival" && string.IsNullOrEmpty(q) && products.Count == 0 && page == 1)
                {
                    // Fallback for empty new arrival on page 1 if needed, but the query above is definitive
                }
            
                var categoryIdsInProducts = products.Select(p => p.CategoryId).Distinct().ToList();
                var categories = await _db.Categories.Where(c => categoryIdsInProducts.Contains(c.Id)).ToListAsync();
                foreach (var p in products)
                {
                    p.Category = categories.FirstOrDefault(c => c.Id == p.CategoryId);
                }

                return View(products);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Không tải được danh sách sản phẩm. Kiểm tra kết nối database. (" + ex.Message + ")";
                ViewBag.CategoryTitle = "SẢN PHẨM";
                ViewBag.CurrentCat = cat;
                ViewBag.CurrentQ = q;
                ViewBag.MinPrice = minPrice;
                ViewBag.MaxPrice = maxPrice;
                ViewBag.CurrentSort = sort;
                return View(new List<Product>());
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var product = await _db.Products
                    .Include(p => p.Category)
                    .Include(p => p.Images)
                    .Include(p => p.Skus)
                    .Include(p => p.Reviews.Where(r => r.IsApproved).OrderByDescending(r => r.CreatedAt))
                        .ThenInclude(r => r.User)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null || !product.IsActive) return NotFound();

                return View(product);
            }
            catch
            {
                return NotFound();
            }
        }

        private void GetChildCategoryIds(int parentId, List<Category> allCategories, List<int> ids)
        {
            var children = allCategories.Where(c => c.ParentCategoryId == parentId).Select(c => c.Id).ToList();
            foreach (var childId in children)
            {
                ids.Add(childId);
                GetChildCategoryIds(childId, allCategories, ids);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveVouchers()
        {
            var now = DateTime.Now;
            var vouchers = await _db.Vouchers
                .Where(v => v.IsActive && (v.ExpiryDate == null || v.ExpiryDate > now))
                .OrderByDescending(v => v.DiscountAmount)
                .Select(v => new {
                    code = v.Code,
                    amount = v.DiscountAmount,
                    minOrder = v.MinOrderAmount,
                    expiry = v.ExpiryDate.ToString("dd/MM/yyyy")
                })
                .ToListAsync();

            return Json(new { success = true, vouchers = vouchers });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(int productId, int rating, string comment)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId)) return Unauthorized();

                var review = new ProductReview
                {
                    ProductId = productId,
                    UserId = userId,
                    Rating = rating,
                    Comment = comment,
                    CreatedAt = DateTime.UtcNow,
                    IsApproved = true // In a real scenario, this might be false for moderation
                };

                _db.ProductReviews.Add(review);
                await _db.SaveChangesAsync();

                TempData["Success"] = "Cảm ơn bạn đã để lại đánh giá!";
                return RedirectToAction("Detail", new { id = productId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra khi gửi đánh giá: " + ex.Message;
                return RedirectToAction("Detail", new { id = productId });
            }
        }
    }
}
