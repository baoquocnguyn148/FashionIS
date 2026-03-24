using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class CustomersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public CustomersController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            var result = new List<FashionStoreIS.Areas.Admin.ViewModels.CustomerAdminViewModel>();
            
            foreach (var user in users)
            {
                var orders = await _db.Orders
                    .Where(o => o.UserId == user.Id && o.Status != OrderStatus.Cancelled)
                    .ToListAsync();
                
                result.Add(new FashionStoreIS.Areas.Admin.ViewModels.CustomerAdminViewModel
                {
                    User = user,
                    OrderCount = orders.Count,
                    TotalSpent = orders.Sum(o => o.TotalAmount),
                    LastOrderDate = orders.Max(o => (DateTime?)o.CreatedAt)
                });
            }
            
            return View(result.OrderByDescending(r => r.TotalSpent).ToList());
        }
    }
}
