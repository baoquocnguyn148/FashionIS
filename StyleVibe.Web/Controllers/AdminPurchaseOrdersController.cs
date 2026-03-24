using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Web.ViewModels;
using System.Text.Json;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin,Staff")]
public class AdminPurchaseOrdersController(
    IPurchaseOrderService purchaseOrderService,
    IAppDbContext context) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var pos = await purchaseOrderService.GetAllPurchaseOrdersAsync(cancellationToken);
        return View(pos);
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var po = await purchaseOrderService.GetPurchaseOrderByIdAsync(id, cancellationToken);
        if (po == null) return NotFound();
        return View(po);
    }

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        ViewBag.Suppliers = new SelectList(
            await context.Suppliers.OrderBy(s => s.Name).ToListAsync(cancellationToken), 
            "Id", "Name");
            
        var products = await context.Products
            .Include(p => p.Skus.Where(s => s.IsActive && !s.IsDeleted))
            .Where(p => p.IsActive && !p.IsDeleted)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
            
        ViewBag.ProductsJson = JsonSerializer.Serialize(products.Select(p => new {
            Id = p.Id,
            Name = p.Name,
            Skus = p.Skus.Select(s => new {
                Id = s.Id,
                SkuCode = s.SkuCode,
                Color = s.Color,
                Size = s.Size,
                CostPrice = s.CostPrice
            })
        }));

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int supplierId, string itemsJson, string? note, CancellationToken cancellationToken)
    {
        try
        {
            var itemsReq = JsonSerializer.Deserialize<List<PurchaseOrderItemViewModel>>(itemsJson, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
            if (itemsReq == null || !itemsReq.Any())
            {
                TempData["ErrorMessage"] = "Phiếu nhập phải có ít nhất 1 sản phẩm.";
                return RedirectToAction(nameof(Create));
            }

            var items = itemsReq.Select(i => (skuId: i.SkuId, quantity: i.Quantity, unitCost: i.UnitCost));

            var po = await purchaseOrderService.CreatePurchaseOrderAsync(supplierId, items, note, cancellationToken);
            
            TempData["SuccessMessage"] = $"Đã tạo phiếu nhập {po.PoCode} thành công.";
            return RedirectToAction(nameof(Details), new { id = po.Id });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction(nameof(Create));
        }
    }
}
