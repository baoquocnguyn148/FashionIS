using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Common;
using StyleVibe.Domain.Entities;

namespace StyleVibe.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Store> Stores => Set<Store>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductSku> ProductSkus => Set<ProductSku>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<StockAdjustment> StockAdjustments => Set<StockAdjustment>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderDetail> PurchaseOrderDetails => Set<PurchaseOrderDetail>();
    public DbSet<LoyaltyTransaction> LoyaltyTransactions => Set<LoyaltyTransaction>();
    public DbSet<Voucher> Vouchers => Set<Voucher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // QUAN TRỌNG: gọi base để Identity tạo đúng schema

        var provider = Database.ProviderName ?? "";
        var utcNowSql = provider.Contains("Oracle", StringComparison.OrdinalIgnoreCase)
            ? "SYS_EXTRACT_UTC(SYSTIMESTAMP)"
            : "GETUTCDATE()";

        // Apply common configuration for BaseEntity
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var builder = modelBuilder.Entity(entityType.ClrType);
                builder.Property<DateTime>("CreatedAt").HasDefaultValueSql(utcNowSql);
                builder.Property<bool>("IsDeleted").HasDefaultValue(false);
            }
        }

        modelBuilder.Entity<Store>(b =>
        {
            b.Property(x => x.Name).HasMaxLength(100).IsRequired();
            b.Property(x => x.Address).HasMaxLength(200).IsRequired();
            b.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            b.Property(x => x.ManagerName).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Category>(b =>
        {
            b.Property(x => x.Name).HasMaxLength(50).IsRequired();
            b.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Supplier>(b =>
        {
            b.Property(x => x.Name).HasMaxLength(150).IsRequired();
            b.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            b.Property(x => x.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(b =>
        {
            b.Property(x => x.Name).HasMaxLength(150).IsRequired();
            b.HasOne(x => x.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(x => x.CategoryId);
            b.HasOne(x => x.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(x => x.SupplierId);
        });

        modelBuilder.Entity<ProductSku>(b =>
        {
            b.Property(x => x.SkuCode).HasMaxLength(30).IsRequired();
            b.HasIndex(x => x.SkuCode).IsUnique();
            b.Property(x => x.Size).HasMaxLength(10).IsRequired();
            b.Property(x => x.Color).HasMaxLength(50).IsRequired();
            b.Property(x => x.CostPrice).HasColumnType("decimal(12,0)");
            b.Property(x => x.SellingPrice).HasColumnType("decimal(12,0)");
            b.Property(x => x.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<Customer>(b =>
        {
            b.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            b.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            b.HasIndex(x => x.Phone).IsUnique();
            b.Property(x => x.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(b =>
        {
            b.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            b.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            b.Property(x => x.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(b =>
        {
            b.Property(x => x.OrderCode).HasMaxLength(20).IsRequired();
            b.HasIndex(x => x.OrderCode).IsUnique();
            b.Property(x => x.SubTotal).HasColumnType("decimal(12,0)");
            b.Property(x => x.DiscountAmount).HasColumnType("decimal(12,0)");
            b.Property(x => x.TotalAmount).HasColumnType("decimal(12,0)");
        });

        modelBuilder.Entity<OrderDetail>(b =>
        {
            b.Property(x => x.UnitPrice).HasColumnType("decimal(12,0)");
            b.Property(x => x.Subtotal).HasColumnType("decimal(12,0)");
            b.HasOne(x => x.ProductSku)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(x => x.ProductSkuId)
                .IsRequired(false); // Cho phép NULL nếu là sản phẩm đơn giản 
        });

        modelBuilder.Entity<PurchaseOrder>(b =>
        {
            b.Property(x => x.PoCode).HasMaxLength(20).IsRequired();
            b.HasIndex(x => x.PoCode).IsUnique();
            b.Property(x => x.TotalCost).HasColumnType("decimal(12,0)");
        });

        modelBuilder.Entity<PurchaseOrderDetail>(b =>
        {
            b.Property(x => x.UnitCost).HasColumnType("decimal(12,0)");
            b.Property(x => x.Subtotal).HasColumnType("decimal(12,0)");
        });
    }
}
