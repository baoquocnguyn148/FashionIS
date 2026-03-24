using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Application.Services;

public class PurchaseOrderService(IAppDbContext context) : IPurchaseOrderService
{
    public async Task<PurchaseOrder> CreatePurchaseOrderAsync(
        int supplierId,
        IEnumerable<(int skuId, int quantity, decimal unitCost)> items,
        string? note = null,
        CancellationToken cancellationToken = default)
    {
        var itemList = items.ToList();
        if (itemList.Count == 0)
        {
            throw new InvalidOperationException("Phiếu nhập phải có ít nhất 1 sản phẩm.");
        }

        var supplier = await context.Suppliers.FindAsync(new object[] { supplierId }, cancellationToken);
        if (supplier == null)
            throw new InvalidOperationException("Nhà cung cấp không tồn tại.");

        var skuIds = itemList.Select(i => i.skuId).Distinct().ToList();
        var skus = await context.ProductSkus
            .Include(s => s.Product)
            .Where(s => skuIds.Contains(s.Id))
            .ToListAsync(cancellationToken);

        if (skus.Count != skuIds.Count)
        {
            throw new InvalidOperationException("Một hoặc nhiều biến thể (SKU) không tồn tại.");
        }

        var store = await context.Stores.FirstOrDefaultAsync(s => s.IsActive, cancellationToken);
        if (store == null)
            throw new InvalidOperationException("Không tìm thấy cửa hàng hoạt động để nhập hàng.");

        var inventories = await context.Inventories
            .Where(i => i.StoreId == store.Id && skuIds.Contains(i.ProductSkuId))
            .ToListAsync(cancellationToken);

        var now = DateTime.UtcNow;
        decimal totalCost = 0m;
        var details = new List<PurchaseOrderDetail>();

        foreach (var item in itemList)
        {
            var sku = skus.Single(s => s.Id == item.skuId);
            var inventory = inventories.SingleOrDefault(i => i.ProductSkuId == item.skuId);

            if (inventory == null)
            {
                inventory = new Inventory
                {
                    StoreId = store.Id,
                    ProductSkuId = sku.Id,
                    QuantityOnHand = 0,
                    ReorderPoint = 10,
                    MaxStockLevel = 200,
                    LastUpdated = now,
                    CreatedAt = now
                };
                context.Inventories.Add(inventory);
                inventories.Add(inventory); // So we can use it below
            }

            var lineSubtotal = item.quantity * item.unitCost;
            totalCost += lineSubtotal;

            inventory.QuantityOnHand += item.quantity;
            inventory.LastUpdated = now;

            // Update product aggregate stock
            sku.Product.Stock += item.quantity;
            
            // Update SKU cost price based on latest import
            sku.CostPrice = item.unitCost;

            var adjustment = new StockAdjustment
            {
                QuantityBefore = inventory.QuantityOnHand - item.quantity,
                QuantityChange = item.quantity,
                QuantityAfter = inventory.QuantityOnHand,
                Reason = StockAdjustmentReason.PurchaseOrder,
                Inventory = inventory,
                CreatedAt = now
            };
            context.StockAdjustments.Add(adjustment);

            var detail = new PurchaseOrderDetail
            {
                ProductSkuId = item.skuId,
                QuantityOrdered = item.quantity,
                QuantityReceived = item.quantity,
                UnitCost = item.unitCost,
                Subtotal = lineSubtotal,
                CreatedAt = now
            };
            details.Add(detail);
        }

        var po = new PurchaseOrder
        {
            PoCode = $"PO-{now:yyyyMMddHHmmss}",
            OrderDate = now,
            SupplierId = supplierId,
            TotalCost = totalCost,
            Note = note,
            CreatedAt = now,
            PurchaseOrderDetails = details
        };

        context.PurchaseOrders.Add(po);
        await context.SaveChangesAsync(cancellationToken);

        return po;
    }

    public async Task<List<PurchaseOrder>> GetAllPurchaseOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await context.PurchaseOrders
            .Include(po => po.Supplier)
            .OrderByDescending(po => po.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.PurchaseOrders
            .Include(po => po.Supplier)
            .Include(po => po.PurchaseOrderDetails)
                .ThenInclude(d => d.ProductSku)
                    .ThenInclude(sku => sku!.Product)
            .FirstOrDefaultAsync(po => po.Id == id, cancellationToken);
    }
}
