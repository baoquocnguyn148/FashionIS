using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index(string search, string status)
        {
            var query = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(oi => oi.ProductSku)
                        .ThenInclude(s => s.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(oi => oi.Product)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                var searchLower = search.ToLower();
                query = query.Where(o => o.CustomerName.ToLower().Contains(searchLower) || o.Phone.Contains(searchLower));
            }

            if (!string.IsNullOrEmpty(status) && Enum.TryParse<OrderStatus>(status, out var statusEnum))
            {
                query = query.Where(o => o.Status == statusEnum);
            }

            var orders = await query.OrderByDescending(o => o.CreatedAt).ToListAsync();
            
            ViewBag.Search = search;
            ViewBag.Status = status;

            return View(orders);
        }

        // GET: Admin/Order/ExportCsv
        public async Task<IActionResult> ExportCsv()
        {
            var orders = await _context.Orders.OrderByDescending(o => o.CreatedAt).ToListAsync();
            
            var builder = new System.Text.StringBuilder();
            builder.AppendLine("OrderID,Customer,Phone,Amount,Status,Date");

            foreach (var order in orders)
            {
                builder.AppendLine($"{order.Id},{order.CustomerName},{order.Phone},{order.TotalAmount},{order.Status},{order.CreatedAt:yyyy-MM-dd HH:mm}");
            }

            return File(System.Text.Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", $"Orders_{DateTime.Now:yyyyMMdd}.csv");
        }

        // POST: Admin/Order/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.Status = status;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(oi => oi.ProductSku)
                        .ThenInclude(s => s.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
