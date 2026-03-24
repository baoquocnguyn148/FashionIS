// FILE: d:\FashionStoreIS\FashionStoreIS\FashionStoreIS\Models\OrderDetail.cs
namespace FashionStoreIS.Models
{
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; } = 0;
        public decimal Subtotal { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public int? ProductSkuId { get; set; }
        public virtual ProductSku? ProductSku { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; } // Direct access for views if needed
    }
}
