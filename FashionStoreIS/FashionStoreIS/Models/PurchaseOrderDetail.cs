namespace FashionStoreIS.Models
{
    public class PurchaseOrderDetail : BaseEntity
    {
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Subtotal { get; set; }

        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

        public int ProductSkuId { get; set; }
        public virtual ProductSku ProductSku { get; set; } = null!;
    }
}
