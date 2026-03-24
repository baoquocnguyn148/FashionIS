using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
                    // Get the database file path
                    var dbPath = db.Database.GetDbConnection().DataSource;
                    Console.WriteLine($"[DB_INIT] SQLite path: {dbPath}");
                    
                    // 10. Global Query Filter fix - We no longer delete the DB on every start
                    // This was previously used for "Deep Clean" during development
                    // If you need to reset, delete the .db file manually from App_Data
                    
                    await db.Database.EnsureCreatedAsync();
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
                    var supplier = new Supplier { Name = "BN Supplier", Phone = "0000000000", Email = "supplier@bnstore.local", CreatedAt = DateTime.Now };
                    db.Categories.AddRange(catTops, catPants, catAcc);
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
                else
                {
                    // ADDITIVE SEEDING: Add new items if they don't exist
                    Console.WriteLine("[DB_INIT] Adding new diverse products...");

                    // Ensure all categories are available for seeding
                    var catTops = await db.Categories.FirstAsync(c => c.Slug == "tops");
                    var catPants = await db.Categories.FirstAsync(c => c.Slug == "pants");
                    var catAcc = await db.Categories.FirstAsync(c => c.Slug == "accessories");
                    var catOuter = await db.Categories.FirstOrDefaultAsync(c => c.Slug == "outerwear") 
                                  ?? new Category { Name = "Áo khoác", Slug = "outerwear", DisplayOrder = 4, CreatedAt = DateTime.Now };
                    var catFoot = await db.Categories.FirstOrDefaultAsync(c => c.Slug == "footwear")
                                 ?? new Category { Name = "Giày & Dép", Slug = "footwear", DisplayOrder = 5, CreatedAt = DateTime.Now };
                    var catDress = await db.Categories.FirstOrDefaultAsync(c => c.Slug == "dresses")
                                  ?? new Category { Name = "Váy & Đầm", Slug = "dresses", DisplayOrder = 6, CreatedAt = DateTime.Now };
                    
                    if (catOuter.Id == 0) db.Categories.Add(catOuter);
                    if (catFoot.Id == 0) db.Categories.Add(catFoot);
                    if (catDress.Id == 0) db.Categories.Add(catDress);
                    await db.SaveChangesAsync();

                    var supplier = await db.Suppliers.FirstAsync();
                    var currentStore = await db.Stores.FirstAsync();

                    async Task AddProductIfMissing(string name, string slug, int catId, decimal price, string img, string desc)
                    {
                        if (!await db.Products.AnyAsync(p => p.Slug == slug))
                        {
                            var p = new Product
                            {
                                Name = name, Slug = slug, CategoryId = catId, SupplierId = supplier.Id,
                                Price = price, ImageUrl = img, Description = desc, CreatedAt = DateTime.Now, IsActive = true
                            };
                            db.Products.Add(p);
                            await db.SaveChangesAsync();

                            // Add diverse SKUs
                            var sizes = catId == catFoot.Id ? new[] { "40", "41", "42" } : new[] { "S", "M", "L" };
                            foreach (var size in sizes)
                            {
                                var sku = new ProductSku
                                {
                                    ProductId = p.Id, SKU = $"{slug.ToUpper()}-{size}", SkuCode = $"{slug.Substring(0, 3).ToUpper()}-{size}",
                                    Color = "Default", Size = size, SellingPrice = price, CostPrice = price * 0.6m,
                                    Stock = 20, IsActive = true, CreatedAt = DateTime.Now
                                };
                                db.ProductSkus.Add(sku);
                                await db.SaveChangesAsync();

                                db.Inventories.Add(new Inventory
                                {
                                    ProductSkuId = sku.Id, StoreId = currentStore.Id, QuantityOnHand = 20,
                                    ReorderPoint = 5, MaxStockLevel = 100, LastUpdated = DateTime.Now, CreatedAt = DateTime.Now
                                });
                            }
                            await db.SaveChangesAsync();
                            p.Stock = 60; // 20 * 3
                            await db.SaveChangesAsync();
                            Console.WriteLine($"[DB_INIT] Added product: {name}");
                        }
                    }

                    await AddProductIfMissing("Áo Bomber Silver-lined", "bomber-jacket-silver", catOuter.Id, 599000, "/uploads/products/product_bomber.png", "Áo Bomber phong cách Streetwear, chất liệu dù cao cấp loại 1.");
                    await AddProductIfMissing("Denim Jacket Vintage", "denim-jacket-vintage", catOuter.Id, 650000, "/uploads/products/product_denim.png", "Áo khoác bò phong cách cổ điển, bền bỉ và thời thượng.");
                    await AddProductIfMissing("Áo Blazer Modern Fit", "blazer-modern-fit", catOuter.Id, 890000, "/uploads/products/product_blazer.png", "Blazer phom hiện đại, lịch lãm cho quý ông công sở.");
                    await AddProductIfMissing("Minimalist White Sneaker", "white-sneaker-minimalist", catFoot.Id, 1200000, "/uploads/products/product_sneakers.png", "Giày sneaker trắng tinh tế, da cao cấp, êm ái khi di chuyển.");
                    await AddProductIfMissing("Chelsea Boots Brown", "chelsea-boots-brown", catFoot.Id, 1500000, "/uploads/products/product_boots.png", "Giày Chelsea Boots da lộn màu nâu, phong cách quý ông sang trọng.");
                    await AddProductIfMissing("Floral Summer Midi Dress", "floral-summer-midi-dress", catDress.Id, 450000, "/uploads/products/product_dress.png", "Váy midi hoa nhí dịu dàng, vải voan nhẹ nhàng cho mùa hè.");

                    // MEGA EXPANSION: Ensure at least 10 products per category
                    Console.WriteLine("[DB_INIT] Mega Expansion: Checking product quotas...");
                    var categories = new[] { catTops, catPants, catAcc, catOuter, catFoot, catDress };
                    var fillerNames = new Dictionary<string, string[]>();
                    var fillerImages = new Dictionary<string, string[]>();

                    fillerNames["tops"] = new[] { "Oversized Graphic Tee", "Hoodie BN Streetwear", "Linen Summer Shirt", "Striped Polo Classic", "V-Neck Basic Tee" };
                    fillerImages["tops"] = new[] { 
                        "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1556821840-3a63f95609a7?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1596755094514-f87034a2612d?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1581655353564-df123a1eb820?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1523381235200-6294a1a98bd0?q=80&w=800&auto=format&fit=crop"
                    };

                    fillerNames["pants"] = new[] { "Chino Slim Fit", "Cargo Multi-pocket", "Skinny Black Jeans", "Techwear Joggers", "Linen Wide-leg Pants" };
                    fillerImages["pants"] = new[] {
                        "https://images.unsplash.com/photo-1624378439575-d8705ad7ae80?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1594633312681-425c7b97ccd1?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1541099649105-f69ad21f3246?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1552374196-1ab2a1c593e8?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1584308666744-24d5c474f2ae?q=80&w=800&auto=format&fit=crop"
                    };

                    fillerNames["accessories"] = new[] { "Urban Backpack", "Beanie Wool Hat", "Baseball Cap Classic", "Leather Slim Wallet", "Metal Link Necklace" };
                    fillerImages["accessories"] = new[] {
                        "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1576871337622-98d48d1cf531?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1588850561407-ed78c282e89b?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1627123424574-724758594e93?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1599643478518-a784e5dc4c8f?q=80&w=800&auto=format&fit=crop"
                    };

                    fillerNames["outerwear"] = new[] { "Windbreaker Tech", "Parka Winter Heavy", "Fleece Zip Jacket", "Trench Coat Modern", "Puffer Quilted Jacket" };
                    fillerImages["outerwear"] = new[] {
                        "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1539533377285-a76043126867?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1544923246-77307dd654ca?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1580657018950-c7f7d6a6d990?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1600185365483-26d7a4cc7519?q=80&w=800&auto=format&fit=crop"
                    };

                    fillerNames["footwear"] = new[] { 
                        "Pro Running Shoes Elite", "Premium Leather Loafers", "Urban Sporty Sandals", 
                        "Summer Comfort Flip-flops", "Rugged Combat Boots BN", "Desert Suede Boots", 
                        "High-top Street Sneaker", "Classic Brogue Oxford" 
                    };
                    fillerImages["footwear"] = new[] {
                        "https://images.unsplash.com/photo-1542291026-7eec264c27ff?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1614252235316-8c857d38b5f4?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1543163521-1bf539c55dd2?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1533681478291-0ad0c69ea268?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1608256246200-53e635b5b65f?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1520639889313-7272a74fw2ae?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1552346154-21d32810aba3?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1449505278894-297fdb3edbc1?q=80&w=800&auto=format&fit=crop"
                    };

                    fillerNames["dresses"] = new[] { "Maxi Floral Dress", "Bodycon Party Dress", "A-line Mini Skirt", "Pleated Midi Skirt", "Evening Silk Gown" };
                    fillerImages["dresses"] = new[] {
                        "https://images.unsplash.com/photo-1515372039744-b8f02a3ae446?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1595777457583-95e059d581b8?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1583337130417-3346a1be7dee?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1577900232427-18219b9166a0?q=80&w=800&auto=format&fit=crop",
                        "https://images.unsplash.com/photo-1566174053879-31528523f8ae?q=80&w=800&auto=format&fit=crop"
                    };

                    foreach (var cat in categories)
                    {
                        // Force update existing placeholders in this category to premium assets
                        if (fillerImages.TryGetValue(cat.Slug ?? "", out var catImages))
                        {
                            var placeholders = await db.Products
                                .Where(p => p.CategoryId == cat.Id && (p.ImageUrl.Contains("placehold.co") || p.ImageUrl.Contains("photo-1552374196-1ab2a1c593e8")))
                                .ToListAsync();

                            foreach (var p in placeholders)
                            {
                                string pName = p.Name?.ToLower() ?? "";
                                string slug = cat.Slug ?? "";

                                if (slug == "footwear")
                                {
                                    if (pName.Contains("sneaker") || pName.Contains("run")) p.ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?q=80&w=800";
                                    else if (pName.Contains("oxford") || pName.Contains("dress") || pName.Contains("leather") || pName.Contains("loafer")) p.ImageUrl = "https://images.unsplash.com/photo-1449505278894-297fdb3edbc1?q=80&w=800";
                                    else if (pName.Contains("boot")) p.ImageUrl = "https://images.unsplash.com/photo-1608256246200-53e635b5b65f?q=80&w=800";
                                    else if (pName.Contains("sandal") || pName.Contains("flip") || pName.Contains("slip-on")) p.ImageUrl = "https://images.unsplash.com/photo-1562273103-91206b930a68?q=80&w=800";
                                }
                                else if (slug == "dresses")
                                {
                                    if (pName.Contains("silk") || pName.Contains("evening") || pName.Contains("gown")) p.ImageUrl = "https://images.unsplash.com/photo-1566174053879-31528523f8ae?q=80&w=800";
                                    else if (pName.Contains("summer") || pName.Contains("floral") || pName.Contains("wrap")) p.ImageUrl = "https://images.unsplash.com/photo-1515372039744-b8f02a3ae446?q=80&w=800";
                                    else if (pName.Contains("satin") || pName.Contains("slip") || pName.Contains("cocktail")) p.ImageUrl = "https://images.unsplash.com/photo-1595777457583-95e059d581b8?q=80&w=800";
                                    else if (pName.Contains("skirt")) p.ImageUrl = "https://images.unsplash.com/photo-1583337130417-3346a1be7dee?q=80&w=800";
                                }
                                else if (slug == "outerwear")
                                {
                                    if (pName.Contains("bomber") || pName.Contains("wind")) p.ImageUrl = "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?q=80&w=800";
                                    else if (pName.Contains("trench") || pName.Contains("coat")) p.ImageUrl = "https://images.unsplash.com/photo-1580657018950-c7f7d6a6d990?q=80&w=800";
                                    else if (pName.Contains("leather")) p.ImageUrl = "https://images.unsplash.com/photo-1551028719-00167b16eac5?q=80&w=800";
                                }
                                else if (slug == "tops")
                                {
                                    if (pName.Contains("shirt") || pName.Contains("polo") || pName.Contains("linen")) p.ImageUrl = "https://images.unsplash.com/photo-1596755094514-f87034a2612d?q=80&w=800";
                                    else if (pName.Contains("tee") || pName.Contains("t-shirt") || pName.Contains("graphic")) p.ImageUrl = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?q=80&w=800";
                                    else if (pName.Contains("hoodie") || pName.Contains("sweat")) p.ImageUrl = "https://images.unsplash.com/photo-1556821840-3a63f95609a7?q=80&w=800";
                                }
                                else if (slug == "pants")
                                {
                                    if (pName.Contains("chino") || pName.Contains("slim") || pName.Contains("relaxed")) p.ImageUrl = "https://images.unsplash.com/photo-1624378439575-d8705ad7ae80?q=80&w=800";
                                    else if (pName.Contains("jean") || pName.Contains("denim")) p.ImageUrl = "https://images.unsplash.com/photo-1541099649105-f69ad21f3246?q=80&w=800";
                                    else if (pName.Contains("jogger") || pName.Contains("techwear") || pName.Contains("tracksuit") || pName.Contains("bottom")) p.ImageUrl = "https://images.unsplash.com/photo-1594633312681-425c7b97ccd1?q=80&w=800";
                                    else if (pName.Contains("pants") || pName.Contains("work") || pName.Contains("linen")) p.ImageUrl = "https://images.unsplash.com/photo-1594633313091-ef9f61b34e44?q=80&w=800";
                                }
                                else if (catImages.Length > 0)
                                {
                                    // Default to first image in category list if no keyword match
                                    p.ImageUrl = catImages[0];
                                }
                            }
                            await db.SaveChangesAsync();
                        }

                        var currentCount = await db.Products.CountAsync(p => p.CategoryId == cat.Id);
                        if (currentCount < 10)
                        {
                            int needed = 10 - currentCount;
                            Console.WriteLine($"[DB_INIT] Category '{cat.Name}' has {currentCount}. Adding {needed} more...");
                            if (fillerNames.TryGetValue(cat.Slug ?? "", out var names) && fillerImages.TryGetValue(cat.Slug ?? "", out var images))
                            {
                                for (int i = 0; i < needed && i < names.Length; i++)
                                {
                                    string name = names[i];
                                    string slug = name.ToLower().Replace(" ", "-").Replace("&", "and") + "-" + cat.Id;
                                    string img = i < images.Length ? images[i] : $"https://placehold.co/800x1000?text={name.Replace(" ", "+")}";
                                    string desc = $"Sản phẩm {name} thuộc bộ sưu tập mới nhất. Chất lượng cao cấp, thiết kế tỉ mỉ.";
                                    await AddProductIfMissing(name, slug, cat.Id, 250000 + (10000 * i), img, desc);
                                }
                            }
                        }
                    }
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
