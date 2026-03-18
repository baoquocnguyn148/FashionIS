using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal Subtotal { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ProductSkuId { get; set; }
    public ProductSku ProductSku { get; set; } = null!;
}

