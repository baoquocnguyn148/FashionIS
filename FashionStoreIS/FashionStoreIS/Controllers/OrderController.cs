using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FashionStoreIS.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private const string CART_COOKIE_NAME = "BNStore_Cart";

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var cart = await GetCartItemsAsync();
            if (!cart.Any())
            {
                TempData["Error"] = "Giỏ hàng của bạn đang trống.";
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.Cart = cart;
            ViewBag.TotalAmount = cart.Sum(i => i.TotalPrice);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(string customerName, string phone, string address, string paymentMethod, string? note)
        {
            var cart = await GetCartItemsAsync();
            if (!cart.Any())
            {
                TempData["Error"] = "Giỏ hàng của bạn đang trống.";
                return RedirectToAction("Index", "Cart");
            }

            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                // 1. Re-validate and re-calculate from DB
                decimal subtotal = 0;
                var orderDetails = new List<OrderDetail>();
                
                // Get all relevant data once
                var productIds = cart.Select(i => i.ProductId).Distinct().ToList();
                var skuIds = cart.Where(i => i.ProductSkuId.HasValue).Select(i => i.ProductSkuId!.Value).Distinct().ToList();

                var products = await _db.Products.Include(p => p.Skus).Where(p => productIds.Contains(p.Id)).ToListAsync();
                
                foreach (var item in cart)
                {
                    var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                    if (product == null || !product.IsActive) 
                        throw new Exception($"Sản phẩm {item.Name} không còn khả dụng.");

                    decimal unitPrice = product.Price;
                    int availableStock = product.Stock;

                    if (item.ProductSkuId.HasValue)
                    {
                        var sku = product.Skus.FirstOrDefault(s => s.Id == item.ProductSkuId.Value);
                        if (sku == null) throw new Exception($"Biến thể sản phẩm {item.Name} không tồn tại.");
                        unitPrice = sku.SellingPrice;
                        availableStock = sku.Stock;

                        if (item.Quantity > availableStock)
                            throw new Exception($"Sản phẩm {item.Name} ({item.Size}/{item.Color}) hết hàng.");

                        // Deduct SKU stock
                        sku.Stock -= item.Quantity;
                    }
                    else
                    {
                        if (item.Quantity > availableStock)
                            throw new Exception($"Sản phẩm {item.Name} hết hàng.");

                        // Deduct Product stock
                        product.Stock -= item.Quantity;
                    }

                    var detail = new OrderDetail
                    {
                        ProductId = item.ProductId,
                        ProductSkuId = item.ProductSkuId ?? 0,
                        Quantity = item.Quantity,
                        UnitPrice = unitPrice,
                        Subtotal = unitPrice * item.Quantity,
                        CreatedAt = DateTime.Now
                    };
                    
                    orderDetails.Add(detail);
                    subtotal += detail.Subtotal;
                }

                // 2. Create Order
                var store = await _db.Stores.FirstOrDefaultAsync() ?? throw new Exception("Không tìm thấy thông tin cửa hàng.");
                
                var order = new Order
                {
                    OrderCode = GenerateOrderCode(),
                    Status = OrderStatus.Pending,
                    PaymentMethod = Enum.Parse<PaymentMethod>(paymentMethod),
                    PaymentStatus = PaymentStatus.Unpaid,
                    SubTotal = subtotal,
                    TotalAmount = subtotal, // Assuming no tax/shipping for now
                    PointsEarned = (int)(subtotal / 100000),
                    CustomerName = customerName,
                    Phone = phone,
                    Address = address,
                    Note = note,
                    StoreId = store.Id,
                    CreatedAt = DateTime.Now
                };

                _db.Orders.Add(order);
                await _db.SaveChangesAsync(); // Get Order ID

                foreach (var detail in orderDetails)
                {
                    detail.OrderId = order.Id;
                    _db.OrderDetails.Add(detail);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                // 3. Clear Cart
                Response.Cookies.Delete(CART_COOKIE_NAME);

                return View("OrderSuccess", order);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["Error"] = "Lỗi đặt hàng: " + ex.Message;
                return RedirectToAction("Checkout");
            }
        }

        private string GenerateOrderCode()
        {
            var dateStr = DateTime.Now.ToString("yyyyMMdd");
            var randomStr = Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
            return $"ORD-{dateStr}-{randomStr}";
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
    }
}
