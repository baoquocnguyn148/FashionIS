using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
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
        private readonly INotificationService _notif;

        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, INotificationService notif)
        {
            _db = db;
            _userManager = userManager;
            _notif = notif;
        }

        public async Task<IActionResult> Index(string tab = "orders", string? status = null)
        {
            if (User.Identity?.Name == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            ViewBag.User = user;
            ViewBag.ActiveTab = tab;

            if (tab == "orders")
            {
                var query = _db.Orders.Where(o => o.UserId == user.Id);
                if (!string.IsNullOrEmpty(status) && Enum.TryParse<OrderStatus>(status, out var statusEnum))
                {
                    query = query.Where(o => o.Status == statusEnum);
                }
                var orders = await query.OrderByDescending(o => o.CreatedAt).ToListAsync();
                ViewBag.SelectedStatus = status;
                return View(orders);
            }
            else if (tab == "address")
            {
                var addresses = await _db.UserAddresses
                    .Where(a => a.UserId == user.Id)
                    .OrderByDescending(a => a.IsDefault)
                    .ToListAsync();
                return View(addresses);
            }
            else if (tab == "notifications")
            {
                var notifications = await _db.Notifications
                    .Where(n => n.UserId == user.Id)
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync();
                return View(notifications);
            }
            else if (tab == "returns")
            {
                var returns = await _db.ReturnRequests
                    .Include(r => r.Order)
                    .Where(r => r.Order.UserId == user.Id)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();
                return View(returns);
            }
            else if (tab == "promotions")
            {
                var vouchers = await _db.Vouchers
                    .Where(v => v.IsActive && v.ExpiryDate > DateTime.Now)
                    .OrderByDescending(v => v.DiscountAmount)
                    .ToListAsync();
                return View(vouchers);
            }

            return View(new List<Order>());
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
                await _notif.SendOrderCancelledAsync(order);
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

        // --- Address Management ---

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(string fullName, string phoneNumber, string addressLine, bool isDefault)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            if (isDefault)
            {
                var existingDefault = await _db.UserAddresses.FirstOrDefaultAsync(a => a.UserId == user.Id && a.IsDefault);
                if (existingDefault != null) existingDefault.IsDefault = false;
            }

            var addressCount = await _db.UserAddresses.CountAsync(a => a.UserId == user.Id);

            var address = new UserAddress
            {
                UserId = user.Id,
                FullName = fullName,
                PhoneNumber = phoneNumber,
                AddressLine = addressLine,
                IsDefault = isDefault || addressCount == 0
            };

            _db.UserAddresses.Add(address);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Đã thêm địa chỉ mới thành công.";
            return RedirectToAction("Index", new { tab = "address" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var address = await _db.UserAddresses.FirstOrDefaultAsync(a => a.Id == id && a.UserId == user.Id);
            if (address == null) return NotFound();

            if (address.IsDefault)
            {
                var other = await _db.UserAddresses.FirstOrDefaultAsync(a => a.Id != id && a.UserId == user.Id);
                if (other != null) other.IsDefault = true;
            }

            _db.UserAddresses.Remove(address);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Đã xóa địa chỉ thành công.";
            return RedirectToAction("Index", new { tab = "address" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetDefaultAddress(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var addresses = await _db.UserAddresses.Where(a => a.UserId == user.Id).ToListAsync();
            foreach (var a in addresses)
            {
                a.IsDefault = (a.Id == id);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", new { tab = "address" });
        }

        // --- Returns ---

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestReturn(int orderId, string reason)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == user.Id);
            if (order == null) return NotFound();

            if (order.Status != OrderStatus.Completed)
            {
                TempData["Error"] = "Chỉ có thể yêu cầu trả hàng cho đơn hàng đã giao thành công.";
                return RedirectToAction("Index", new { tab = "orders" });
            }

            var existing = await _db.ReturnRequests.AnyAsync(r => r.OrderId == orderId);
            if (existing)
            {
                TempData["Error"] = "Đơn hàng này đã có yêu cầu xử lý trả hàng.";
                return RedirectToAction("Index", new { tab = "returns" });
            }

            var rr = new ReturnRequest
            {
                OrderId = orderId,
                Reason = reason,
                Status = ReturnRequestStatus.Pending,
                RefundAmount = order.TotalAmount
            };

            _db.ReturnRequests.Add(rr);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Yêu cầu trả hàng đã được gửi và đang chờ xử lý.";
            return RedirectToAction("Index", new { tab = "returns" });
        }

        // --- Notifications ---

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkRead(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var n = await _db.Notifications.FirstOrDefaultAsync(x => x.Id == id && x.UserId == user.Id);
            if (n != null)
            {
                n.IsRead = true;
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { tab = "notifications" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound();

            var n = await _db.Notifications.FirstOrDefaultAsync(x => x.Id == id && x.UserId == user.Id);
            if (n != null)
            {
                _db.Notifications.Remove(n);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { tab = "notifications" });
        }
    }
}
