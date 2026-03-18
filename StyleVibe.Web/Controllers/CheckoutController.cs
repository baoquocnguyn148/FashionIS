using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using System.Text.Json.Serialization;

namespace StyleVibe.Web.Controllers;

[Authorize] // Yêu cầu đăng nhập để checkout 
public class CheckoutController : Controller
{
    private readonly IAppDbContext _context;
    private readonly IPosService _posService;

    public CheckoutController(IAppDbContext context, IPosService posService)
    {
        _context = context;
        _posService = posService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        // Lấy thông tin customer nếu đã đăng nhập 
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var customer = userId != null
            ? await _context.Customers
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted, cancellationToken)
            : null;

        // Lấy danh sách stores để chọn nhận hàng / mua tại quầy 
        var stores = await _context.Stores
            .Where(s => s.IsActive && !s.IsDeleted)
            .ToListAsync(cancellationToken);

        ViewBag.Customer = customer;
        ViewBag.Stores = stores;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessOrder(
        string customerName, string address, string phone, string? note,
        int storeId, int paymentMethod, string itemsJson,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(itemsJson))
        {
            TempData["ErrorMessage"] = "Giỏ hàng trống.";
            return RedirectToAction(nameof(Index));
        }

        try
        {
            var itemsReq = System.Text.Json.JsonSerializer.Deserialize<List<CheckoutItem>>(itemsJson, 
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];

            if (!itemsReq.Any())
            {
                TempData["ErrorMessage"] = "Giỏ hàng trống.";
                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var customer = userId != null
                ? await _context.Customers
                    .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted, cancellationToken)
                : null;

            var items = itemsReq.Select(i =>
                (productSkuId: i.SkuId, quantity: i.Quantity, discountPercent: 0m));

            var order = await _posService.CreateOrderAsync(
                storeId: storeId,
                customerId: customer?.Id,
                items: items,
                paymentMethod: (byte)paymentMethod,
                note: note,
                customerName: customerName,
                phone: phone,
                address: address,
                cancellationToken: cancellationToken);

            return RedirectToAction(nameof(Success), new { orderId = order.Id });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Success(int orderId, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductSku)
                    .ThenInclude(sku => sku!.Product)
            .Include(o => o.Store)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, cancellationToken);

        if (order == null) return NotFound();
        return View(order);
    }
}

// ViewModel cho checkout request 
public class CheckoutRequest
{
    [JsonPropertyName("storeId")]
    public int StoreId { get; set; }

    [JsonPropertyName("paymentMethod")]
    public int PaymentMethod { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("items")]
    public List<CheckoutItem> Items { get; set; } = [];
}

public class CheckoutItem
{
    [JsonPropertyName("skuId")]
    public int SkuId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}