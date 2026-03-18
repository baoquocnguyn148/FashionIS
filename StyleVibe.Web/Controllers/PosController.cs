using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin,Staff")]
public class PosController : Controller
{
    private readonly IPosService _posService;
    private readonly IAppDbContext _context;

    public PosController(IPosService posService, IAppDbContext context)
    {
        _posService = posService;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var stores = await _context.Stores
            .Where(s => s.IsActive && !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();

        ViewBag.Stores = stores;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout(int storeId, int? customerId, string note, byte paymentMethod, int[] skuIds, int[] quantities, decimal[] discounts)
    {
        if (skuIds == null || skuIds.Length == 0)
        {
            TempData["ErrorMessage"] = "Giỏ hàng đang trống.";
            return RedirectToAction(nameof(Index));
        }

        var items = new List<(int productSkuId, int quantity, decimal discountPercent)>();
        for (var i = 0; i < skuIds.Length; i++)
        {
            items.Add((skuIds[i], quantities[i], discounts[i]));
        }

        try
        {
            var order = await _posService.CreateOrderAsync(
                storeId,
                customerId,
                items,
                paymentMethod,
                string.IsNullOrWhiteSpace(note) ? null : note);

            TempData["SuccessMessage"] = $"Thanh toán thành công. Mã đơn: {order.OrderCode}";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    // API tìm SKU theo code hoặc tên sản phẩm 
    [HttpGet]
    public async Task<IActionResult> SearchSku(string q, int storeId, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(q)) return Json(new List<object>());

        var skus = await _context.ProductSkus
            .Include(s => s.Product)
            .Where(s => s.IsActive && !s.IsDeleted
                     && (s.SkuCode.Contains(q) || (s.Product != null && s.Product.Name.Contains(q))))
            .Take(10)
            .ToListAsync(ct);

        var skuIds = skus.Select(s => s.Id).ToList();
        var inventory = await _context.Inventories
            .Where(i => i.StoreId == storeId
                     && skuIds.Contains(i.ProductSkuId)
                     && !i.IsDeleted)
            .ToListAsync(ct);

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
