using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FashionStoreIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            try
            {
                var banners = await _db.Banners
                    .Where(b => b.IsActive)
                    .OrderBy(b => b.DisplayOrder)
                    .ToListAsync();
                
                var hero = banners.FirstOrDefault(b => b.Position == "Hero");
                if (hero == null)
                {
                    Console.WriteLine("[HOME_DIAG] No Hero banner found in DB. Count: " + banners.Count);
                }
                else
                {
                    Console.WriteLine("[HOME_DIAG] Hero banner found: " + hero.ImageUrl);
                }

                ViewBag.HeroBanner = hero;
                ViewBag.CategoryBanners = banners.Where(b => b.Position != "Hero").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[HOME_ERR] " + ex.Message);
                ViewBag.HeroBanner = null;
                ViewBag.CategoryBanners = new List<Banner>();
            }
            return View();
        }

        [HttpGet("/Home/ForceReseed")]
        public async Task<IActionResult> ForceReseed()
        {
            try
            {
                var isPostgres = _db.Database.ProviderName?.Contains("Npgsql", StringComparison.OrdinalIgnoreCase) == true;
                if (isPostgres)
                {
                    await _db.Database.ExecuteSqlRawAsync("TRUNCATE TABLE \"PRODUCTS\", \"CATEGORIES\", \"BANNERS\" CASCADE;");
                }
                else
                {
                    await _db.Database.ExecuteSqlRawAsync("DELETE FROM PRODUCTS; DELETE FROM CATEGORIES; DELETE FROM BANNERS;");
                }

                return Content("Database TRUNCATED cleanly (soft deletes bypassed). PLEASE RESTART THE RENDER SERVER (Manual Deploy) to re-seed data from scratch.", "text/plain");
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message + "\n" + ex.InnerException?.Message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
