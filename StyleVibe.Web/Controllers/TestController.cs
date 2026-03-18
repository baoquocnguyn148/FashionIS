using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Infrastructure.Data;

namespace StyleVibe.Web.Controllers;

public class TestController : Controller
{
    private readonly IAppDbContext _context;
    private readonly AppDbContext _dbContext;

    public TestController(IAppDbContext context, AppDbContext dbContext)
    {
        _context = context;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> CheckConnection(CancellationToken cancellationToken = default)
    {
        try
        {
            // Test 1: Kiểm tra có thể kết nối DB không
            var canConnect = await _dbContext.Database.CanConnectAsync(cancellationToken);
            
            // Test 2: Đếm số bảng đã tạo
            var storesCount = await _context.Stores.CountAsync(cancellationToken);
            var categoriesCount = await _context.Categories.CountAsync(cancellationToken);
            var productsCount = await _context.Products.CountAsync(cancellationToken);
            var customersCount = await _context.Customers.CountAsync(cancellationToken);
            var ordersCount = await _context.Orders.CountAsync(cancellationToken);
            
            // Test 3: Lấy connection string (ẩn password nếu có)
            var connectionString = _dbContext.Database.GetConnectionString() ?? "N/A";
            var safeConnectionString = connectionString.Contains("Password") 
                ? connectionString.Substring(0, connectionString.IndexOf("Password")) + "Password=***" 
                : connectionString;

            ViewBag.CanConnect = canConnect;
            ViewBag.StoresCount = storesCount;
            ViewBag.CategoriesCount = categoriesCount;
            ViewBag.ProductsCount = productsCount;
            ViewBag.CustomersCount = customersCount;
            ViewBag.OrdersCount = ordersCount;
            ViewBag.ConnectionString = safeConnectionString;
            ViewBag.DatabaseName = _dbContext.Database.GetDbConnection().Database;

            return View();
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            ViewBag.StackTrace = ex.StackTrace;
            return View();
        }
    }
}
