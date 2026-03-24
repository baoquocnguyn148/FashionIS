using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Domain.Enums;
using System.Text.RegularExpressions;

namespace StyleVibe.Application.Services;

public class PosService(IAppDbContext context) : IPosService
{
    private const int MaxRetries = 3;

    public async Task<Order> CreateOrderAsync(
        int storeId,
        int? customerId,
        IEnumerable<(int productSkuId, int quantity, decimal discountPercent)> items,
        byte paymentMethod,
        string? note = null,
        string? customerName = null,
        string? phone = null,
        string? address = null,
        string? voucherCode = null,
        CancellationToken cancellationToken = default)
    {
        var itemList = items.ToList();
        if (itemList.Count == 0)
        {
            throw new InvalidOperationException("Order must contain at least one item.");
        }

        if (!string.IsNullOrEmpty(phone) && !Regex.IsMatch(phone, @"^0\d{9}$"))
        {
            throw new ArgumentException("Số điện thoại không hợp lệ. Phải bắt đầu bằng 0 và có 10 chữ số.");
        }

        int retryCount = 0;
        
        while (true)
        {
            try
            {
                var skuIds = itemList.Select(i => i.productSkuId).Distinct().ToList();

                var skus = await context.ProductSkus
                    .Include(s => s.Product)
                    .Where(s => skuIds.Contains(s.Id))
                    .ToListAsync(cancellationToken);

                if (skus.Count != skuIds.Count)
                {
                    throw new InvalidOperationException("One or more SKUs not found.");
                }

                var inventories = await context.Inventories
                    .Where(i => i.StoreId == storeId && skuIds.Contains(i.ProductSkuId))
                    .ToListAsync(cancellationToken);

                var now = DateTime.UtcNow;

                decimal subTotal = 0m;
                var orderDetails = new List<OrderDetail>();

                foreach (var item in itemList)
                {
                    var sku = skus.Single(s => s.Id == item.productSkuId);
                    var inventory = inventories.SingleOrDefault(i => i.ProductSkuId == item.productSkuId);

                    if (inventory == null || inventory.QuantityOnHand < item.quantity)
                    {
                        throw new InvalidOperationException($"Not enough stock for SKU {sku.SkuCode}.");
                    }

                    var lineUnitPrice = sku.SellingPrice;
                    var discountFactor = 1 - (item.discountPercent / 100m);
                    var lineSubtotal = lineUnitPrice * item.quantity * discountFactor;

                    subTotal += lineSubtotal;

                    inventory.QuantityOnHand -= item.quantity;
                    inventory.LastUpdated = now;
                    
                    // Deduct from Product aggregate stock 
                    sku.Product.Stock -= item.quantity;
                    if (sku.Product.Stock < 0) sku.Product.Stock = 0;

                    var adjustment = new StockAdjustment
                    {
                        QuantityBefore = inventory.QuantityOnHand + item.quantity,
                        QuantityChange = -item.quantity,
                        QuantityAfter = inventory.QuantityOnHand,
                        Reason = StockAdjustmentReason.Manual,
                        InventoryId = inventory.Id,
                        CreatedAt = now
                    };

                    context.StockAdjustments.Add(adjustment);

                    var detail = new OrderDetail
                    {
                        ProductSkuId = item.productSkuId,
                        Quantity = item.quantity,
                        UnitPrice = lineUnitPrice,
                        DiscountPercent = item.discountPercent,
                        Subtotal = lineSubtotal,
                        CreatedAt = now
                    };
                    orderDetails.Add(detail);
                }

                // Handle Voucher
                decimal discountAmount = 0m;
                Voucher? appliedVoucher = null;

                if (!string.IsNullOrWhiteSpace(voucherCode))
                {
                    appliedVoucher = await context.Vouchers
                        .FirstOrDefaultAsync(v => v.Code == voucherCode && v.IsActive && 
                            (!v.ExpiryDate.HasValue || v.ExpiryDate >= now), cancellationToken);

                    if (appliedVoucher == null)
                    {
                        throw new InvalidOperationException("Mã giảm giá không tồn tại, chưa kích hoạt hoặc đã hết hạn.");
                    }
                    
                    if (appliedVoucher.UsedCount >= appliedVoucher.MaxUsageCount)
                    {
                        throw new InvalidOperationException("Mã giảm giá đã hết lượt sử dụng.");
                    }

                    if (appliedVoucher.MinOrderAmount.HasValue && subTotal < appliedVoucher.MinOrderAmount.Value)
                    {
                        throw new InvalidOperationException($"Đơn hàng phải từ {appliedVoucher.MinOrderAmount.Value:N0} ₫ để dùng mã này.");
                    }

                    discountAmount = appliedVoucher.DiscountAmount;
                    appliedVoucher.UsedCount += 1;
                }

                var order = new Order
                {
                    OrderCode = GenerateOrderCode(now),
                    OrderDate = now,
                    StoreId = storeId,
                    CustomerId = customerId,
                    CustomerName = customerName,
                    Phone = phone,
                    Address = address,
                    SubTotal = subTotal,
                    DiscountAmount = discountAmount,
                    TotalAmount = Math.Max(0, subTotal - discountAmount),
                    PaymentMethod = (PaymentMethod)paymentMethod,
                    PaymentStatus = PaymentStatus.Paid,
                    Status = OrderStatus.Completed,
                    Note = note,
                    PointsEarned = customerId.HasValue ? (int)(Math.Max(0, subTotal - discountAmount) / 100_000m) * 10 : 0,
                    CreatedAt = now,
                    OrderDetails = orderDetails
                };

                context.Orders.Add(order);

                if (customerId.HasValue && order.PointsEarned > 0)
                {
                    var customer = await context.Customers
                        .FirstOrDefaultAsync(c => c.Id == customerId.Value, cancellationToken);

                    if (customer != null)
                    {
                        customer.LoyaltyPoints += order.PointsEarned;

                        context.LoyaltyTransactions.Add(new LoyaltyTransaction
                        {
                            CustomerId = customer.Id,
                            Order = order,
                            Points = order.PointsEarned,
                            Description = $"Tích điểm đơn {order.OrderCode}",
                            CreatedAt = now
                        });
                    }
                }

                await context.SaveChangesAsync(cancellationToken);
                return order;
            }
            catch (DbUpdateConcurrencyException)
            {
                retryCount++;
                if (retryCount >= MaxRetries)
                {
                    throw new InvalidOperationException("Hệ thống đang bận do quá nhiều giao dịch đồng thời. Vui lòng thử lại sau.");
                }
                
                // Clear tracker and retry
                foreach (var entry in context.ChangeTracker.Entries())
                {
                    entry.State = EntityState.Detached;
                }
                
                // Small delay to prevent tight loop collisions
                await Task.Delay(100, cancellationToken);
            }
        }
    }

    private static string GenerateOrderCode(DateTime now)
        => $"ORD-{now:yyyyMMddHHmmss}";
}
