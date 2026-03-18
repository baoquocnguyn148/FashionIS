using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _db.Categories
                .Include(c => c.ParentCategory)
                .OrderBy(c => c.DisplayOrder)
                .ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.Parents = await _db.Categories.Where(c => c.ParentCategoryId == null).ToListAsync();
            if (id.HasValue) // Edit
            {
                var cat = (await _db.Categories.Where(c => c.Id == id).ToListAsync()).FirstOrDefault();
                if (cat == null) return NotFound();
                return View(cat);
            }
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (model.Id > 0)
            {
                var existing = (await _db.Categories.Where(c => c.Id == model.Id).ToListAsync()).FirstOrDefault();
                if (existing == null) return NotFound();
                
                // Tránh tình trạng danh mục cha là chính nó
                if (model.ParentCategoryId == model.Id)
                    model.ParentCategoryId = null;

                existing.Name = model.Name;
                existing.Slug = string.IsNullOrEmpty(model.Slug) ? GenerateSlug(model.Name) : model.Slug;
                existing.ParentCategoryId = model.ParentCategoryId;
                existing.DisplayOrder = model.DisplayOrder;
                existing.IsActive = model.IsActive;
                existing.Description = model.Description;
                existing.ImageUrl = model.ImageUrl;
            }
            else
            {
                if (string.IsNullOrEmpty(model.Slug))
                    model.Slug = GenerateSlug(model.Name);
                _db.Categories.Add(model);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private string GenerateSlug(string name)
        {
            return name.ToLower()
                .Replace(" ", "-")
                .Replace("đ", "d")
                .Normalize(System.Text.NormalizationForm.FormD)
                .Where(c => (int)c <= 127)
                .Aggregate("", (s, c) => s + c)
                .Replace("--", "-");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = (await _db.Categories.Where(c => c.Id == id).ToListAsync()).FirstOrDefault();
            if (cat != null)
            {
                _db.Categories.Remove(cat);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
