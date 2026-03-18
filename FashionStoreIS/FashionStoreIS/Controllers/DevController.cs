using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FashionStoreIS.Controllers
{
    [Route("dev")]
    public class DevController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        private const string CART_COOKIE_NAME = "BNStore_Cart";

        public DevController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpGet("smoke/checkout")]
        public async Task<IActionResult> SmokeCheckout()
        {
            if (!_env.IsDevelopment()) return NotFound();

            var sku = await _db.ProductSkus
                .Include(s => s.Product)
                .OrderBy(s => s.Id)
                .FirstOrDefaultAsync(s => s.IsActive && s.Product != null && s.Product.IsActive);

            if (sku == null || sku.Product == null) return Content("No SKU found.");

            var cookieData = new[]
            {
                new
                {
                    ProductId = sku.ProductId,
                    ProductSkuId = (int?)sku.Id,
                    Color = sku.Color ?? "Default",
                    Size = sku.Size ?? "One Size",
                    Quantity = 1
                }
            };

            Response.Cookies.Append(
                CART_COOKIE_NAME,
                JsonSerializer.Serialize(cookieData),
                new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(1),
                    HttpOnly = true,
                    Secure = Request.IsHttps,
                    SameSite = SameSiteMode.Lax,
                    IsEssential = true
                });

            return Redirect("/Checkout");
        }

        [HttpGet("smoke/place-order")]
        public async Task<IActionResult> SmokePlaceOrder()
        {
            if (!_env.IsDevelopment()) return NotFound();

            var sku = await _db.ProductSkus
                .Include(s => s.Product)
                .Include(s => s.Inventories)
                .OrderBy(s => s.Id)
                .FirstOrDefaultAsync(s => s.IsActive && s.Product != null && s.Product.IsActive);

            if (sku == null || sku.Product == null) return Json(new { success = false, message = "No SKU found." });

            var order = new Order
            {
                CustomerName = "Smoke Test",
                Address = "HCM",
                Phone = "0900000000",
                TotalAmount = 0,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now,
                UserId = null
            };

            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                var qty = 1;
                var unitPrice = sku.PriceOverride.HasValue && sku.PriceOverride.Value > 0 ? sku.PriceOverride.Value : sku.Product.Price;
                var lineSubtotal = unitPrice * qty;

                _db.OrderDetails.Add(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductSkuId = sku.Id,
                    Quantity = qty,
                    UnitPrice = unitPrice,
                    Subtotal = lineSubtotal,
                    DiscountPercent = 0
                });

                var inventory = sku.Inventories.FirstOrDefault();
                if (inventory != null)
                {
                    if (inventory.QuantityOnHand < qty) return Json(new { success = false, message = "Insufficient inventory." });
                    inventory.QuantityOnHand -= qty;
                    inventory.LastUpdated = DateTime.Now;
                }
                else
                {
                    if (sku.Stock < qty) return Json(new { success = false, message = "Insufficient stock." });
                    sku.Stock -= qty;
                }

                sku.Product.Stock -= qty;
                order.TotalAmount = lineSubtotal;
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new { success = true, orderId = order.Id, total = order.TotalAmount });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}

