using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Store : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string ManagerName { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
