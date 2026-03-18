using Microsoft.EntityFrameworkCore;
using StyleVibe.Domain.Entities;

namespace StyleVibe.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Store> Stores { get; }
    DbSet<Category> Categories { get; }
    DbSet<Supplier> Suppliers { get; }
    DbSet<Product> Products { get; }
    DbSet<ProductSku> ProductSkus { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderDetail> OrderDetails { get; }
    DbSet<Inventory> Inventories { get; }
    DbSet<StockAdjustment> StockAdjustments { get; }
    DbSet<PurchaseOrder> PurchaseOrders { get; }
    DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; }
    DbSet<LoyaltyTransaction> LoyaltyTransactions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

