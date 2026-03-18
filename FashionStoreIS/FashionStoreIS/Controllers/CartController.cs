using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FashionStoreIS.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private const string CART_COOKIE_NAME = "BNStore_Cart";

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cart = await GetCartItemsAsync();
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int? skuId, string color, string size, int quantity)
        {
            if (quantity <= 0) return BadRequest();

            // 1. Fetch Product and SKU from DB
            var product = await _db.Products
                .Include(p => p.Skus)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return NotFound();

            // 2. Validate Stock
            int availableStock = 0;
            if (skuId.HasValue)
            {
                var sku = product.Skus.FirstOrDefault(s => s.Id == skuId.Value);
                if (sku == null) return NotFound("SKU không tồn tại");
                availableStock = sku.Stock;
            }
            else
            {
                availableStock = product.Stock;
            }

            // 3. Check existing quantity in cart
            var cart = await GetCartItemsAsync();
            var existingItem = cart.FirstOrDefault(i => i.ProductId == productId && i.ProductSkuId == skuId && i.Color == color && i.Size == size);
            int currentQtyInCart = existingItem?.Quantity ?? 0;

            if (currentQtyInCart + quantity > availableStock)
            {
                return Json(new { success = false, message = $"Số lượng vượt quá tồn kho (Còn lại: {availableStock - currentQtyInCart})" });
            }

            // 4. Update or Add Item
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItemViewModel
                {
                    ProductId = productId,
                    ProductSkuId = skuId,
                    Color = color,
                    Size = size,
                    Quantity = quantity
                });
            }

            SaveCartItems(cart);
            return Json(new { success = true, itemCount = cart.Sum(i => i.Quantity) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int productId, string color, string size, int delta)
        {
            var cart = await GetCartItemsAsync();
            var item = cart.FirstOrDefault(i => i.ProductId == productId && i.Color == color && i.Size == size);

            if (item != null)
            {
                item.Quantity += delta;
                
                // Re-validate stock on update
                var product = await _db.Products.Include(p => p.Skus).FirstOrDefaultAsync(p => p.Id == productId);
                if (product != null)
                {
                    int availableStock = item.ProductSkuId.HasValue 
                        ? product.Skus.FirstOrDefault(s => s.Id == item.ProductSkuId.Value)?.Stock ?? 0 
                        : product.Stock;
                    
                    if (item.Quantity > availableStock) item.Quantity = availableStock;
                }

                if (item.Quantity <= 0) cart.Remove(item);
                SaveCartItems(cart);
            }

            var fullCart = await GetCartItemsAsync(); // Re-hydrate for view
            return PartialView("_CartDrawerPartial", fullCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int productId, string color, string size)
        {
            var cart = await GetCartItemsAsync();
            var item = cart.FirstOrDefault(i => i.ProductId == productId && i.Color == color && i.Size == size);

            if (item != null)
            {
                cart.Remove(item);
                SaveCartItems(cart);
            }

            var fullCart = await GetCartItemsAsync(); // Re-hydrate for view
            return PartialView("_CartDrawerPartial", fullCart);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartCount()
        {
            var cart = await GetCartItemsAsync();
            return Json(new { count = cart.Sum(i => i.Quantity) });
        }

        [HttpGet]
        public async Task<IActionResult> GetCartDrawer()
        {
            var cart = await GetCartItemsAsync();
            return PartialView("_CartDrawerPartial", cart);
        }

        private async Task<List<CartItemViewModel>> GetCartItemsAsync()
        {
            var cookie = Request.Cookies[CART_COOKIE_NAME];
            if (string.IsNullOrEmpty(cookie)) return new List<CartItemViewModel>();

            try
            {
                var cartItems = JsonSerializer.Deserialize<List<CartItemViewModel>>(cookie) ?? new List<CartItemViewModel>();
                
                if (cartItems.Any())
                {
                    // Hydrate data from Database
                    var productIds = cartItems.Select(i => i.ProductId).Distinct().ToList();
                    var skuIds = cartItems.Where(i => i.ProductSkuId.HasValue).Select(i => i.ProductSkuId!.Value).Distinct().ToList();

                    var products = await _db.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
                    var skus = await _db.ProductSkus.Where(s => skuIds.Contains(s.Id)).ToListAsync();

                    foreach (var item in cartItems)
                    {
                        var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                        if (product != null)
                        {
                            item.Name = product.Name;
                            item.ImageUrl = product.ImageUrl ?? "";
                            
                            // Use SKU price if available, otherwise product price
                            if (item.ProductSkuId.HasValue)
                            {
                                var sku = skus.FirstOrDefault(s => s.Id == item.ProductSkuId.Value);
                                item.Price = sku?.SellingPrice ?? product.Price;
                            }
                            else
                            {
                                item.Price = product.Price;
                            }
                        }
                    }
                }
                return cartItems;
            }
            catch
            {
                return new List<CartItemViewModel>();
            }
        }

        private void SaveCartItems(List<CartItemViewModel> items)
        {
            // Only store minimal info for security and space
            var cookieData = items.Select(i => new
            {
                i.ProductId,
                i.ProductSkuId,
                i.Color,
                i.Size,
                i.Quantity
            }).ToList();

            var options = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7),
                HttpOnly = true,
                Secure = Request.IsHttps,
                SameSite = SameSiteMode.Lax,
                IsEssential = true
            };
            Response.Cookies.Append(CART_COOKIE_NAME, JsonSerializer.Serialize(cookieData), options);
        }
    }
}
