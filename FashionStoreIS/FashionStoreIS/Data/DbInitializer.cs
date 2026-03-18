using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionStoreIS.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                Console.WriteLine("[DB_INIT] Starting Schema & Data Restoration...");

                // 1. Schema Creation
                var provider = db.Database.ProviderName ?? "";
                if (provider.Contains("Sqlite", StringComparison.OrdinalIgnoreCase))
                {
                    await db.Database.EnsureCreatedAsync();
                    
                    // Definitive fix for SQLite schema mismatch in dev:
                    // If the PRODUCTSKUID column is still NOT NULL, we drop and recreate the table.
                    using (var command = db.Database.GetDbConnection().CreateCommand())
                    {
                        await db.Database.OpenConnectionAsync();
                        command.CommandText = "SELECT \"notnull\" FROM pragma_table_info('ORDERDETAILS') WHERE name='PRODUCTSKUID'";
                        var result = await command.ExecuteScalarAsync();
                        if (result != null && Convert.ToInt32(result) == 1) // 1 means NOT NULL
                        {
                            Console.WriteLine("[DB_INIT] Fix schema: Dropping ORDERDETAILS to fix NOT NULL constraint...");
                            command.CommandText = "DROP TABLE ORDERDETAILS";
                            await command.ExecuteNonQueryAsync();
                            await db.Database.CloseConnectionAsync();
                            await db.Database.EnsureCreatedAsync(); // Recreate with correct schema
                        }
                        else { await db.Database.CloseConnectionAsync(); }
                    }
                }
                else if (provider.Contains("Oracle", StringComparison.OrdinalIgnoreCase))
                {
                    await db.Database.MigrateAsync();
                }

                // 2. Additive Role Seeding
                var roleNames = new[] { "SuperAdmin", "Staff", "User" };
                var currentRoles = await db.Roles.ToListAsync();
                foreach (var roleName in roleNames)
                {
                    var normalized = roleName.ToUpperInvariant();
                    if (!currentRoles.Any(r => r.NormalizedName == normalized))
                    {
                        var role = new IdentityRole(roleName) { NormalizedName = normalized };
                        var res = await roleManager.CreateAsync(role);
                        if (res.Succeeded) Console.WriteLine($"[DB_INIT] Role '{roleName}' seeded.");
                    }
                }

                // 3. Additive Admin Seeding
                var adminEmail = "admin@gmail.com";
                var adminPassword = Environment.GetEnvironmentVariable("ADMIN_DEFAULT_PASSWORD") ?? "Admin@123";
                
                var currentUsers = await db.Users.ToListAsync();
                if (!currentUsers.Any(u => u.Email == adminEmail))
                {
                    var admin = new ApplicationUser
                    {
                        UserName = adminEmail, Email = adminEmail,
                        NormalizedUserName = adminEmail.ToUpperInvariant(), NormalizedEmail = adminEmail.ToUpperInvariant(),
                        FullName = "Super Admin", EmailConfirmed = true, JoinDate = DateTime.UtcNow
                    };
                    var res = await userManager.CreateAsync(admin, adminPassword);
                    if (res.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "SuperAdmin");
                        Console.WriteLine("[DB_INIT] Admin user seeded.");
                    }
                }

                // 4. Premium UI Banners (Seed only if empty)
                var currentBanners = await db.Banners.ToListAsync();
                if (!currentBanners.Any())
                {
                    db.Banners.AddRange(
                        new Banner { Title = "NEW COLLECTION 2026", SubTitle = "FOR DREAMERS ONLY", ImageUrl = "/uploads/banners/12e9e97e-5dec-42ea-a0ae-968cb9cd2600.png", Position = "Hero", LinkUrl = "/Product/List", IsActive = true, DisplayOrder = 1, CreatedAt = DateTime.Now },
                        new Banner { Title = "ÁO", SubTitle = "PREMIUM TOPS", ImageUrl = "/uploads/banners/22b9c89d-fd22-4619-834e-47fbf529d1ee.png", Position = "Category1", LinkUrl = "/Product/List?cat=tops", IsActive = true, DisplayOrder = 2, CreatedAt = DateTime.Now }
                    );
                    await db.SaveChangesAsync();
                    Console.WriteLine("[DB_INIT] Banners seeded.");
                }
                
                // 5. Seed Store (always check if empty)
                var hasStore = await db.Stores.AnyAsync();
                Store store;
                if (!hasStore)
                {
                    store = new Store
                    {
                        Name = "BN Store - Default",
                        Address = "Hồ Chí Minh",
                        Phone = "0000000000",
                        ManagerName = "Admin",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    };
                    db.Stores.Add(store);
                    await db.SaveChangesAsync();
                    Console.WriteLine("[DB_INIT] Default store seeded.");
                }
                else
                {
                    store = await db.Stores.OrderBy(s => s.Id).FirstAsync();
                }

                // 6. Seed Categories, Supplier, Products for Dev/InMemory
                var hasProducts = await db.Products.AnyAsync();
                if (!hasProducts)
                {
                    var catTops = new Category { Name = "Áo", Slug = "tops", DisplayOrder = 1, CreatedAt = DateTime.Now };
                    var catPants = new Category { Name = "Quần", Slug = "pants", DisplayOrder = 2, CreatedAt = DateTime.Now };
                    var catAcc = new Category { Name = "Phụ kiện", Slug = "accessories", DisplayOrder = 3, CreatedAt = DateTime.Now };
                    db.Categories.AddRange(catTops, catPants, catAcc);
                    await db.SaveChangesAsync();

                    var supplier = new Supplier { Name = "BN Supplier", Phone = "0000000000", Email = "supplier@bnstore.local", CreatedAt = DateTime.Now };
                    db.Suppliers.Add(supplier);
                    await db.SaveChangesAsync();

                    static Product MakeProduct(string name, string slug, int catId, int supplierId, decimal price, string img)
                    {
                        return new Product
                        {
                            Name = name,
                            Slug = slug,
                            CategoryId = catId,
                            SupplierId = supplierId,
                            Price = price,
                            Stock = 0,
                            ImageUrl = img,
                            Description = "Chất liệu cao cấp, phom dáng hiện đại.",
                            CreatedAt = DateTime.Now,
                            IsActive = true
                        };
                    }

                    var p1 = MakeProduct("Áo thun BN Basic", "ao-thun-bn-basic", catTops.Id, supplier.Id, 199000, "https://placehold.co/800x1000?text=BN+Tee");
                    var p2 = MakeProduct("Áo polo BN Classic", "ao-polo-bn-classic", catTops.Id, supplier.Id, 299000, "https://placehold.co/800x1000?text=BN+Polo");
                    var p3 = MakeProduct("Quần jogger BN", "quan-jogger-bn", catPants.Id, supplier.Id, 349000, "https://placehold.co/800x1000?text=BN+Jogger");
                    var p4 = MakeProduct("Quần jeans BN Slim", "quan-jeans-bn-slim", catPants.Id, supplier.Id, 499000, "https://placehold.co/800x1000?text=BN+Jeans");
                    var p5 = MakeProduct("Thắt lưng BN Leather", "that-lung-bn-leather", catAcc.Id, supplier.Id, 259000, "https://placehold.co/800x1000?text=BN+Belt");
                    db.Products.AddRange(p1, p2, p3, p4, p5);
                    await db.SaveChangesAsync();

                    List<ProductSku> skus = new()
                    {
                        new ProductSku { ProductId = p1.Id, SKU = "TEE-BLACK-S", SkuCode = "TEE-BLK-S", Color = "Black", Size = "S", SellingPrice = p1.Price, CostPrice = 120000, Stock = 20, IsActive = true, CreatedAt = DateTime.Now },
                        new ProductSku { ProductId = p1.Id, SKU = "TEE-BLACK-M", SkuCode = "TEE-BLK-M", Color = "Black", Size = "M", SellingPrice = p1.Price, CostPrice = 120000, Stock = 30, IsActive = true, CreatedAt = DateTime.Now },
                        new ProductSku { ProductId = p1.Id, SKU = "TEE-WHITE-M", SkuCode = "TEE-WHT-M", Color = "White", Size = "M", SellingPrice = p1.Price, CostPrice = 120000, Stock = 25, IsActive = true, CreatedAt = DateTime.Now },
                        new ProductSku { ProductId = p2.Id, SKU = "POLO-NAVY-M", SkuCode = "POLO-NVY-M", Color = "Navy", Size = "M", SellingPrice = p2.Price, CostPrice = 180000, Stock = 15, IsActive = true, CreatedAt = DateTime.Now },
                        new ProductSku { ProductId = p3.Id, SKU = "JOGGER-BLACK-L", SkuCode = "JGR-BLK-L", Color = "Black", Size = "L", SellingPrice = p3.Price, CostPrice = 200000, Stock = 18, IsActive = true, CreatedAt = DateTime.Now },
                        new ProductSku { ProductId = p4.Id, SKU = "JEANS-INDIGO-32", SkuCode = "JNS-IND-32", Color = "Indigo", Size = "32", SellingPrice = p4.Price, CostPrice = 280000, Stock = 12, IsActive = true, CreatedAt = DateTime.Now },
                        new ProductSku { ProductId = p5.Id, SKU = "BELT-BROWN-100", SkuCode = "BLT-BRW-100", Color = "Brown", Size = "100", SellingPrice = p5.Price, CostPrice = 150000, Stock = 40, IsActive = true, CreatedAt = DateTime.Now }
                    };
                    foreach (var s in skus) db.ProductSkus.Add(s);
                    await db.SaveChangesAsync();

                    var skuIds = skus.Select(s => s.Id).ToList();
                    var existingInventorySkuIds = await db.Inventories
                        .Where(i => skuIds.Contains(i.ProductSkuId))
                        .Select(i => i.ProductSkuId)
                        .Distinct()
                        .ToListAsync();

                    foreach (var sku in skus)
                    {
                        if (existingInventorySkuIds.Contains(sku.Id)) continue;
                        db.Inventories.Add(new Inventory
                        {
                            ProductSkuId = sku.Id,
                            StoreId = store.Id,
                            QuantityOnHand = sku.Stock,
                            ReorderPoint = 10,
                            MaxStockLevel = 200,
                            LastUpdated = DateTime.Now,
                            CreatedAt = DateTime.Now
                        });
                    }
                    await db.SaveChangesAsync();

                    // Update stock aggregate
                    var prodIds = skus.GroupBy(s => s.ProductId).ToDictionary(g => g.Key, g => g.Sum(x => x.Stock));
                    var seededProds = await db.Products.Where(p => prodIds.Keys.Contains(p.Id)).ToListAsync();
                    foreach (var sp in seededProds) sp.Stock = prodIds[sp.Id];
                    await db.SaveChangesAsync();

                    // Seed Sample Voucher
                    if (!await db.Vouchers.AnyAsync())
                    {
                        db.Vouchers.Add(new Voucher
                        {
                            Code = "BNWELCOME",
                            DiscountAmount = 50000,
                            MinOrderAmount = 200000,
                            ExpiryDate = DateTime.Now.AddMonths(12),
                            IsActive = true,
                            CreatedAt = DateTime.Now
                        });
                        await db.SaveChangesAsync();
                    }

                    Console.WriteLine("[DB_INIT] Sample categories/products/SKUs/vouchers seeded.");
                }
                
                Console.WriteLine("[DB_INIT] Initialization successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB_INIT_FATAL] Error: {ex.Message}");
            }
        }
    }
}
