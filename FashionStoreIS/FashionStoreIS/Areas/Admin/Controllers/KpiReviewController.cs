using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class KpiReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public KpiReviewController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/KpiReview
        public async Task<IActionResult> Index(int? month, int? year, int? storeId)
        {
            int m = month ?? DateTime.Now.Month;
            int y = year ?? DateTime.Now.Year;

            var query = _context.KpiReviews.Include(k => k.Employee).Include(k => k.Reviewer)
                .Where(k => k.Month == m && k.Year == y);

            if (storeId.HasValue)
                query = query.Where(k => k.Employee.StoreId == storeId);

            ViewData["Month"] = m;
            ViewData["Year"] = y;
            ViewData["Stores"] = new SelectList(_context.Stores, "Id", "Name", storeId);

            return View(await query.ToListAsync());
        }

        // GET: Admin/KpiReview/Create
        public IActionResult Create(int? employeeId)
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees.Where(e => e.IsActive), "Id", "FullName", employeeId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KpiReview review)
        {
            // Check if review already exists
            var existing = await _context.KpiReviews.AnyAsync(k => k.EmployeeId == review.EmployeeId && k.Month == review.Month && k.Year == review.Year);
            if (existing)
            {
                ModelState.AddModelError("", "Nhân viên này đã được đánh giá trong tháng này.");
            }

            if (ModelState.IsValid)
            {
                // Calculate TotalScore (Weighted: Sales 50%, Attitude 25%, Teamwork 25%)
                review.TotalScore = (review.SalesScore * 0.5m) + (review.AttitudeScore * 0.25m) + (review.TeamworkScore * 0.25m);
                
                // Determine Rank
                review.Rank = review.TotalScore switch
                {
                    >= 90 => KpiRank.A,
                    >= 70 => KpiRank.B,
                    >= 50 => KpiRank.C,
                    _ => KpiRank.D
                };

                review.ReviewerId = _userManager.GetUserId(User);
                review.CreatedAt = DateTime.Now;
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees.Where(e => e.IsActive), "Id", "FullName", review.EmployeeId);
            return View(review);
        }

        public async Task<IActionResult> Leaderboard(int? month, int? year)
        {
            int m = month ?? DateTime.Now.Month;
            int y = year ?? DateTime.Now.Year;

            var topPerformers = await _context.KpiReviews
                .Include(k => k.Employee).ThenInclude(e => e.Store)
                .Where(k => k.Month == m && k.Year == y)
                .OrderByDescending(k => k.TotalScore)
                .Take(10)
                .ToListAsync();

            ViewData["Month"] = m;
            ViewData["Year"] = y;
            return View(topPerformers);
        }
    }
}
