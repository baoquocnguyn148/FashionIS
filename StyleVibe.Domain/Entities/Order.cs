using StyleVibe.Domain.Common;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Domain.Entities;

public class Order : BaseEntity
{
    public string OrderCode { get; set; } = null!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public int PointsEarned { get; set; }
    public string? Note { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

