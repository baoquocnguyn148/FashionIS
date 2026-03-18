using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public BannersController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Banners.OrderBy(b => b.DisplayOrder).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() => View(new Banner());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner model, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
                model.ImageUrl = await SaveImage(imageFile);

            model.CreatedAt = DateTime.Now;
            _db.Banners.Add(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Thêm banner thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var banners = await _db.Banners.ToListAsync();
            var banner = banners.FirstOrDefault(b => b.Id == id);
            if (banner == null) return NotFound();
            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Banner model, IFormFile? imageFile)
        {
            var banners = await _db.Banners.ToListAsync();
            var existing = banners.FirstOrDefault(b => b.Id == model.Id);
            if (existing == null) return NotFound();

            existing.Title = model.Title;
            existing.SubTitle = model.SubTitle;
            existing.LinkUrl = model.LinkUrl;
            existing.Position = model.Position;
            existing.DisplayOrder = model.DisplayOrder;
            existing.IsActive = model.IsActive;

            if (imageFile != null && imageFile.Length > 0)
                existing.ImageUrl = await SaveImage(imageFile);

            await _db.SaveChangesAsync();
            TempData["Success"] = "Cập nhật banner thành công!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var banners = await _db.Banners.ToListAsync();
            var banner = banners.FirstOrDefault(b => b.Id == id);
            if (banner != null)
            {
                _db.Banners.Remove(banner);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Đã xóa banner.";
            }
            return RedirectToAction("Index");
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "uploads", "banners");
            Directory.CreateDirectory(uploads);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploads, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return "/uploads/banners/" + fileName;
        }
    }
}
