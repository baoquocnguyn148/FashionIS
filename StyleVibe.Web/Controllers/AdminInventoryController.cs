using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Domain.Enums;
using StyleVibe.Web.ViewModels.Admin;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminInventoryController : Controller
{
    private readonly IAppDbContext _context;

    public AdminInventoryController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(InventoryFilterViewModel filter, CancellationToken cancellationToken = default)
    {
        const int pageSize = 20;
        filter.Page = Math.Max(1, filter.Page);

        var query = _context.Inventories
            .Include(i => i.ProductSku)
                .ThenInclude(sku => sku.Product)
            .Include(i => i.Store)
            .Where(i => !i.IsDeleted);

        if (filter.StoreId.HasValue && filter.StoreId.Value > 0)
        {
            query = query.Where(i => i.StoreId == filter.StoreId.Value);
        }

        if (filter.LowStock)
        {
            query = query.Where(i => i.QuantityOnHand <= i.ReorderPoint);
        }

        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .OrderBy(i => i.Store.Name)
            .ThenBy(i => i.ProductSku.SkuCode)
            .Skip((filter.Page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Filter = filter;
        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);

        return View(items);
    }

    [HttpGet]
    public async Task<IActionResult> Adjust(int id, CancellationToken cancellationToken = default)
    {
        var inventory = await _context.Inventories
            .Include(i => i.ProductSku)
                .ThenInclude(sku => sku.Product)
            .Include(i => i.Store)
            .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted, cancellationToken);

        if (inventory == null) return NotFound();

        var model = new StockAdjustViewModel
        {
            InventoryId = inventory.Id,
            ProductSkuId = inventory.ProductSkuId,
            StoreId = inventory.StoreId,
            QuantityOnHand = inventory.QuantityOnHand,
            SkuCode = inventory.ProductSku.SkuCode,
            ProductName = inventory.ProductSku.Product.Name,
            StoreName = inventory.Store.Name,
            Reason = StockAdjustmentReason.Manual
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adjust(StockAdjustViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return View(model);

        var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == model.InventoryId && !i.IsDeleted, cancellationToken);
        if (inventory == null) return NotFound();

        int quantityBefore = inventory.QuantityOnHand;
        int quantityAfter = quantityBefore + model.QuantityChange;

        if (quantityAfter < 0)
        {
            ModelState.AddModelError("QuantityChange", "Số lượng sau khi điều chỉnh không được âm.");
            return View(model);
        }

        using var transaction = await _context.SaveChangesAsync(cancellationToken) > 0 ? null : null; // EF Core SaveChanges is atomic

        var adjustment = new StockAdjustment
        {
            InventoryId = inventory.Id,
            QuantityBefore = quantityBefore,
            QuantityChange = model.QuantityChange,
            QuantityAfter = quantityAfter,
            Reason = model.Reason,
            Note = model.Note,
            CreatedAt = DateTime.UtcNow
            // AdjustedByUserId should be set here if we have user context
        };

        inventory.QuantityOnHand = quantityAfter;
        inventory.LastUpdated = DateTime.UtcNow;

        _context.StockAdjustments.Add(adjustment);
        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = "Điều chỉnh tồn kho thành công.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> History(int inventoryId, CancellationToken cancellationToken = default)
    {
        var inventory = await _context.Inventories
            .Include(i => i.ProductSku)
                .ThenInclude(sku => sku.Product)
            .Include(i => i.Store)
            .FirstOrDefaultAsync(i => i.Id == inventoryId && !i.IsDeleted, cancellationToken);

        if (inventory == null) return NotFound();

        var history = await _context.StockAdjustments
            .Where(a => a.InventoryId == inventoryId)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync(cancellationToken);

        ViewBag.Inventory = inventory;
        return View(history);
    }

    public async Task<IActionResult> PurchaseOrders(OrderStatus? status, int? supplierId, CancellationToken cancellationToken = default)
    {
        var query = _context.PurchaseOrders
            .Include(po => po.Supplier)
            .Include(po => po.Store)
            .Where(po => !po.IsDeleted);

        if (status.HasValue) query = query.Where(po => po.Status == status.Value);
        if (supplierId.HasValue) query = query.Where(po => po.SupplierId == supplierId.Value);

        var pos = await query.OrderByDescending(po => po.OrderDate).ToListAsync(cancellationToken);
        
        ViewBag.Suppliers = await _context.Suppliers.Where(s => !s.IsDeleted).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Status = status;
        ViewBag.SupplierId = supplierId;

        return View(pos);
    }

    [HttpGet]
    public async Task<IActionResult> CreatePO(CancellationToken cancellationToken = default)
    {
        ViewBag.Suppliers = await _context.Suppliers.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Skus = await _context.ProductSkus
            .Include(s => s.Product)
            .Where(s => !s.IsDeleted && s.IsActive)
            .OrderBy(s => s.SkuCode)
            .ToListAsync(cancellationToken);

        return View(new PurchaseOrderViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePO(PurchaseOrderViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid || model.Items.Count == 0)
        {
            if (model.Items.Count == 0) TempData["ErrorMessage"] = "Vui lòng chọn ít nhất một sản phẩm.";
            await LoadPoDropdownsAsync(cancellationToken);
            return View(model);
        }

        var poCode = $"PO-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";
        
        var po = new PurchaseOrder
        {
            PoCode = poCode,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            SupplierId = model.SupplierId,
            StoreId = model.StoreId,
            Note = model.Note,
            IsDeleted = false
        };

        decimal totalCost = 0;
        foreach (var item in model.Items)
        {
            var detail = new PurchaseOrderDetail
            {
                ProductSkuId = item.ProductSkuId,
                QuantityOrdered = item.Quantity,
                UnitCost = item.UnitCost,
                Subtotal = item.Quantity * item.UnitCost
            };
            po.PurchaseOrderDetails.Add(detail);
            totalCost += detail.Subtotal;
        }

        po.TotalCost = totalCost;
        _context.PurchaseOrders.Add(po);
        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = $"Tạo đơn nhập hàng {poCode} thành công.";
        return RedirectToAction(nameof(PurchaseOrders));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReceivePO(int id, int[] skuIds, int[] receivedQty, CancellationToken cancellationToken = default)
    {
        var po = await _context.PurchaseOrders
            .Include(p => p.PurchaseOrderDetails)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);

        if (po == null) return NotFound();

        po.Status = OrderStatus.Completed; // Simplified, usually check if all items received
        po.ReceivedDate = DateTime.UtcNow;

        for (int i = 0; i < skuIds.Length; i++)
        {
            int skuId = skuIds[i];
            int qty = receivedQty[i];

            var detail = po.PurchaseOrderDetails.FirstOrDefault(d => d.ProductSkuId == skuId);
            if (detail != null)
            {
                detail.QuantityReceived = qty;

                // Update Inventory
                var inventory = await _context.Inventories.FirstOrDefaultAsync(inv => inv.StoreId == po.StoreId && inv.ProductSkuId == skuId && !inv.IsDeleted, cancellationToken);
                if (inventory == null)
                {
                    inventory = new Inventory
                    {
                        StoreId = po.StoreId,
                        ProductSkuId = skuId,
                        QuantityOnHand = 0,
                        ReorderPoint = 10,
                        LastUpdated = DateTime.UtcNow
                    };
                    _context.Inventories.Add(inventory);
                    await _context.SaveChangesAsync(cancellationToken); // Need ID for adjustment
                }

                var adjustment = new StockAdjustment
                {
                    InventoryId = inventory.Id,
                    QuantityBefore = inventory.QuantityOnHand,
                    QuantityChange = qty,
                    QuantityAfter = inventory.QuantityOnHand + qty,
                    Reason = StockAdjustmentReason.PurchaseOrder,
                    Note = $"Nhập hàng từ PO: {po.PoCode}",
                    CreatedAt = DateTime.UtcNow
                };
                
                inventory.QuantityOnHand += qty;
                inventory.LastUpdated = DateTime.UtcNow;
                _context.StockAdjustments.Add(adjustment);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        TempData["SuccessMessage"] = "Nhận hàng thành công.";
        return RedirectToAction(nameof(PurchaseOrders));
    }

    private async Task LoadPoDropdownsAsync(CancellationToken cancellationToken)
    {
        ViewBag.Suppliers = await _context.Suppliers.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Skus = await _context.ProductSkus
            .Include(s => s.Product)
            .Where(s => !s.IsDeleted && s.IsActive)
            .OrderBy(s => s.SkuCode)
            .ToListAsync(cancellationToken);
    }
}
