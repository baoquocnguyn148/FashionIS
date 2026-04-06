using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Controllers.Api
{
    [ApiController]
    [Route("api/chatbot")]
    public class ChatbotApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ChatbotApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("products")]
        public async Task<IActionResult> SearchProducts(string? q, string? category, string? sort, decimal? minPrice, decimal? maxPrice, int limit = 10)
        {
            var query = _db.Products.Include(p => p.Category).Where(p => p.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                var lowerQ = q.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(lowerQ) 
                                      || p.Description!.ToLower().Contains(lowerQ)
                                      || p.Skus.Any(s => s.Color.ToLower().Contains(lowerQ) || s.Size.ToLower().Contains(lowerQ)));
            }
            
            if (!string.IsNullOrEmpty(category))
            {
                var lowerCat = category.ToLower();
                // 1. Try strict category match first
                var categoryQuery = query.Where(p => p.Category != null && (p.Category.Slug.Contains(lowerCat) || p.Category.Name.ToLower().Contains(lowerCat)));
                
                if (await categoryQuery.AnyAsync())
                {
                    query = categoryQuery;
                }
                else
                {
                    // 2. Flexible Fallback: If no category matches, treat the 'category' string as an additional keyword for product name/SKU
                    query = query.Where(p => p.Name.ToLower().Contains(lowerCat) 
                                          || p.Description!.ToLower().Contains(lowerCat)
                                          || p.Skus.Any(s => s.Color.ToLower().Contains(lowerCat) || s.Size.ToLower().Contains(lowerCat)));
                }
            }

            if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice.Value);
            if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice.Value);

            // Sorting Logic
            query = sort?.ToLower() switch
            {
                "popular" => query.OrderByDescending(p => p.Stock), // Using stock as proxy for popularity/availability
                "newest" => query.OrderByDescending(p => p.CreatedAt),
                "price_low" => query.OrderBy(p => p.Price),
                "price_high" => query.OrderByDescending(p => p.Price),
                _ => query.OrderByDescending(p => p.Id) // Default
            };

            var totalCount = await query.CountAsync();

            var products = await query
                .Take(limit)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Stock,
                    p.ImageUrl,
                    CategoryName = p.Category != null ? p.Category.Name : "N/A"
                })
                .ToListAsync();

            return Ok(new { TotalCount = totalCount, Items = products });
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var product = await _db.Products
                .Include(p => p.Category)
                .Include(p => p.Skus)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            return Ok(new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                product.ImageUrl,
                CategoryName = product.Category?.Name,
                Skus = product.Skus.Select(s => new { s.Id, s.Size, s.Color, s.SellingPrice, s.Stock })
            });
        }

        [HttpGet("track-order/{orderCode}")]
        public async Task<IActionResult> TrackOrder(string orderCode)
        {
            var order = await _db.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);

            if (order == null) return NotFound(new { message = "Không tìm thấy đơn hàng." });

            return Ok(new
            {
                order.OrderCode,
                Status = order.Status.ToString(),
                order.TotalAmount,
                order.CreatedAt,
                Items = order.OrderDetails.Select(od => new
                {
                    ProductName = od.Product?.Name,
                    od.Quantity,
                    od.UnitPrice
                })
            });
        }

        [HttpGet("vouchers")]
        public async Task<IActionResult> GetVouchers()
        {
            var now = DateTime.Now;
            var vouchers = await _db.Vouchers
                .Where(v => v.IsActive && v.ExpiryDate > now && v.UsedCount < v.MaxUsageCount)
                .Select(v => new
                {
                    v.Code,
                    v.DiscountAmount,
                    v.MinOrderAmount,
                    v.ExpiryDate
                })
                .ToListAsync();

            return Ok(vouchers);
        }
    }
}
