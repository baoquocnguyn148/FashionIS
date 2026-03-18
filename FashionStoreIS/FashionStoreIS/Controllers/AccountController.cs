using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FashionStoreIS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string tab = "orders", string? status = null)
        {
            if (User.Identity?.Name == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var query = _db.Orders.Where(o => o.UserId == user.Id);
            
            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<OrderStatus>(status, out var statusEnum))
                {
                    query = query.Where(o => o.Status == statusEnum);
                }
            }

            var orders = await query
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            ViewBag.User = user;
            ViewBag.ActiveTab = tab;
            ViewBag.SelectedStatus = status;
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadAvatar(IFormFile avatar)
        {
            if (avatar == null || avatar.Length == 0) return RedirectToAction("Index", new { tab = "profile" });
            if (avatar.Length > 2 * 1024 * 1024)
            {
                TempData["Error"] = "Ảnh đại diện quá lớn (tối đa 2MB).";
                return RedirectToAction("Index", new { tab = "profile" });
            }

            var ext = Path.GetExtension(avatar.FileName).ToLowerInvariant();
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            if (!allowed.Contains(ext))
            {
                TempData["Error"] = "Định dạng ảnh không hợp lệ. Chỉ hỗ trợ JPG/PNG/WEBP.";
                return RedirectToAction("Index", new { tab = "profile" });
            }

            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var fileName = user.Id + "_" + DateTimeOffset.UtcNow.ToUnixTimeSeconds() + ext;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "avatars", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await avatar.CopyToAsync(stream);
            }

            user.AvatarUrl = "/uploads/avatars/" + fileName;
            await _userManager.UpdateAsync(user);

            TempData["Success"] = "Cập nhật ảnh đại diện thành công.";
            return RedirectToAction("Index", new { tab = "profile" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(string fullName, string phoneNumber, DateTime? dob, string gender)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            user.FullName = fullName;
            user.PhoneNumber = phoneNumber;
            user.DateOfBirth = dob;
            user.Gender = gender;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "Cập nhật thông tin thành công.";
            }
            else
            {
                TempData["Error"] = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return RedirectToAction("Index", new { tab = "profile" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                TempData["Error"] = "Mật khẩu xác nhận không khớp.";
                return RedirectToAction("Index", new { tab = "security" });
            }

            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                TempData["Success"] = "Đổi mật khẩu thành công.";
            }
            else
            {
                TempData["Error"] = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return RedirectToAction("Index", new { tab = "security" });
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            if (User.Identity?.Name == null) return RedirectToAction("Login", "Account", new { area = "Identity" });

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            if (user == null) return RedirectToAction("Login", "Account", new { area = "Identity" });

            // Oracle 11g workaround
            var orders = await _db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(oi => oi.ProductSku)
                .ThenInclude(s => s.Product)
                .Where(o => o.Id == id && o.UserId == user.Id)
                .ToListAsync();

            var order = orders.FirstOrDefault();

            if (order == null) return NotFound();

            return View(order);
        }
    }
}
