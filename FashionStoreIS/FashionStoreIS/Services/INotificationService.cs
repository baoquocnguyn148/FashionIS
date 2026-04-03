using FashionStoreIS.Models;
using System.Threading.Tasks;

namespace FashionStoreIS.Services
{
    public interface INotificationService
    {
        /// <summary>Gửi một notification đến user.</summary>
        Task SendAsync(string userId, string title, string message, string? actionUrl = null);

        /// <summary>Gửi notification tự động khi trạng thái đơn trả thay đổi.</summary>
        Task SendReturnStatusChangedAsync(ReturnRequest returnRequest, string adminNote = "");

        /// <summary>Gửi notification khi đặt hàng thành công.</summary>
        Task SendOrderSuccessAsync(Order order);

        /// <summary>Gửi notification khi hủy đơn hàng.</summary>
        Task SendOrderCancelledAsync(Order order);

        /// <summary>Gửi notification khi thêm vào giỏ hàng.</summary>
        Task SendCartAddedAsync(string userId, string productName);

        /// <summary>Gửi notification hàng loạt đến nhiều user (dùng cho Campaign).</summary>
        Task<int> SendBulkAsync(IEnumerable<string> userIds, string title, string message, string? actionUrl = null);
    }
}
