using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Domain.Enums;
using StyleVibe.Web.ViewModels.Admin;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminCustomersController : Controller
{
    private readonly IAppDbContext _context;

    public AdminCustomersController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(CustomerTier? tier, string? search, int page = 1, CancellationToken cancellationToken = default)
    {
        const int pageSize = 20;
        page = Math.Max(1, page);

        var query = _context.Customers
            .Include(c => c.Orders.Where(o => !o.IsDeleted))
            .Where(c => !c.IsDeleted);

        if (tier.HasValue)
        {
            query = query.Where(c => c.Tier == tier.Value);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(c => c.FullName.Contains(s) || c.Phone.Contains(s));
        }

        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .OrderByDescending(c => c.JoinDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        ViewBag.Tier = tier;
        ViewBag.Search = search;
        ViewBag.Page = page;
        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);

        return View(items);
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
    {
        var customer = await _context.Customers
            .Include(c => c.Orders.OrderByDescending(o => o.OrderDate).Take(10))
            .Include(c => c.LoyaltyTransactions.OrderByDescending(t => t.CreatedAt).Take(10))
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, cancellationToken);

        if (customer == null) return NotFound();
        return View(customer);
    }

    [HttpGet]
    public IActionResult Create() => View(new CustomerViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return View(model);

        var customer = new Customer
        {
            FullName = model.FullName,
            Phone = model.Phone,
            Email = model.Email,
            Address = model.Address,
            DateOfBirth = model.DateOfBirth,
            Tier = model.Tier,
            LoyaltyPoints = model.LoyaltyPoints,
            JoinDate = DateTime.UtcNow,
            IsDeleted = false
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = "Thêm khách hàng thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken = default)
    {
        var c = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
        if (c == null) return NotFound();

        return View(new CustomerViewModel
        {
            Id = c.Id,
            FullName = c.FullName,
            Phone = c.Phone,
            Email = c.Email,
            Address = c.Address,
            DateOfBirth = c.DateOfBirth,
            Tier = c.Tier,
            LoyaltyPoints = c.LoyaltyPoints
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CustomerViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return View(model);

        var c = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.Id && !x.IsDeleted, cancellationToken);
        if (c == null) return NotFound();

        c.FullName = model.FullName;
        c.Phone = model.Phone;
        c.Email = model.Email;
        c.Address = model.Address;
        c.DateOfBirth = model.DateOfBirth;
        c.Tier = model.Tier;
        c.LoyaltyPoints = model.LoyaltyPoints;
        c.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = "Cập nhật khách hàng thành công.";
        return RedirectToAction(nameof(Details), new { id = c.Id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdjustPoints(int customerId, int points, string reason, CancellationToken cancellationToken = default)
    {
        var c = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId && !x.IsDeleted, cancellationToken);
        if (c == null) return NotFound();

        var transaction = new LoyaltyTransaction
        {
            CustomerId = customerId,
            Points = points,
            Description = reason,
            CreatedAt = DateTime.UtcNow
        };

        c.LoyaltyPoints += points;
        _context.LoyaltyTransactions.Add(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = $"Đã điều chỉnh {points} điểm cho khách hàng.";
        return RedirectToAction(nameof(Details), new { id = customerId });
    }
}
