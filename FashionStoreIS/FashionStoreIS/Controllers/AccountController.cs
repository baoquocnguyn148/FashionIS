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

            var query = _db.Orders.Where(o => o.UserId == user!.Id);
            
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

            using (var stream = avatar.OpenReadStream())
            {
                var headerBytes = new byte[12];
                await stream.ReadAsync(headerBytes, 0, 12);

                bool isJpg = headerBytes[0] == 0xFF && headerBytes[1] == 0xD8;
                bool isPng = headerBytes[0] == 0x89 && headerBytes[1] == 0x50 && headerBytes[2] == 0x4E && headerBytes[3] == 0x47;
                bool isWebp = headerBytes[0] == 0x52 && headerBytes[1] == 0x49 && headerBytes[2] == 0x46 && headerBytes[3] == 0x46 &&
                              headerBytes[8] == 0x57 && headerBytes[9] == 0x45 && headerBytes[10] == 0x42 && headerBytes[11] == 0x50;

                if (!isJpg && !isPng && !isWebp)
                {
                    TempData["Error"] = "Tệp đính kèm không phải là hình ảnh hợp lệ (Phát hiện sai chữ ký thập lục phân).";
                    return RedirectToAction("Index", new { tab = "profile" });
                }

                stream.Position = 0; // Reset position for copying

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var order = await _db.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user.Id);
                
            if (order == null) return NotFound();

            if (order.Status != OrderStatus.Pending)
            {
                TempData["Error"] = "Chỉ có thể hủy đơn hàng khi trạng thái là Chờ xác nhận.";
            }
            else
            {
                order.Status = OrderStatus.Cancelled;

                // 1. Restore Stock
                foreach (var detail in order.OrderDetails)
                {
                    if (detail.ProductId.HasValue)
                    {
                        var product = await _db.Products.FindAsync(detail.ProductId.Value);
                        if (product != null) product.Stock += detail.Quantity;
                    }
                    if (detail.ProductSkuId.HasValue)
                    {
                        var sku = await _db.ProductSkus.FindAsync(detail.ProductSkuId.Value);
                        if (sku != null) sku.Stock += detail.Quantity;
                    }
                }

                // 2. Restore Voucher Usage
                if (order.VoucherId.HasValue)
                {
                    var voucher = await _db.Vouchers.FindAsync(order.VoucherId.Value);
                    if (voucher != null && voucher.UsedCount > 0)
                    {
                        voucher.UsedCount -= 1;
                    }
                }

                await _db.SaveChangesAsync();
                TempData["Success"] = "Đã hủy đơn hàng thành công.";
            }

            return RedirectToAction("Index", new { tab = "orders" });
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            if (User.Identity?.Name == null) return RedirectToAction("Login", "Account", new { area = "Identity" });

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            if (user == null) return RedirectToAction("Login", "Account", new { area = "Identity" });

            // Fix: Include both ProductSku and Product to avoid null reference
            var orders = await _db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(oi => oi.ProductSku)
                .ThenInclude(s => s!.Product)
                .Include(o => o.OrderDetails)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.Id == id && o.UserId == user!.Id)
                .ToListAsync();

            var order = orders.FirstOrDefault();

            if (order == null) return NotFound();

            return View(order);
        }
    }
}
