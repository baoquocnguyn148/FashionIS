using System;

namespace FashionStoreIS.Models
{
    public enum ReturnRequestStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Completed = 3
    }

    public class ReturnRequest : BaseEntity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public string Reason { get; set; } = null!;
        public ReturnRequestStatus Status { get; set; } = ReturnRequestStatus.Pending;
        public decimal RefundAmount { get; set; } = 0;

        // Admin processing fields
        public string? AdminNote { get; set; }      // Lý do từ chối hoặc ghi chú duyệt
        public DateTime? ProcessedAt { get; set; } // Thời điểm admin xử lý
    }
}
