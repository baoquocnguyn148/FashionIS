// FILE: d:\FashionStoreIS\FashionStoreIS\FashionStoreIS\Controllers\CheckoutController.cs
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
            // Max length is 20 chars (BN + 12 chars timestamp + 6 chars random)
            var ts = DateTime.UtcNow.ToString("yyMMddHHmmss");
            var rnd = Random.Shared.Next(100000, 999999);
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

            var cart = await GetCartItemsHydratedAsync();
            if (cart.Count == 0) return Json(new { success = false, message = "Giỏ hàng trống." });
            var subtotal = cart.Sum(i => i.Quantity * i.Price);

            var voucher = await _db.Vouchers
                .FirstOrDefaultAsync(v => v.Code == code && v.IsActive && v.ExpiryDate >= DateTime.Now);
            
            if (voucher == null) return Json(new { success = false, message = "Mã giảm giá không tồn tại hoặc đã hết hạn." });
            if (subtotal < voucher.MinOrderAmount) 
                return Json(new { success = false, message = $"Đơn hàng tối thiểu {voucher.MinOrderAmount:N0} VND để sử dụng mã này." });
            
            // Check usage limit
            if (voucher.UsedCount >= voucher.MaxUsageCount)
                return Json(new { success = false, message = "Mã giảm giá này đã hết lượt sử dụng." });

            return Json(new { success = true, discount = voucher.DiscountAmount, code = voucher.Code });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessOrder(
            string customerName, string address, string phone, 
            string? voucherCode, string? note)
        {
            // BƯỚC 1: Validate input
            if (string.IsNullOrWhiteSpace(customerName) || 
                string.IsNullOrWhiteSpace(phone) || 
                string.IsNullOrWhiteSpace(address))
            {
                TempData["Error"] = "Vui lòng điền đầy đủ thông tin giao hàng.";
                return RedirectToAction("Index");
            }

            // BƯỚC 2: Lấy cart
            var cart = await GetCartItemsHydratedAsync();
            if (cart.Count == 0)
            {
                TempData["Error"] = "Giỏ hàng trống.";
                return RedirectToAction("Index", "Home");
            }

            // BƯỚC 3: Lấy store
            var store = await _db.Stores
                .Where(s => s.IsActive)
                .OrderBy(s => s.Id)
                .FirstOrDefaultAsync();
            if (store == null)
            {
                TempData["Error"] = "Hệ thống đang bảo trì. Vui lòng thử lại.";
                return RedirectToAction("Index");
            }

            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                // BƯỚC 4: Tạo Order với tất cả field có giá trị mặc định
                var order = new Order
                {
                    OrderCode      = GenerateOrderCode(),
                    CustomerName   = customerName.Trim(),
                    Phone          = phone.Trim(),
                    Address        = address.Trim(),
                    Note           = string.IsNullOrWhiteSpace(note) ? null : note.Trim(),
                    Status         = OrderStatus.Pending,
                    PaymentMethod  = PaymentMethod.Cash,
                    PaymentStatus  = PaymentStatus.Unpaid,
                    SubTotal       = 0,
                    DiscountAmount = 0,
                    TotalAmount    = 0,
                    PointsEarned   = 0,
                    StoreId        = store.Id,
                    CreatedAt      = DateTime.Now,
                    IsDeleted      = false,
                    UserId         = null,
                    CustomerId     = null,
                    VoucherId      = null
                };

                // Set UserId nếu đã login
                if (User.Identity?.IsAuthenticated == true)
                {
                    var currentUser = await _userManager.GetUserAsync(User);
                    order.UserId = currentUser?.Id;
                }

                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                // BƯỚC 5: Load products và skus từ DB
                var productIds = cart.Select(i => i.ProductId).Distinct().ToList();
                var skuIds = cart
                    .Where(i => i.ProductSkuId.HasValue && i.ProductSkuId.Value > 0)
                    .Select(i => i.ProductSkuId!.Value)
                    .Distinct()
                    .ToList();

                var products = await _db.Products
                    .Include(p => p.Skus)
                    .Where(p => productIds.Contains(p.Id))
                    .ToListAsync();

                var skus = skuIds.Any()
                    ? await _db.ProductSkus
                        .Include(s => s.Product)
                        .Where(s => skuIds.Contains(s.Id))
                        .ToListAsync()
                    : new List<ProductSku>();

                decimal subtotal = 0;

                // BƯỚC 6: Tạo OrderDetail cho từng item
                foreach (var item in cart)
                {
                    var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                    if (product == null || !product.IsActive)
                        throw new Exception($"Sản phẩm không còn khả dụng. Vui lòng làm mới giỏ hàng.");

                    decimal unitPrice;
                    var orderDetail = new OrderDetail
                    {
                        OrderId         = order.Id,
                        Quantity        = item.Quantity,
                        DiscountPercent = 0,
                        CreatedAt       = DateTime.Now,
                        IsDeleted       = false
                    };

                    if (item.ProductSkuId.HasValue && item.ProductSkuId.Value > 0)
                    {
                        // Sản phẩm CÓ SKU
                        var sku = skus.FirstOrDefault(s => s.Id == item.ProductSkuId.Value);
                        if (sku == null)
                            throw new Exception($"Biến thể sản phẩm không tồn tại. Vui lòng làm mới giỏ hàng.");

                        if (sku.Stock < item.Quantity)
                            throw new Exception($"'{product.Name}' ({sku.Size}/{sku.Color}) chỉ còn {sku.Stock} sản phẩm.");

                        // Trừ stock SKU
                        sku.Stock -= item.Quantity;
                        // Sync Product.Stock = tổng tất cả SKU còn lại
                        product.Stock = product.Skus.Sum(s => s.Stock);

                        unitPrice = (sku.PriceOverride.HasValue && sku.PriceOverride.Value > 0)
                            ? sku.PriceOverride.Value
                            : sku.SellingPrice;

                        orderDetail.ProductSkuId = sku.Id;
                        orderDetail.ProductId    = product.Id;
                    }
                    else
                    {
                        // Sản phẩm KHÔNG CÓ SKU
                        if (product.Stock < item.Quantity)
                            throw new Exception($"'{product.Name}' không đủ hàng trong kho.");

                        product.Stock -= item.Quantity;
                        unitPrice = product.Price;

                        // ProductSkuId = null (đã nullable)
                        orderDetail.ProductSkuId = null;
                        orderDetail.ProductId    = product.Id;
                    }

                    orderDetail.UnitPrice = unitPrice;
                    orderDetail.Subtotal  = unitPrice * item.Quantity;
                    subtotal += orderDetail.Subtotal;

                    _db.OrderDetails.Add(orderDetail);
                }

                // BƯỚC 7: Xử lý voucher
                decimal discount = 0;
                if (!string.IsNullOrWhiteSpace(voucherCode))
                {
                    var voucher = await _db.Vouchers
                        .FirstOrDefaultAsync(v =>
                            v.Code == voucherCode &&
                            v.IsActive &&
                            v.ExpiryDate >= DateTime.Now);

                    if (voucher != null && subtotal >= voucher.MinOrderAmount)
                    {
                        discount        = voucher.DiscountAmount;
                        order.VoucherId = voucher.Id;
                        voucher.UsedCount++;
                    }
                }

                // BƯỚC 8: Cập nhật tổng tiền
                order.SubTotal       = subtotal;
                order.DiscountAmount = discount;
                order.TotalAmount    = Math.Max(0, subtotal - discount);
                order.PointsEarned   = (int)(order.TotalAmount / 100000);

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                // Xóa cookie giỏ hàng
                Response.Cookies.Delete(CART_COOKIE_NAME);

                return View("OrderSuccess", order);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                var errorMsg = ex.Message;
                if (ex.InnerException != null)
                    errorMsg += " | Inner: " + ex.InnerException.Message;

                Console.WriteLine($"[CHECKOUT_ERROR] {errorMsg}");
                TempData["Error"] = "Lỗi hệ thống: " + errorMsg;
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
