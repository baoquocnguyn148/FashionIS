using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Web.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly IAppDbContext _context;

    public AccountController(IAppDbContext context)
    {
        _context = context;
    }

    // Helper: lấy Customer của user hiện tại 
    private async Task<Customer?> GetCurrentCustomerAsync(CancellationToken ct = default)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return null;
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted, ct);
    }

    // Trang tổng quan tài khoản 
    public async Task<IActionResult> Index(CancellationToken ct = default)
    {
        var customer = await GetCurrentCustomerAsync(ct);
        if (customer == null) return RedirectToAction("CreateProfile");

        var recentOrders = await _context.Orders
            .Where(o => o.CustomerId == customer.Id && !o.IsDeleted)
            .OrderByDescending(o => o.OrderDate)
            .Take(5)
            .ToListAsync(ct);

        ViewBag.RecentOrders = recentOrders;
        return View(customer);
    }

    // Danh sách đơn hàng 
    public async Task<IActionResult> Orders(int page = 1, CancellationToken ct = default)
    {
        var customer = await GetCurrentCustomerAsync(ct);
        if (customer == null) return RedirectToAction("CreateProfile");

        const int pageSize = 10;
        var query = _context.Orders
            .Include(o => o.Store)
            .Where(o => o.CustomerId == customer.Id && !o.IsDeleted)
            .OrderByDescending(o => o.OrderDate);

        var total = await query.CountAsync(ct);
        var orders = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);

        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);
        ViewBag.CurrentPage = page;
        return View(orders);
    }

    // Chi tiết 1 đơn hàng 
    public async Task<IActionResult> OrderDetail(int id, CancellationToken ct = default)
    {
        var customer = await GetCurrentCustomerAsync(ct);
        if (customer == null) return Unauthorized();

        var order = await _context.Orders
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductSku)
                    .ThenInclude(sku => sku!.Product)
            .Include(o => o.Store)
            .FirstOrDefaultAsync(o => o.Id == id
                                   && o.CustomerId == customer.Id
                                   && !o.IsDeleted, ct);

        if (order == null) return NotFound();
        return View(order);
    }

    // Trang điểm loyalty 
    public async Task<IActionResult> Loyalty(CancellationToken ct = default)
    {
        var customer = await GetCurrentCustomerAsync(ct);
        if (customer == null) return RedirectToAction("CreateProfile");

        var transactions = await _context.LoyaltyTransactions
            .Where(t => t.CustomerId == customer.Id)
            .OrderByDescending(t => t.CreatedAt)
            .Take(20)
            .ToListAsync(ct);

        ViewBag.Transactions = transactions;
        return View(customer);
    }

    // Tạo profile lần đầu sau khi đăng ký 
    [HttpGet]
    public IActionResult CreateProfile() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProfile(
        string fullName, string phone, string? address,
        CancellationToken ct = default)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        // Check số điện thoại chưa tồn tại 
        if (await _context.Customers.AnyAsync(c => c.Phone == phone && !c.IsDeleted, ct))
        {
            ModelState.AddModelError("phone", "Số điện thoại đã được đăng ký.");
            return View();
        }

        var customer = new Customer
        {
            FullName = fullName,
            Phone = phone,
            Address = address,
            UserId = userId,
            JoinDate = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            Tier = CustomerTier.Bronze,
            LoyaltyPoints = 0
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(ct);

        return RedirectToAction("Index");
    }
}
