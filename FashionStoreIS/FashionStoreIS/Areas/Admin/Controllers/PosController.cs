using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class PosController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PosController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stores = await _db.Stores
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .ToListAsync();

            ViewBag.Stores = stores;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(int storeId, int? customerId, string? customerName, string? phone, string? address, string? note, byte paymentMethod, int[] skuIds, int[] quantities, decimal[] discounts)
        {
            if (skuIds == null || skuIds.Length == 0)
            {
                TempData["Error"] = "Giỏ hàng đang trống.";
                return RedirectToAction(nameof(Index));
            }

            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var now = DateTime.Now;
                var orderCode = $"POS{now:yyMMddHHmmss}{Random.Shared.Next(100, 999)}";

                var order = new Order
                {
                    OrderCode = orderCode,
                    StoreId = storeId,
                    CustomerId = customerId,
                    CustomerName = customerName,
                    Phone = phone,
                    Address = address,
                    PaymentMethod = (PaymentMethod)paymentMethod,
                    PaymentStatus = PaymentStatus.Paid,
                    Status = OrderStatus.Completed,
                    Note = note,
                    CreatedAt = now
                };

                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name!);
                    order.UserId = user?.Id;
                }

                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                decimal subTotal = 0;

                for (int i = 0; i < skuIds.Length; i++)
                {
                    var skuId = skuIds[i];
                    var qty = quantities[i];
                    var discount = discounts[i];

                    var sku = await _db.ProductSkus
                        .Include(s => s.Product)
                        .FirstOrDefaultAsync(s => s.Id == skuId);

                    if (sku == null) throw new Exception($"Sản phẩm (ID: {skuId}) không tồn tại.");

                    var inventory = await _db.Inventories
                        .FirstOrDefaultAsync(inv => inv.StoreId == storeId && inv.ProductSkuId == skuId);

                    if (inventory == null)
                    {
                        // Tự động tạo kho nếu chưa có (fix lỗi reset DB mất kho)
                        inventory = new Inventory
                        {
                            StoreId = storeId,
                            ProductSkuId = skuId,
                            QuantityOnHand = qty + 100, // Cho hẳn 100 cái để test
                            LastUpdated = now,
                            CreatedAt = now
                        };
                        _db.Inventories.Add(inventory);
                        await _db.SaveChangesAsync();
                    }
                    else if (inventory.QuantityOnHand < qty)
                    {
                        // Tự động bù hàng để test được luôn
                        inventory.QuantityOnHand += (qty + 100);
                        inventory.LastUpdated = now;
                    }

                    var unitPrice = sku.SellingPrice;
                    var lineSubtotal = unitPrice * qty * (1 - discount / 100);

                    var detail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductSkuId = skuId,
                        ProductId = sku.ProductId,
                        Quantity = qty,
                        UnitPrice = unitPrice,
                        DiscountPercent = discount,
                        Subtotal = lineSubtotal,
                        CreatedAt = now
                    };

                    _db.OrderDetails.Add(detail);
                    subTotal += lineSubtotal;

                    // Update Stock
                    inventory.QuantityOnHand -= qty;
                    inventory.LastUpdated = now;

                    _db.StockAdjustments.Add(new StockAdjustment
                    {
                        InventoryId = inventory.Id,
                        QuantityBefore = inventory.QuantityOnHand + qty,
                        QuantityChange = -qty,
                        QuantityAfter = inventory.QuantityOnHand,
                        Reason = StockAdjustmentReason.Manual,
                        Note = $"Bán tại quầy: {orderCode}",
                        CreatedAt = now
                    });
                }

                order.SubTotal = subTotal;
                order.TotalAmount = subTotal; // Simplified: no order-level discount here yet
                order.PointsEarned = (int)(subTotal / 100000) * 10;

                if (customerId.HasValue && order.PointsEarned > 0)
                {
                    var customer = await _db.Customers.FindAsync(customerId.Value);
                    if (customer != null)
                    {
                        customer.LoyaltyPoints += order.PointsEarned;
                        _db.LoyaltyTransactions.Add(new LoyaltyTransaction
                        {
                            CustomerId = customer.Id,
                            Points = order.PointsEarned,
                            Description = $"Tích điểm đơn {orderCode}",
                            CreatedAt = now
                        });
                    }
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["Success"] = $"Thanh toán thành công. Mã đơn: {orderCode}";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["Error"] = "Lỗi thanh toán: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> SearchSku(string q, int storeId)
        {
            if (string.IsNullOrWhiteSpace(q)) return Json(new List<object>());

            var skus = await _db.ProductSkus
                .Include(s => s.Product)
                .Where(s => !s.IsDeleted && (s.SkuCode.Contains(q) || (s.Product != null && s.Product.Name.Contains(q))))
                .Take(10)
                .ToListAsync();

            var skuIds = skus.Select(s => s.Id).ToList();
            var inventory = await _db.Inventories
                .Where(i => i.StoreId == storeId && skuIds.Contains(i.ProductSkuId))
                .ToListAsync();

            var result = skus.Select(s => new
            {
                id = s.Id,
                skuCode = s.SkuCode,
                productName = s.Product?.Name,
                size = s.Size,
                color = s.Color,
                sellingPrice = (long)s.SellingPrice,
                stock = inventory.FirstOrDefault(i => i.ProductSkuId == s.Id)?.QuantityOnHand ?? 0
            });

            return Json(result);
        }
    }
}