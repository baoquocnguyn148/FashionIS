using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Application.Services;

public class PosService(IAppDbContext context) : IPosService
{
    public async Task<Order> CreateOrderAsync(
        int storeId,
        int? customerId,
        IEnumerable<(int productSkuId, int quantity, decimal discountPercent)> items,
        byte paymentMethod,
        string? note,
        CancellationToken cancellationToken = default)
    {
        var itemList = items.ToList();
        if (itemList.Count == 0)
        {
            throw new InvalidOperationException("Order must contain at least one item.");
        }

        var skuIds = itemList.Select(i => i.productSkuId).Distinct().ToList();

        var skus = await context.ProductSkus
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

            var adjustment = new StockAdjustment
            {
                QuantityBefore = inventory.QuantityOnHand + item.quantity,
                QuantityChange = -item.quantity,
                QuantityAfter = inventory.QuantityOnHand,
                Reason = StockAdjustmentReason.PurchaseOrder, // simplified; POS sale
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

        var order = new Order
        {
            OrderCode = GenerateOrderCode(now),
            OrderDate = now,
            StoreId = storeId,
            CustomerId = customerId,
            SubTotal = subTotal,
            DiscountAmount = 0,
            TotalAmount = subTotal,
            PaymentMethod = (PaymentMethod)paymentMethod,
            PaymentStatus = PaymentStatus.Paid,
            Status = OrderStatus.Completed,
            Note = note,
            PointsEarned = customerId.HasValue ? (int)(subTotal / 100_000m) * 10 : 0,
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

    private static string GenerateOrderCode(DateTime now)
        => $"ORD-{now:yyyyMMddHHmmss}";
}

