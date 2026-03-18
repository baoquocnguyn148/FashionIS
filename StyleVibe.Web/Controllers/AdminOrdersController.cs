using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Enums;
using StyleVibe.Web.ViewModels.Admin;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminOrdersController : Controller
{
    private readonly IAppDbContext _context;

    public AdminOrdersController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(OrderFilterViewModel filter, CancellationToken cancellationToken = default)
    {
        const int pageSize = 20;
        filter.Page = Math.Max(1, filter.Page);

        var query = _context.Orders
            .Include(o => o.Store)
            .Include(o => o.Customer)
            .Where(o => !o.IsDeleted);

        if (filter.Status.HasValue)
        {
            query = query.Where(o => o.Status == filter.Status.Value);
        }

        if (filter.StoreId.HasValue && filter.StoreId.Value > 0)
        {
            query = query.Where(o => o.StoreId == filter.StoreId.Value);
        }

        if (filter.DateFrom.HasValue)
        {
            var from = filter.DateFrom.Value.Date;
            query = query.Where(o => o.OrderDate >= from);
        }

        if (filter.DateTo.HasValue)
        {
            var toExclusive = filter.DateTo.Value.Date.AddDays(1);
            query = query.Where(o => o.OrderDate < toExclusive);
        }

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var s = filter.Search.Trim();
            query = query.Where(o => o.OrderCode.Contains(s) || (o.Customer != null && o.Customer.FullName.Contains(s)));
        }

        var total = await query.CountAsync(cancellationToken);
        var orders = await query
            .OrderByDescending(o => o.OrderDate)
            .Skip((filter.Page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Filter = filter;
        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);

        return View(orders);
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders
            .Include(o => o.Store)
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductSku)
                    .ThenInclude(sku => sku.Product)
            .Where(o => o.Id == id && !o.IsDeleted)
            .FirstOrDefaultAsync(cancellationToken);

        if (order == null) return NotFound();
        return View(order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, OrderStatus status, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted, cancellationToken);
        if (order == null) return NotFound();

        if (!IsValidTransition(order.Status, status))
        {
            TempData["ErrorMessage"] = "Chuyển trạng thái không hợp lệ.";
            return RedirectToAction(nameof(Details), new { id });
        }

        order.Status = status;
        order.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);
        TempData["SuccessMessage"] = "Cập nhật trạng thái thành công.";

        return RedirectToAction(nameof(Details), new { id });
    }

    private static bool IsValidTransition(OrderStatus from, OrderStatus to)
    {
        if (from == to) return true;
        if (from is OrderStatus.Completed or OrderStatus.Cancelled) return false;

        return from switch
        {
            OrderStatus.Pending => to is OrderStatus.Confirmed or OrderStatus.Cancelled,
            OrderStatus.Confirmed => to is OrderStatus.Processing or OrderStatus.Cancelled,
            OrderStatus.Processing => to is OrderStatus.Completed or OrderStatus.Cancelled,
            _ => false
        };
    }
}

