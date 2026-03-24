using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FashionStoreIS.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSku> ProductSkus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<LoyaltyTransaction> LoyaltyTransactions { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var isOracle = Database.ProviderName?.Contains("Oracle", StringComparison.OrdinalIgnoreCase) == true;

            // 0. Naming Convention
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName == null) continue;
                var normalizedTableName = tableName.ToUpperInvariant();
                entity.SetTableName(normalizedTableName);

                foreach (var property in entity.GetProperties())
                {
                    var storeObject = StoreObjectIdentifier.Table(normalizedTableName, entity.GetSchema());
                    var columnName = property.GetColumnName(storeObject);
                    if (columnName != null) property.SetColumnName(columnName.ToUpperInvariant());
                }
            }
            
            if (isOracle)
                builder.HasSequence<long>("HILOSEQUENCE").IncrementsBy(1).StartsAt(1).IsCyclic(false);

            // 1. Identity Tables (Matching schema.sql)
            builder.Entity<ApplicationUser>(entity => {
                entity.ToTable("ASPNETUSERS");
                if (isOracle)
                {
                    entity.Property(e => e.Id).HasColumnName("ID").HasColumnType("VARCHAR2(450)");
                    entity.Property(e => e.UserName).HasColumnName("USERNAME").HasColumnType("VARCHAR2(256)");
                    entity.Property(e => e.NormalizedUserName).HasColumnName("NORMALIZEDUSERNAME").HasColumnType("VARCHAR2(256)");
                    entity.Property(e => e.Email).HasColumnName("EMAIL").HasColumnType("VARCHAR2(256)");
                    entity.Property(e => e.NormalizedEmail).HasColumnName("NORMALIZEDEMAIL").HasColumnType("VARCHAR2(256)");
                    entity.Property(e => e.EmailConfirmed).HasColumnName("EMAILCONFIRMED").HasColumnType("NUMBER(1)");
                    entity.Property(e => e.PasswordHash).HasColumnName("PASSWORDHASH").HasColumnType("VARCHAR2(2000)");
                    entity.Property(e => e.SecurityStamp).HasColumnName("SECURITYSTAMP").HasColumnType("VARCHAR2(2000)");
                    entity.Property(e => e.ConcurrencyStamp).HasColumnName("CONCURRENCYSTAMP").HasColumnType("VARCHAR2(2000)");
                    entity.Property(e => e.PhoneNumber).HasColumnName("PHONENUMBER").HasColumnType("VARCHAR2(2000)");
                    entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PHONENUMBERCONFIRMED").HasColumnType("NUMBER(1)");
                    entity.Property(e => e.TwoFactorEnabled).HasColumnName("TWOFACTORENABLED").HasColumnType("NUMBER(1)");
                    entity.Property(e => e.LockoutEnd).HasColumnName("LOCKOUTEND").HasColumnType("TIMESTAMP WITH TIME ZONE");
                    entity.Property(e => e.LockoutEnabled).HasColumnName("LOCKOUTENABLED").HasColumnType("NUMBER(1)");
                    entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESSFAILEDCOUNT").HasColumnType("NUMBER(10)");
                    entity.Property(e => e.FullName).HasColumnName("FULLNAME").HasColumnType("NVARCHAR2(100)");
                    entity.Property(e => e.Gender).HasColumnName("GENDER").HasColumnType("NVARCHAR2(20)");
                    entity.Property(e => e.AvatarUrl).HasColumnName("AVATARURL").HasColumnType("NVARCHAR2(2000)");
                    entity.Property(e => e.MembershipPoints).HasColumnName("MEMBERSHIPPOINTS").HasColumnType("NUMBER(10)");
                }
            });

            builder.Entity<IdentityRole>(entity => {
                entity.ToTable("ASPNETROLES");
                if (isOracle)
                {
                    entity.Property(e => e.Id).HasColumnName("ID").HasColumnType("VARCHAR2(450)");
                    entity.Property(e => e.Name).HasColumnName("NAME").HasColumnType("VARCHAR2(256)");
                    entity.Property(e => e.NormalizedName).HasColumnName("NORMALIZEDNAME").HasColumnType("VARCHAR2(256)");
                    entity.Property(e => e.ConcurrencyStamp).HasColumnName("CONCURRENCYSTAMP").HasColumnType("VARCHAR2(2000)");
                }
            });

            builder.Entity<IdentityUserRole<string>>(entity => {
                entity.ToTable("ASPNETUSERROLES");
                entity.Property(e => e.UserId).HasColumnName("USERID");
                entity.Property(e => e.RoleId).HasColumnName("ROLEID");
            });

            builder.Entity<IdentityUserClaim<string>>(entity => {
                entity.ToTable("ASPNETUSERCLAIMS");
                if (isOracle)
                    entity.Property(e => e.Id).HasColumnName("ID").UseHiLo("HILOSEQUENCE");
                else
                    entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.UserId).HasColumnName("USERID");
                entity.Property(e => e.ClaimType).HasColumnName("CLAIMTYPE");
                entity.Property(e => e.ClaimValue).HasColumnName("CLAIMVALUE");
            });

            builder.Entity<IdentityUserLogin<string>>(entity => {
                entity.ToTable("ASPNETUSERLOGINS");
                entity.Property(e => e.LoginProvider).HasColumnName("LOGINPROVIDER");
                entity.Property(e => e.ProviderKey).HasColumnName("PROVIDERKEY");
                entity.Property(e => e.UserId).HasColumnName("USERID");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity => {
                entity.ToTable("ASPNETROLECLAIMS");
                if (isOracle)
                    entity.Property(e => e.Id).HasColumnName("ID").UseHiLo("HILOSEQUENCE");
                else
                    entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.RoleId).HasColumnName("ROLEID");
            });

            builder.Entity<IdentityUserToken<string>>(entity => {
                entity.ToTable("ASPNETUSERTOKENS");
                entity.Property(e => e.UserId).HasColumnName("USERID");
                entity.Property(e => e.LoginProvider).HasColumnName("LOGINPROVIDER");
                entity.Property(e => e.Name).HasColumnName("NAME");
                entity.Property(e => e.Value).HasColumnName("VALUE");
            });

            // 2. Business Entities
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var b = builder.Entity(entityType.ClrType);
                    if (isOracle)
                        b.Property("Id").HasColumnName("ID").UseHiLo("HILOSEQUENCE");
                    else
                        b.Property("Id").HasColumnName("ID").ValueGeneratedOnAdd();
                    b.Property("CreatedAt").HasColumnName("CREATEDAT");
                    b.Property("UpdatedAt").HasColumnName("UPDATEDAT");
                    if (isOracle)
                        b.Property("IsDeleted").HasColumnName("ISDELETED").HasColumnType("NUMBER(1)");
                    else
                        b.Property("IsDeleted").HasColumnName("ISDELETED");

                    // 10. Global Query Filter for IsDeleted (Audit #32)
                    var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                    var propertyMethodInfo = typeof(Microsoft.EntityFrameworkCore.EF).GetMethod("Property")!.MakeGenericMethod(typeof(bool));
                    var isDeletedProperty = System.Linq.Expressions.Expression.Call(propertyMethodInfo, parameter, System.Linq.Expressions.Expression.Constant("IsDeleted"));
                    var compareExpression = System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType.Equal, isDeletedProperty, System.Linq.Expressions.Expression.Constant(false));
                    var lambda = System.Linq.Expressions.Expression.Lambda(compareExpression, parameter);
                    builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            builder.Entity<Category>(b => {
                b.ToTable("CATEGORIES");
                b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
                b.Property(x => x.Slug).HasColumnName("SLUG").HasMaxLength(150);
                b.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(500);
                b.Property(x => x.ImageUrl).HasColumnName("IMAGEURL").HasMaxLength(255);
                b.Property(x => x.DisplayOrder).HasColumnName("DISPLAYORDER").HasDefaultValue(0);
                b.Property(x => x.IsActive).HasColumnName("ISACTIVE").HasDefaultValue(true);
                b.Property(x => x.ParentCategoryId).HasColumnName("PARENTCATEGORYID");

                b.HasOne(x => x.ParentCategory)
                 .WithMany(x => x.SubCategories)
                 .HasForeignKey(x => x.ParentCategoryId)
                 .HasConstraintName("FK_CAT_PARENT");
            });

            builder.Entity<Supplier>(b => {
                b.ToTable("SUPPLIERS");
                b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(150).IsRequired();
                b.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(15);
                b.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(100);
            });

            builder.Entity<Product>(b => {
                b.ToTable("PRODUCTS");
                b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(150).IsRequired();
                b.Property(x => x.Slug).HasColumnName("SLUG").HasMaxLength(150).IsRequired();
                b.Property(x => x.Price).HasColumnName("PRICE").HasColumnType("NUMBER(12,2)");
                b.Property(x => x.Stock).HasColumnName("STOCK").HasColumnType("NUMBER(10)");
                b.Property(x => x.CategoryId).HasColumnName("CATEGORYID");
                b.Property(x => x.SupplierId).HasColumnName("SUPPLIERID");
                
                b.HasOne(x => x.Category).WithMany(c => c.Products).HasForeignKey(x => x.CategoryId).HasConstraintName("FK_PROD_CAT");
                b.HasOne(x => x.Supplier).WithMany(s => s.Products).HasForeignKey(x => x.SupplierId).HasConstraintName("FK_PROD_SUP");
            });

            builder.Entity<ProductSku>(b => {
                b.ToTable("PRODUCTSKUS");
                b.Property(x => x.SKU).HasColumnName("SKU").HasMaxLength(50);
                b.Property(x => x.SkuCode).HasColumnName("SKUCODE").HasMaxLength(30);
                b.Property(x => x.Size).HasColumnName("SIZE").HasMaxLength(10);
                b.Property(x => x.Color).HasColumnName("COLOR").HasMaxLength(50);
                b.Property(x => x.CostPrice).HasColumnName("COSTPRICE").HasColumnType("NUMBER(12,2)");
                b.Property(x => x.SellingPrice).HasColumnName("SELLINGPRICE").HasColumnType("NUMBER(12,2)");
                b.Property(x => x.PriceOverride).HasColumnName("PRICEOVERRIDE").HasColumnType("NUMBER(12,2)");
                b.Property(x => x.Stock).HasColumnName("STOCK").HasDefaultValue(0);
                
                // Dùng Stock làm concurrency token thay RowVersion
                b.Property(e => e.Stock).IsConcurrencyToken();
                
                b.HasOne(x => x.Product).WithMany(p => p.Skus).HasForeignKey(x => x.ProductId).HasConstraintName("FK_SKU_PROD");
            });

            builder.Entity<Customer>(b => {
                b.ToTable("CUSTOMERS");
                b.Property(x => x.FullName).HasColumnName("FULLNAME").HasMaxLength(100).IsRequired();
                b.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(15).IsRequired();
                b.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(100);
                
                b.HasOne(x => x.User).WithOne().HasForeignKey<Customer>(x => x.UserId).HasConstraintName("FK_CUST_USER");
            });

            builder.Entity<Store>(b => {
                b.ToTable("STORES");
                b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
                b.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(200);
                b.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(15);
            });

            builder.Entity<Employee>(b => {
                b.ToTable("EMPLOYEES");
                b.Property(x => x.FullName).HasColumnName("FULLNAME").HasMaxLength(100).IsRequired();
                b.Property(x => x.Position).HasColumnName("POSITION").HasMaxLength(50);
                b.HasOne(x => x.Store).WithMany().HasForeignKey(x => x.StoreId).HasConstraintName("FK_EMP_STORE");
            });

            builder.Entity<Order>(b => {
                b.ToTable("ORDERS");
                b.Property(x => x.OrderCode).HasColumnName("ORDERCODE").HasMaxLength(20).IsRequired();
                b.HasIndex(x => x.OrderCode).IsUnique();
                b.Property(x => x.SubTotal).HasColumnName("SUBTOTAL").HasColumnType("NUMBER(14,0)");
                b.Property(x => x.TotalAmount).HasColumnName("TOTALAMOUNT").HasColumnType("NUMBER(14,0)");
                b.Property(x => x.Status).HasColumnName("STATUS").HasConversion<byte>();
                
                // Nullable properties
                b.Property(e => e.Note).IsRequired(false);
                b.Property(e => e.CustomerName).IsRequired(false);
                b.Property(e => e.Phone).IsRequired(false);
                b.Property(e => e.Address).IsRequired(false);
                b.Property(e => e.UserId).IsRequired(false);
                b.Property(e => e.SubTotal).HasDefaultValue(0m);
                b.Property(e => e.DiscountAmount).HasDefaultValue(0m);
                b.Property(e => e.TotalAmount).HasDefaultValue(0m);
                b.Property(e => e.PointsEarned).HasDefaultValue(0);
                
                b.HasOne(x => x.Store).WithMany(s => s.Orders).HasForeignKey(x => x.StoreId).HasConstraintName("FK_ORD_STORE");
                b.HasOne(x => x.Customer)
                    .WithMany()
                    .HasForeignKey(x => x.CustomerId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Voucher)
                    .WithMany()
                    .HasForeignKey(x => x.VoucherId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(x => x.UserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderDetail>(b => {
                b.ToTable("ORDERDETAILS");
                b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasColumnType("NUMBER(12,0)");
                b.Property(x => x.Subtotal).HasColumnName("SUBTOTAL").HasColumnType("NUMBER(14,0)");
                
                // Nullable properties
                b.Property(e => e.ProductSkuId).IsRequired(false);
                b.Property(e => e.ProductId).IsRequired(false);
                b.Property(e => e.DiscountPercent).HasDefaultValue(0m);
                
                b.HasOne(x => x.Order).WithMany(o => o.OrderDetails).HasForeignKey(x => x.OrderId).HasConstraintName("FK_OD_ORD");
                b.HasOne(x => x.ProductSku)
                    .WithMany(s => s.OrderDetails)
                    .HasForeignKey(x => x.ProductSkuId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Product)
                    .WithMany()
                    .HasForeignKey(x => x.ProductId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Inventory>(b => {
                b.ToTable("INVENTORIES");
                b.HasOne(x => x.Store).WithMany(s => s.Inventories).HasForeignKey(x => x.StoreId).HasConstraintName("FK_INV_STORE");
                b.HasOne(x => x.ProductSku).WithMany(s => s.Inventories).HasForeignKey(x => x.ProductSkuId).HasConstraintName("FK_INV_SKU");
            });

            builder.Entity<StockAdjustment>(b => {
                b.ToTable("STOCKADJUSTMENTS");
                b.HasOne(x => x.Inventory).WithMany(i => i.StockAdjustments).HasForeignKey(x => x.InventoryId).HasConstraintName("FK_SA_INV");
            });

            builder.Entity<PurchaseOrder>(b => {
                b.ToTable("PURCHASEORDERS");
                b.Property(x => x.PoCode).HasColumnName("POCODE").HasMaxLength(20).IsRequired();
                b.Property(x => x.TotalCost).HasColumnName("TOTALCOST").HasColumnType("NUMBER(16,0)");
                b.HasOne(x => x.Supplier).WithMany(s => s.PurchaseOrders).HasForeignKey(x => x.SupplierId).HasConstraintName("FK_PO_SUP");
                b.HasOne(x => x.Store).WithMany().HasForeignKey(x => x.StoreId).HasConstraintName("FK_PO_STORE");
            });

            builder.Entity<PurchaseOrderDetail>(b => {
                b.ToTable("PURCHASEORDERDETAILS");
                b.Property(x => x.UnitCost).HasColumnName("UNITCOST").HasColumnType("NUMBER(12,0)");
                b.Property(x => x.Subtotal).HasColumnName("SUBTOTAL").HasColumnType("NUMBER(14,0)");
                b.HasOne(x => x.PurchaseOrder).WithMany(p => p.Details).HasForeignKey(x => x.PurchaseOrderId).HasConstraintName("FK_POD_PO");
                b.HasOne(x => x.ProductSku).WithMany().HasForeignKey(x => x.ProductSkuId).HasConstraintName("FK_POD_SKU");
            });

            builder.Entity<LoyaltyTransaction>(b => {
                b.ToTable("LOYALTYTRANSACTIONS");
                b.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).HasConstraintName("FK_LT_CUST");
            });

            builder.Entity<Banner>(b => {
                b.ToTable("BANNERS");
                if (isOracle)
                    b.Property(e => e.Id).UseHiLo("HILOSEQUENCE").HasColumnName("ID");
                else
                    b.Property(e => e.Id).HasColumnName("ID");
            });

            builder.Entity<Voucher>(b => {
                b.ToTable("VOUCHERS");
                if (isOracle)
                    b.Property(e => e.Id).UseHiLo("HILOSEQUENCE").HasColumnName("ID");
                else
                    b.Property(e => e.Id).HasColumnName("ID");
                
                b.Property(x => x.Code).HasColumnName("CODE").HasMaxLength(50).IsRequired();
                b.HasIndex(x => x.Code).IsUnique();
                b.Property(x => x.DiscountAmount).HasColumnName("DISCOUNTAMOUNT").HasColumnType("NUMBER(12,0)");
                b.Property(x => x.MinOrderAmount).HasColumnName("MINORDERAMOUNT").HasColumnType("NUMBER(12,0)");
                b.Property(x => x.ExpiryDate).HasColumnName("EXPIRYDATE");
                b.Property(x => x.IsActive).HasColumnName("ISACTIVE");
                b.Property(x => x.MaxUsageCount).HasColumnName("MAXUSAGECOUNT");
                b.Property(x => x.UsedCount).HasColumnName("USEDCOUNT");
            });


        }
    }
}
