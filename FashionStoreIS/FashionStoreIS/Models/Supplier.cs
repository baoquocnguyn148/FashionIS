using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? ContactPerson { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int LeadTimeDays { get; set; } = 7;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    }
}
