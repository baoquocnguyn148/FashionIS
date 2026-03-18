using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace FashionStoreIS.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private const string CART_COOKIE_NAME = "BNStore_Cart";
        private static string GenerateOrderCode()
        {
            var ts = DateTime.UtcNow.ToString("yyMMddHHmmss");
            var rnd = Random.Shared.Next(1000, 9999);
            return $"BN{ts}{rnd}";
        }

        public CheckoutController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cart = await GetCartItemsHydratedAsync();
            if (cart.Count == 0) return RedirectToAction("Index", "Home");
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyVoucher(string code, decimal currentTotal)
        {
            if (string.IsNullOrEmpty(code)) return Json(new { success = false, message = "Vui lòng nhập mã." });

            // Never trust totals from client; compute from DB-backed cart state
            var cart = await GetCartItemsHydratedAsync();
            if (cart.Count == 0) return Json(new { success = false, message = "Giỏ hàng trống." });
            var subtotal = cart.Sum(i => i.Quantity * i.Price);

            var vouchers = await _db.Vouchers
                .Where(v => v.Code == code && v.IsActive && v.ExpiryDate >= DateTime.Now)
                .ToListAsync();
            
            var voucher = vouchers.FirstOrDefault();

            if (voucher == null) return Json(new { success = false, message = "Mã giảm giá không tồn tại hoặc đã hết hạn." });
            if (subtotal < voucher.MinOrderAmount) 
                return Json(new { success = false, message = $"Đơn hàng tối thiểu {voucher.MinOrderAmount:N0} VND để sử dụng mã này." });

            return Json(new { success = true, discount = voucher.DiscountAmount, code = voucher.Code });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessOrder(string customerName, string address, string phone, string? voucherCode, string? note)
        {
            var cart = await GetCartItemsHydratedAsync();
            if (cart.Count == 0)
            {
                TempData["Error"] = "Giỏ hàng của bạn đang trống.";
                return RedirectToAction("Index", "Home");
            }

            // 1. Basic Validation
            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                TempData["Error"] = "Vui lòng điền đầy đủ thông tin giao hàng.";
                return RedirectToAction("Index");
            }

            // 2. Fetch all necessary data in one go to minimize DB roundtrips
            var skuIds = cart.Where(i => i.ProductSkuId.HasValue).Select(i => i.ProductSkuId!.Value).Distinct().ToList();
            var productIds = cart.Select(i => i.ProductId).Distinct().ToList();

            var skus = await _db.ProductSkus
                .Include(s => s.Product)
                .Include(s => s.Inventories)
                .Where(s => skuIds.Contains(s.Id))
                .ToListAsync();

            var products = await _db.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            var store = await _db.Stores
                .Where(s => s.IsActive)
                .OrderBy(s => s.Id)
                .FirstOrDefaultAsync();

            if (store == null)
            {
                TempData["Error"] = "Hệ thống đang bảo trì, vui lòng quay lại sau (Thiếu thông tin cửa hàng).";
                return RedirectToAction("Index");
            }

            // 3. Start Transaction
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                decimal subtotal = 0;
                decimal discount = 0;

                // Create Order Object
                var order = new Order
                {
                    OrderCode = GenerateOrderCode(),
                    CustomerName = customerName.Trim(),
                    Address = address.Trim(),
                    Phone = phone.Trim(),
                    Note = note?.Trim(),
                    Status = OrderStatus.Pending,
                    PaymentMethod = PaymentMethod.Cash,
                    PaymentStatus = PaymentStatus.Unpaid,
                    StoreId = store.Id,
                    CreatedAt = DateTime.Now
                };

                // Add User ID if logged in
                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name!);
                    order.UserId = user?.Id;
                }

                _db.Orders.Add(order);
                await _db.SaveChangesAsync(); // Get Order ID

                // 4. Process Line Items and Stock
                foreach (var item in cart)
                {
                    decimal unitPrice = 0;
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        Quantity = item.Quantity,
                        CreatedAt = DateTime.Now
                    };

                    if (item.ProductSkuId.HasValue && item.ProductSkuId.Value > 0)
                    {
                        var sku = skus.FirstOrDefault(s => s.Id == item.ProductSkuId.Value);
                        if (sku == null || sku.Product == null) 
                            throw new Exception($"Sản phẩm biến thể (ID: {item.ProductSkuId}) không tồn tại trong hệ thống. Vui lòng làm mới giỏ hàng.");

                        // Stock Check & Deduction
                        if (sku.Stock < item.Quantity)
                            throw new Exception($"Sản phẩm {sku.Product.Name} ({sku.Size}/{sku.Color}) không đủ hàng trong kho.");

                        sku.Stock -= item.Quantity;
                        sku.Product.Stock -= item.Quantity; // Keep aggregate stock in sync

                        unitPrice = sku.PriceOverride > 0 ? sku.PriceOverride.Value : sku.Product.Price;
                        orderDetail.ProductSkuId = sku.Id;
                        orderDetail.ProductId = sku.ProductId;
                    }
                    else
                    {
                        var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                        if (product == null) 
                            throw new Exception($"Sản phẩm (ID: {item.ProductId}) không tồn tại trong hệ thống. Vui lòng làm mới giỏ hàng.");

                        if (product.Stock < item.Quantity)
                            throw new Exception($"Sản phẩm {product.Name} không đủ hàng trong kho.");

                        product.Stock -= item.Quantity;
                        unitPrice = product.Price;
                        orderDetail.ProductId = product.Id;
                        orderDetail.ProductSkuId = null; // Explicitly set to null for simple products
                    }

                    orderDetail.UnitPrice = unitPrice;
                    orderDetail.Subtotal = unitPrice * item.Quantity;
                    
                    subtotal += orderDetail.Subtotal;
                    _db.OrderDetails.Add(orderDetail);
                }

                // 5. Handle Voucher
                if (!string.IsNullOrEmpty(voucherCode))
                {
                    var voucher = await _db.Vouchers
                        .FirstOrDefaultAsync(v => v.Code == voucherCode && v.IsActive && v.ExpiryDate >= DateTime.Now);

                    if (voucher != null && subtotal >= voucher.MinOrderAmount)
                    {
                        discount = voucher.DiscountAmount;
                        order.VoucherId = voucher.Id;
                    }
                }

                // 6. Finalize Totals
                order.SubTotal = subtotal;
                order.DiscountAmount = discount;
                order.TotalAmount = Math.Max(0, subtotal - discount);

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                // 7. Success - Clear Cookie and Redirect
                Response.Cookies.Delete(CART_COOKIE_NAME);
                return View("OrderSuccess", order);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                
                string detailedError = ex.Message;
                if (ex.InnerException != null)
                {
                    detailedError += " | Inner: " + ex.InnerException.Message;
                }

                Console.WriteLine($"[ORDER_ERROR] {detailedError}");
                TempData["Error"] = "Lỗi hệ thống: " + detailedError;
                return RedirectToAction("Index");
            }
        }

        private async Task<List<CartItemViewModel>> GetCartItemsHydratedAsync()
        {
            var cookie = Request.Cookies[CART_COOKIE_NAME];
            if (string.IsNullOrEmpty(cookie)) return new List<CartItemViewModel>();
            try
            {
                var cartItems = JsonSerializer.Deserialize<List<CartItemViewModel>>(cookie) ?? new List<CartItemViewModel>();
                if (!cartItems.Any()) return cartItems;

                var productIds = cartItems.Select(i => i.ProductId).Distinct().ToList();
                var skuIds = cartItems.Where(i => i.ProductSkuId.HasValue).Select(i => i.ProductSkuId!.Value).Distinct().ToList();

                var products = await _db.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
                var skus = await _db.ProductSkus.Where(s => skuIds.Contains(s.Id)).ToListAsync();

                foreach (var item in cartItems)
                {
                    var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                    if (product == null) continue;

                    item.Name = product.Name;
                    item.ImageUrl = product.ImageUrl ?? "";

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

                return cartItems;
            }
            catch
            {
                return new List<CartItemViewModel>();
            }
        }
    }
}
