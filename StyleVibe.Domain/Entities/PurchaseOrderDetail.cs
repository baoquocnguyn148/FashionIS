using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class PurchaseOrderDetail : BaseEntity
{
    public int QuantityOrdered { get; set; }
    public int QuantityReceived { get; set; }
    public decimal UnitCost { get; set; }
    public decimal Subtotal { get; set; }

    public int PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; } = null!;

    public int ProductSkuId { get; set; }
    public ProductSku ProductSku { get; set; } = null!;
}

