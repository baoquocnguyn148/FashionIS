using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FashionStoreIS.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET: /Order/MyOrders
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            var orders = await _db.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId == user.Id && !o.IsDeleted)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return View(orders);
        }

        // GET: /Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            var order = await _db.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.ProductSku)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user.Id && !o.IsDeleted);

            if (order == null)
                return NotFound();

            return View(order);
        }
    }
}
