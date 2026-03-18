using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class Store : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string ManagerName { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}

