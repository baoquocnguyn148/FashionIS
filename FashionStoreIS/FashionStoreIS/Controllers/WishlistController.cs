using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Controllers
{
    [Authorize]  // Yêu cầu đăng nhập cho toàn bộ controller
    public class WishlistController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // ─── GET /Wishlist ────────────────────────────────────────────────────
        /// <summary>Hiển thị danh sách sản phẩm yêu thích của user hiện tại.</summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var items = await _db.WishlistItems
                .Where(w => w.UserId == userId)
                .Include(w => w.Product)
                    .ThenInclude(p => p.Category)
                .OrderByDescending(w => w.CreatedAt)
                .ToListAsync();

            ViewData["Title"] = "Danh sách yêu thích";
            return View(items);
        }

        // ─── POST /Wishlist/Toggle/{productId} ───────────────────────────────
        /// <summary>
        /// AJAX: Thêm nếu chưa có, xóa nếu đã có (toggle).
        /// Trả về JSON { inWishlist: bool, count: int }.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Toggle(int id)
        {
            var userId = _userManager.GetUserId(User);
            var productId = id; // map to productId for clarity in logic

            // Kiểm tra sản phẩm tồn tại và đang active
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == productId && p.IsActive);
            if (product == null)
                return Json(new { success = false, message = "Sản phẩm không tồn tại." });

            var existing = await _db.WishlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            bool inWishlist;
            if (existing != null)
            {
                // Đã có → Xóa khỏi wishlist (hard delete, không phải soft)
                _db.WishlistItems.Remove(existing);
                inWishlist = false;
            }
            else
            {
                // Chưa có → Thêm vào wishlist
                _db.WishlistItems.Add(new WishlistItem
                {
                    UserId    = userId!,
                    ProductId = productId,
                    CreatedAt = DateTime.Now
                });
                inWishlist = true;
            }

            await _db.SaveChangesAsync();

            var count = await _db.WishlistItems.CountAsync(w => w.UserId == userId);
            return Json(new { success = true, inWishlist, count });
        }

        // ─── POST /Wishlist/Remove/{productId} ───────────────────────────────
        /// <summary>Xóa sản phẩm khỏi wishlist (dùng từ trang Wishlist/Index).</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var userId = _userManager.GetUserId(User);
            var productId = id;

            var item = await _db.WishlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            if (item != null)
            {
                _db.WishlistItems.Remove(item);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Đã xóa sản phẩm khỏi danh sách yêu thích.";
            }

            return RedirectToAction(nameof(Index));
        }

        // ─── GET /Wishlist/Status/{productId} ────────────────────────────────
        /// <summary>AJAX: Kiểm tra xem sản phẩm có trong wishlist chưa.</summary>
        [HttpGet]
        public async Task<IActionResult> Status(int id)
        {
            var userId = _userManager.GetUserId(User);
            var productId = id;
            var inWishlist = await _db.WishlistItems
                .AnyAsync(w => w.UserId == userId && w.ProductId == productId);
            var count = await _db.WishlistItems.CountAsync(w => w.UserId == userId);
            return Json(new { inWishlist, count });
        }

        // ─── GET /Wishlist/GetWishlistIds ─────────────────────────────────────
        /// <summary>AJAX: Trả về tất cả productId trong wishlist của user (dùng để load trạng thái bulk).</summary>
        [HttpGet]
        public async Task<IActionResult> GetWishlistIds()
        {
            var userId = _userManager.GetUserId(User);
            var ids = await _db.WishlistItems
                .Where(w => w.UserId == userId)
                .Select(w => w.ProductId)
                .ToListAsync();
            return Json(new { ids, count = ids.Count });
        }

        // ─── POST /Wishlist/Clear ─────────────────────────────────────────────
        /// <summary>Xóa toàn bộ wishlist của user.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            var userId = _userManager.GetUserId(User);
            var items = await _db.WishlistItems.Where(w => w.UserId == userId).ToListAsync();
            _db.WishlistItems.RemoveRange(items);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Đã xóa toàn bộ danh sách yêu thích.";
            return RedirectToAction(nameof(Index));
        }
    }
}
