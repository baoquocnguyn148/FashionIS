using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IAppDbContext _context;

    public AdminController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Dashboard(CancellationToken cancellationToken = default)
    {
        var today = DateTime.UtcNow.Date;
        var thisMonth = new DateTime(today.Year, today.Month, 1);
        var lastMonth = thisMonth.AddMonths(-1);
        var tomorrow = today.AddDays(1);

        var totalProducts = await _context.Products.CountAsync(p => !p.IsDeleted, cancellationToken);
        var totalOrders = await _context.Orders.CountAsync(o => !o.IsDeleted, cancellationToken);
        var totalCustomers = await _context.Customers.CountAsync(c => !c.IsDeleted, cancellationToken);

        var todayRevenue = await _context.Orders
            .Where(o => o.OrderDate >= today && o.OrderDate < tomorrow && !o.IsDeleted)
            .SumAsync(o => (decimal?)o.TotalAmount ?? 0, cancellationToken);

        var thisMonthRevenue = await _context.Orders
            .Where(o => o.OrderDate >= thisMonth && !o.IsDeleted)
            .SumAsync(o => (decimal?)o.TotalAmount ?? 0, cancellationToken);

        var lastMonthRevenue = await _context.Orders
            .Where(o => o.OrderDate >= lastMonth && o.OrderDate < thisMonth && !o.IsDeleted)
            .SumAsync(o => (decimal?)o.TotalAmount ?? 0, cancellationToken);

        var revenueGrowth = lastMonthRevenue > 0 
            ? ((thisMonthRevenue - lastMonthRevenue) / lastMonthRevenue * 100) 
            : 0;

        // Cảnh báo tồn kho thấp
        var lowStockCount = await _context.Inventories
            .Where(i => i.QuantityOnHand <= i.ReorderPoint && !i.IsDeleted)
            .CountAsync(cancellationToken);

        // 5 đơn hàng gần nhất
        var recentOrders = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Store)
            .Where(o => !o.IsDeleted)
            .OrderByDescending(o => o.OrderDate)
            .Take(5)
            .ToListAsync(cancellationToken);

        // Doanh thu 7 ngày gần nhất (cho chart)
        var revenueByDay = new List<object>();
        for (int i = 6; i >= 0; i--)
        {
            var day = today.AddDays(-i);
            var nextDay = day.AddDays(1);
            var rev = await _context.Orders
                .Where(o => o.OrderDate >= day && o.OrderDate < nextDay && !o.IsDeleted)
                .SumAsync(o => (decimal?)o.TotalAmount ?? 0, cancellationToken);
            revenueByDay.Add(new { date = day.ToString("dd/MM"), revenue = rev });
        }

        ViewBag.TotalProducts = totalProducts;
        ViewBag.TotalOrders = totalOrders;
        ViewBag.TotalCustomers = totalCustomers;
        ViewBag.TodayRevenue = todayRevenue;
        ViewBag.ThisMonthRevenue = thisMonthRevenue;
        ViewBag.RevenueGrowth = revenueGrowth;
        ViewBag.LowStockCount = lowStockCount;
        ViewBag.RecentOrders = recentOrders;
        ViewBag.RevenueByDay = revenueByDay;

        // Top products (simplified - by order count)
        var topProducts = await _context.OrderDetails
            .Include(od => od.ProductSku)
                .ThenInclude(sku => sku!.Product)
            .Where(od => !od.IsDeleted)
            .GroupBy(od => new { od.ProductSku!.Product!.Id, od.ProductSku!.Product!.Name })
            .Select(g => new { ProductName = g.Key.Name, TotalSold = g.Sum(od => od.Quantity), Revenue = g.Sum(od => od.Subtotal) })
            .OrderByDescending(x => x.TotalSold)
            .Take(10)
            .ToListAsync(cancellationToken);

        ViewBag.TopProducts = topProducts;

        return View();
    }

    public IActionResult Products()
    {
        return RedirectToAction("Index", "AdminProducts");
    }

    public IActionResult Orders()
    {
        return RedirectToAction("Index", "AdminOrders");
    }

    public IActionResult Inventory()
    {
        return RedirectToAction("Index", "AdminInventory");
    }

    public IActionResult Customers()
    {
        return RedirectToAction("Index", "AdminCustomers");
    }

    public IActionResult Reports()
    {
        return View();
    }
}
