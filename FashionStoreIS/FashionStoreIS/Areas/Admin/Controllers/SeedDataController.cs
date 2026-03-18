using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class SeedDataController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SeedDataController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeedSampleData()
        {
            try
            {
                // Get existing products - Safe pattern for Oracle 11g
                var products = (await _db.Products.ToListAsync()).Take(5).ToList();
                
                if (!products.Any())
                {
                    TempData["Error"] = "Không có sản phẩm nào trong database. Vui lòng thêm sản phẩm trước.";
                    return RedirectToAction(nameof(Index));
                }

                // Create sample orders
                var random = new Random();
                var statuses = new[] { OrderStatus.Pending, OrderStatus.Processing, OrderStatus.Shipped, OrderStatus.Completed };
                var customerNames = new[] { "NguyềE Văn A", "Trần ThềEB", "Lê Văn C", "Phạm ThềED", "Hoàng Văn E" };
                var phones = new[] { "0912345678", "0923456789", "0934567890", "0945678901", "0956789012" };
                var addresses = new[] { "Hà Nội", "TPHCM", "Đà Nẵng", "Hải Phòng", "Cần Thơ" };

                for (int i = 0; i < 20; i++)
                {
                    var order = new Order
                    {
                        CustomerName = customerNames[random.Next(customerNames.Length)],
                        Phone = phones[random.Next(phones.Length)],
                        Address = addresses[random.Next(addresses.Length)],
                        Status = statuses[random.Next(statuses.Length)],
                        CreatedAt = DateTime.Now.AddDays(-random.Next(1, 90)), // Random date within last 90 days
                        TotalAmount = 0
                    };

                    // Add order details
                    var orderDetails = new List<OrderDetail>();
                    var numItems = random.Next(1, 4); // 1-3 items per order
                    
                    for (int j = 0; j < numItems; j++)
                    {
                        var product = products[random.Next(products.Count)];
                        
                        var sku = (await _db.ProductSkus.Where(s => s.ProductId == product.Id).ToListAsync()).FirstOrDefault();
                        if (sku == null) continue;

                        var orderDetail = new OrderDetail
                        {
                            ProductSkuId = sku.Id,
                            Quantity = random.Next(1, 5),
                            UnitPrice = product.Price,
                            Subtotal = random.Next(1, 5) * product.Price,
                            DiscountPercent = 0
                        };
                        
                        orderDetails.Add(orderDetail);
                        order.TotalAmount += orderDetail.Subtotal;
                    }

                    order.OrderDetails = orderDetails;
                    _db.Orders.Add(order);
                }

                await _db.SaveChangesAsync();
                
                TempData["Success"] = $"Đã tạo thành công 20 đơn hàng mẫu với {await _db.OrderDetails.CountAsync()} sản phẩm.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi tạo dữ liệu mẫu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
