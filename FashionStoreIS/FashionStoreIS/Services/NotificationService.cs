using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FashionStoreIS.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _db;

        public NotificationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SendAsync(string userId, string title, string message, string? actionUrl = null)
        {
            var notification = new Notification
            {
                UserId = userId,
                Title = title,
                Message = message,
                ActionUrl = actionUrl,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
            _db.Notifications.Add(notification);
            await _db.SaveChangesAsync();
        }

        public async Task SendReturnStatusChangedAsync(ReturnRequest rr, string adminNote = "")
        {
            // Load the order's UserId if not already loaded
            string? userId = rr.Order?.UserId;
            if (userId == null)
            {
                var order = await _db.Orders.FindAsync(rr.OrderId);
                userId = order?.UserId;
            }
            if (userId == null) return;

            string title, message;
            string actionUrl = "/Account/Index?tab=returns";

            switch (rr.Status)
            {
                case ReturnRequestStatus.Approved:
                    title = "✅ Yêu cầu trả hàng đã được duyệt";
                    message = $"Yêu cầu trả hàng cho đơn #{rr.OrderId} đã được chấp nhận. " +
                              "Vui lòng gửi hàng về địa chỉ cửa hàng. Chúng tôi sẽ hoàn tiền sau khi nhận hàng.";
                    break;
                case ReturnRequestStatus.Rejected:
                    title = "❌ Yêu cầu trả hàng bị từ chối";
                    message = $"Yêu cầu trả hàng cho đơn #{rr.OrderId} đã bị từ chối.";
                    if (!string.IsNullOrWhiteSpace(adminNote))
                        message += $" Lý do: {adminNote}";
                    break;
                case ReturnRequestStatus.Completed:
                    title = "💰 Hoàn tiền thành công";
                    message = $"Đơn trả hàng #{rr.OrderId} đã được xử lý hoàn tất. " +
                              $"Số tiền {rr.RefundAmount:N0}₫ đã được hoàn về tài khoản của bạn.";
                    break;
                default:
                    return;
            }

            await SendAsync(userId, title, message, actionUrl);
        }

        public async Task SendOrderSuccessAsync(Order order)
        {
            if (string.IsNullOrEmpty(order.UserId)) return;

            string title = "🎉 Đặt hàng thành công";
            string message = $"Cảm ơn bạn! Đơn hàng #{order.OrderCode} đã được đặt thành công. " +
                             $"Tổng thanh toán: {order.TotalAmount:N0}₫. Chúng tôi sẽ sớm xử lý đơn hàng của bạn.";
            string actionUrl = $"/Account/Index?tab=orders";

            await SendAsync(order.UserId, title, message, actionUrl);
        }

        public async Task SendOrderCancelledAsync(Order order)
        {
            if (string.IsNullOrEmpty(order.UserId)) return;

            string title = "🚫 Đã hủy đơn hàng";
            string message = $"Đơn hàng #{order.OrderCode} đã được hủy thành công theo yêu cầu của bạn. " +
                             "Hy vọng được phục vụ bạn trong lần mua sắm tới!";
            string actionUrl = $"/Account/Index?tab=orders";

            await SendAsync(order.UserId, title, message, actionUrl);
        }

        public async Task SendCartAddedAsync(string userId, string productName)
        {
            if (string.IsNullOrEmpty(userId)) return;

            string title = "🛒 Đã thêm vào giỏ hàng";
            string message = $"Sản phẩm '{productName}' đã được thêm vào giỏ hàng của bạn. Đừng quên thanh toán nhé!";
            string actionUrl = "/Cart/Index";

            await SendAsync(userId, title, message, actionUrl);
        }

        public async Task<int> SendBulkAsync(IEnumerable<string> userIds, string title, string message, string? actionUrl = null)
        {
            int count = 0;
            foreach (var userId in userIds)
            {
                if (string.IsNullOrEmpty(userId)) continue;
                try
                {
                    var notification = new Notification
                    {
                        UserId    = userId,
                        Title     = title,
                        Message   = message,
                        ActionUrl = actionUrl,
                        IsRead    = false,
                        CreatedAt = DateTime.Now
                    };
                    _db.Notifications.Add(notification);
                    count++;
                }
                catch { /* Skip failing individual notifications */ }
            }
            await _db.SaveChangesAsync();
            return count;
        }
    }
}
