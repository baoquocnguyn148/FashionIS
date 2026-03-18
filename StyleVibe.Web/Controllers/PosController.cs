using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Infrastructure.Data;

namespace StyleVibe.Web.Controllers;

public class PosController(IPosService posService, AppDbContext dbContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var stores = await dbContext.Stores
            .Where(s => s.IsActive && !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();

        ViewBag.Stores = stores;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Checkout(int storeId, int? customerId, string note, byte paymentMethod, int[] skuIds, int[] quantities, decimal[] discounts)
    {
        if (skuIds.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Giỏ hàng đang trống.");
            return RedirectToAction(nameof(Index));
        }

        var items = new List<(int productSkuId, int quantity, decimal discountPercent)>();
        for (var i = 0; i < skuIds.Length; i++)
        {
            items.Add((skuIds[i], quantities[i], discounts[i]));
        }

        try
        {
            var order = await posService.CreateOrderAsync(
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
}

