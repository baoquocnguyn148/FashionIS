using System;
using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class PurchaseOrder : BaseEntity
    {
        public string PoCode { get; set; } = null!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ExpectedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
        public decimal TotalCost { get; set; }
        public string? Note { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;

        public virtual ICollection<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();
    }
}
