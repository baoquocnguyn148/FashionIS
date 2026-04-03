// FILE: d:\FashionStoreIS\FashionStoreIS\FashionStoreIS\Models\Order.cs
using System;
using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Order : BaseEntity
    {
        public string OrderCode { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
        public decimal SubTotal { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public int PointsEarned { get; set; } = 0;
        public string? Note { get; set; }
 
        public int? VoucherId { get; set; }
        public virtual Voucher? Voucher { get; set; }

        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;

        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<ReturnRequest> ReturnRequests { get; set; } = new List<ReturnRequest>();
    }
}
