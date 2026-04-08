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

                // 1. Schema Synchronization
                var provider = db.Database.ProviderName ?? "";
                bool isPostgres = provider.Contains("Npgsql", StringComparison.OrdinalIgnoreCase);
                bool isSqlite = provider.Contains("Sqlite", StringComparison.OrdinalIgnoreCase);

                if (isPostgres)
                {
                    // For Postgres, we rely on Migrations already applied in Program.cs
                    Console.WriteLine("[DB_INIT] PostgreSQL detected. Using schema from migrations.");
                }
                else if (isSqlite)
                {
                    await db.Database.EnsureCreatedAsync();
                    var conn = db.Database.GetDbConnection();
                    if (conn.State != System.Data.ConnectionState.Open) await conn.OpenAsync();

                    var createTableCmds = new[]
                    {
                        @"CREATE TABLE IF NOT EXISTS USERADDRESSES (ID INTEGER PRIMARY KEY AUTOINCREMENT, USERID TEXT NOT NULL, FULLNAME TEXT NOT NULL, PHONENUMBER TEXT NOT NULL, ADDRESSLINE TEXT NOT NULL, ISDEFAULT INTEGER NOT NULL DEFAULT 0, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0)",
                        @"CREATE TABLE IF NOT EXISTS RETURNREQUESTS (ID INTEGER PRIMARY KEY AUTOINCREMENT, ORDERID INTEGER NOT NULL, REASON TEXT NOT NULL, STATUS INTEGER NOT NULL DEFAULT 0, REFUNDAMOUNT REAL NOT NULL DEFAULT 0, ADMINNOTE TEXT, PROCESSEDAT TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(ORDERID) REFERENCES ORDERS(ID))",
                        @"CREATE TABLE IF NOT EXISTS NOTIFICATIONS (ID INTEGER PRIMARY KEY AUTOINCREMENT, USERID TEXT NOT NULL, TITLE TEXT NOT NULL, MESSAGE TEXT NOT NULL, ISREAD INTEGER NOT NULL DEFAULT 0, ACTIONURL TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0)",
                        @"CREATE TABLE IF NOT EXISTS CAMPAIGNS (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT NOT NULL, DESCRIPTION TEXT, STARTDATE TEXT NOT NULL, ENDDATE TEXT NOT NULL, TARGETSEGMENT TEXT NOT NULL, VOUCHERID INTEGER, NOTIFICATIONTITLE TEXT NOT NULL, NOTIFICATIONMESSAGE TEXT NOT NULL, ISSENT INTEGER NOT NULL DEFAULT 0, SENTAT TEXT, RECIPIENTCOUNT INTEGER NOT NULL DEFAULT 0, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(VOUCHERID) REFERENCES VOUCHERS(ID))",
                        @"CREATE TABLE IF NOT EXISTS WISHLISTITEMS (ID INTEGER PRIMARY KEY AUTOINCREMENT, USERID TEXT NOT NULL, PRODUCTID INTEGER NOT NULL, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(USERID) REFERENCES ASPNETUSERS(ID), FOREIGN KEY(PRODUCTID) REFERENCES PRODUCTS(ID), UNIQUE(USERID, PRODUCTID))",
                        
                        // HRM & Payroll Tables
                        @"CREATE TABLE IF NOT EXISTS DEPARTMENTS (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT NOT NULL, DESCRIPTION TEXT, ISACTIVE INTEGER NOT NULL DEFAULT 1, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0)",
                        @"CREATE TABLE IF NOT EXISTS ATTENDANCES (ID INTEGER PRIMARY KEY AUTOINCREMENT, EMPLOYEEID INTEGER NOT NULL, DATE TEXT NOT NULL, CHECKIN TEXT, CHECKOUT TEXT, TOTALHOURS REAL NOT NULL DEFAULT 0, STATUS INTEGER NOT NULL, NOTE TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(EMPLOYEEID) REFERENCES EMPLOYEES(ID))",
                        @"CREATE TABLE IF NOT EXISTS LEAVEREQUESTS (ID INTEGER PRIMARY KEY AUTOINCREMENT, EMPLOYEEID INTEGER NOT NULL, STARTDATE TEXT NOT NULL, ENDDATE TEXT NOT NULL, TYPE INTEGER NOT NULL, STATUS INTEGER NOT NULL DEFAULT 1, REASON TEXT, ADMINNOTE TEXT, APPROVEDBYID TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(EMPLOYEEID) REFERENCES EMPLOYEES(ID))",
                        @"CREATE TABLE IF NOT EXISTS SALARYCOMPONENTS (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT NOT NULL, TYPE INTEGER NOT NULL, DEFAULTAMOUNT REAL NOT NULL DEFAULT 0, DESCRIPTION TEXT, ISACTIVE INTEGER NOT NULL DEFAULT 1, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0)",
                        @"CREATE TABLE IF NOT EXISTS PAYROLLS (ID INTEGER PRIMARY KEY AUTOINCREMENT, EMPLOYEEID INTEGER NOT NULL, MONTH INTEGER NOT NULL, YEAR INTEGER NOT NULL, TOTALHOURSWORKED REAL NOT NULL DEFAULT 0, BASEHOURLYRATE REAL NOT NULL DEFAULT 0, TOTALBASESALARY REAL NOT NULL DEFAULT 0, TOTALADDITIONS REAL NOT NULL DEFAULT 0, TOTALDEDUCTIONS REAL NOT NULL DEFAULT 0, NETSALARY REAL NOT NULL DEFAULT 0, STATUS INTEGER NOT NULL DEFAULT 1, PROCESSEDDATE TEXT, NOTE TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(EMPLOYEEID) REFERENCES EMPLOYEES(ID))",
                        @"CREATE TABLE IF NOT EXISTS PAYROLLITEMS (ID INTEGER PRIMARY KEY AUTOINCREMENT, PAYROLLID INTEGER NOT NULL, SALARYCOMPONENTID INTEGER, AMOUNT REAL NOT NULL DEFAULT 0, NOTE TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(PAYROLLID) REFERENCES PAYROLLS(ID), FOREIGN KEY(SALARYCOMPONENTID) REFERENCES SALARYCOMPONENTS(ID))",
                        @"CREATE TABLE IF NOT EXISTS SHIFTS (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT NOT NULL, STARTTIME TEXT NOT NULL, ENDTIME TEXT NOT NULL, STOREID INTEGER NOT NULL, ISACTIVE INTEGER NOT NULL DEFAULT 1, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(STOREID) REFERENCES STORES(ID))",
                        @"CREATE TABLE IF NOT EXISTS SCHEDULES (ID INTEGER PRIMARY KEY AUTOINCREMENT, EMPLOYEEID INTEGER NOT NULL, SHIFTID INTEGER NOT NULL, DATE TEXT NOT NULL, STATUS INTEGER NOT NULL DEFAULT 1, NOTE TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(EMPLOYEEID) REFERENCES EMPLOYEES(ID), FOREIGN KEY(SHIFTID) REFERENCES SHIFTS(ID))",
                        @"CREATE TABLE IF NOT EXISTS KPIREVIEWS (ID INTEGER PRIMARY KEY AUTOINCREMENT, EMPLOYEEID INTEGER NOT NULL, REVIEWERID TEXT NOT NULL, MONTH INTEGER NOT NULL, YEAR INTEGER NOT NULL, SALESSCORE REAL NOT NULL DEFAULT 0, ATTITUDESCORE REAL NOT NULL DEFAULT 0, TEAMWORKSCORE REAL NOT NULL DEFAULT 0, TOTALSCORE REAL NOT NULL DEFAULT 0, RANK INTEGER NOT NULL, NOTES TEXT, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(EMPLOYEEID) REFERENCES EMPLOYEES(ID), FOREIGN KEY(REVIEWERID) REFERENCES ASPNETUSERS(ID))",
                        @"CREATE TABLE IF NOT EXISTS LEAVEBALANCES (ID INTEGER PRIMARY KEY AUTOINCREMENT, EMPLOYEEID INTEGER NOT NULL, YEAR INTEGER NOT NULL, ANNUALDAYSTOTAL INTEGER NOT NULL DEFAULT 12, ANNUALDAYSUSED INTEGER NOT NULL DEFAULT 0, SICKDAYSTOTAL INTEGER NOT NULL DEFAULT 5, SICKDAYSUSED INTEGER NOT NULL DEFAULT 0, CREATEDAT TEXT NOT NULL DEFAULT (datetime('now')), UPDATEDAT TEXT, ISDELETED INTEGER NOT NULL DEFAULT 0, FOREIGN KEY(EMPLOYEEID) REFERENCES EMPLOYEES(ID))",

                        // Patch EMPLOYEES with new columns
                        @"ALTER TABLE EMPLOYEES ADD COLUMN BASESALARYPERHOUR REAL NOT NULL DEFAULT 0",
                        @"ALTER TABLE EMPLOYEES ADD COLUMN BANKACCOUNTNUMBER TEXT",
                        @"ALTER TABLE EMPLOYEES ADD COLUMN BANKNAME TEXT",
                        @"ALTER TABLE EMPLOYEES ADD COLUMN BANKACCOUNTNAME TEXT",
                        @"ALTER TABLE EMPLOYEES ADD COLUMN DEPARTMENTID INTEGER REFERENCES DEPARTMENTS(ID)"
                    };

                    foreach (var sql in createTableCmds)
                    {
                        try
                        {
                            using var cmd = conn.CreateCommand();
                            cmd.CommandText = sql;
                            await cmd.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            // Ignore if column already exists (Sqlite does not support IF NOT EXISTS for ADD COLUMN)
                            Console.WriteLine($"[DB_INIT_PATCH] Info: {ex.Message}");
                        }
                    }
                }

                // 2. Roles
                var roleNames = new[] { "SuperAdmin", "Staff", "User" };
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // 3. Admin User
                var adminEmail = "admin@gmail.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, FullName = "Super Admin", EmailConfirmed = true, JoinDate = DateTime.UtcNow };
                    var res = await userManager.CreateAsync(admin, "Admin@123");
                    if (res.Succeeded) await userManager.AddToRoleAsync(admin, "SuperAdmin");
                }

                // 4. Seeding Products & Banners (Baseline) - Aggressive Auto-Purge for Broken Assets
                bool hasBrokenBanners = await db.Banners.AnyAsync(b => b.ImageUrl.Contains("/uploads/") || b.ImageUrl.Contains("placehold.co"));
                bool hasBrokenProducts = await db.Products.AnyAsync(p => p.ImageUrl != null && (p.ImageUrl.Contains("/uploads/") || p.ImageUrl.Contains("placehold.co")));

                if (hasBrokenBanners || hasBrokenProducts || !await db.Banners.AnyAsync() || !await db.Products.AnyAsync())
                {
                    Console.WriteLine("[DB_INIT] Found broken local paths or empty DB. Purging for fresh seed...");
                    
                    // Purge Banners
                    var allBanners = await db.Banners.ToListAsync();
                    db.Banners.RemoveRange(allBanners);

                    // Purge Products & Related
                    var allSkus = await db.ProductSkus.ToListAsync();
                    db.ProductSkus.RemoveRange(allSkus);
                    
                    var allImages = await db.ProductImages.ToListAsync();
                    db.ProductImages.RemoveRange(allImages);

                    var allProducts = await db.Products.ToListAsync();
                    db.Products.RemoveRange(allProducts);

                    // Purge Categories to avoid slug conflicts
                    var allCats = await db.Categories.ToListAsync();
                    db.Categories.RemoveRange(allCats);
                    
                    await db.SaveChangesAsync();
                    Console.WriteLine("[DB_INIT] Old data purged completely.");

                    // --- RE-SEED DATA ---
                    
                    // 1. Banners
                    db.Banners.AddRange(
                        new Banner { Title = "NEW COLLECTION 2026", SubTitle = "FOR DREAMERS ONLY", ImageUrl = "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=1400&q=80", Position = "Hero", LinkUrl = "/Product/List", IsActive = true, DisplayOrder = 1, CreatedAt = DateTime.UtcNow },
                        new Banner { Title = "PREMIUM TOPS", SubTitle = "ESSENTIALS", ImageUrl = "https://images.unsplash.com/photo-1523381210434-271e8be1f52b?w=1400&q=80", Position = "Category1", LinkUrl = "/Product/List?cat=tops", IsActive = true, DisplayOrder = 2, CreatedAt = DateTime.UtcNow }
                    );

                    // 2. Categories
                    var catTops    = new Category { Name = "Áo",    Slug = "tops",    DisplayOrder = 1, CreatedAt = DateTime.UtcNow };
                    var catPants   = new Category { Name = "Quần",  Slug = "pants",   DisplayOrder = 2, CreatedAt = DateTime.UtcNow };
                    var catOuter   = new Category { Name = "Áo Khoác", Slug = "outerwear", DisplayOrder = 3, CreatedAt = DateTime.UtcNow };
                    var catAccess  = new Category { Name = "Phụ Kiện", Slug = "accessories", DisplayOrder = 4, CreatedAt = DateTime.UtcNow };
                    db.Categories.AddRange(catTops, catPants, catOuter, catAccess);

                    // 3. Supplier (Get existing or create)
                    var supplier = await db.Suppliers.FirstOrDefaultAsync() ?? new Supplier { Name = "Main Supplier", Phone = "0900000000", Email = "supplier@main.local", CreatedAt = DateTime.UtcNow };
                    if (supplier.Id == 0) db.Suppliers.Add(supplier);
                    
                    await db.SaveChangesAsync();

                    // 4. Products with high-quality local images
                    var products = new List<Product>
                    {
                        new Product { Name = "Áo Thun BN Blank Black",    Slug = "ao-thun-blank-black", CategoryId = catTops.Id,  SupplierId = supplier.Id, Price = 350000, Description = "Premium cotton blank black shirt", ImageUrl = "/images/products/BLANKSHIRTBLACK_main.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Áo Thun BN Blank White",    Slug = "ao-thun-blank-white", CategoryId = catTops.Id,  SupplierId = supplier.Id, Price = 350000, Description = "Premium cotton blank white shirt", ImageUrl = "/images/products/BlankShirtWhite_main.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Áo Coach Shirt Green",      Slug = "coach-shirt-green",   CategoryId = catTops.Id,  SupplierId = supplier.Id, Price = 450000, Description = "Modern coach shirt in vibrant green", ImageUrl = "/images/products/COACHSHIRT-GREEN_main.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Áo Sweater Gray FW25",       Slug = "sweater-gray-fw25",   CategoryId = catTops.Id,  SupplierId = supplier.Id, Price = 590000, Description = "Winter 2025 Oversize Sweater", ImageUrl = "/images/products/FW25OSMSWEATER_GRAY_main.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        
                        new Product { Name = "Quần Tracksuit Coach",      Slug = "tracksuit-pant-coach", CategoryId = catPants.Id, SupplierId = supplier.Id, Price = 550000, Description = "Comfortable tracksuit pants", ImageUrl = "/images/products/Coachtracksuitpant.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Quần Sport Sweatpant Gray", Slug = "sport-sweatpant-gray", CategoryId = catPants.Id, SupplierId = supplier.Id, Price = 420000, Description = "Sporty gray sweatpants", ImageUrl = "/images/products/sportsweetpant_gray.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Quần Vital Trank Blue",     Slug = "vital-trank-blue",    CategoryId = catPants.Id, SupplierId = supplier.Id, Price = 480000, Description = "Vital edition blue trank pants", ImageUrl = "/images/products/vitaltrankpants_blue.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Quần Vital Trank Red",      Slug = "vital-trank-red",     CategoryId = catPants.Id, SupplierId = supplier.Id, Price = 480000, Description = "Vital edition red trank pants", ImageUrl = "/images/products/vitaltrankpants_red.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        
                        new Product { Name = "Áo Bomber BN S-Black",      Slug = "bomber-s-black",      CategoryId = catOuter.Id, SupplierId = supplier.Id, Price = 890000, Description = "S-Class Black Bomber Jacket", ImageUrl = "/images/products/BlackSBomber.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Áo Hoodie Jeans Zip Black", Slug = "hoodie-jeans-zip",    CategoryId = catOuter.Id, SupplierId = supplier.Id, Price = 750000, Description = "Black Zip Hoodie Jeans Style", ImageUrl = "/images/products/W25SSMAJEANSZIPHOODIE_BLACK_main.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        
                        new Product { Name = "Túi Da Cowhide Black",       Slug = "cowhide-bag-black",   CategoryId = catAccess.Id, SupplierId = supplier.Id, Price = 1200000, Description = "Premium embossed black cowhide leather bag", ImageUrl = "/images/products/COWHIDELEATHERBAG-EMBOSSEDBLACK.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Túi Da Cowhide White",       Slug = "cowhide-bag-white",   CategoryId = catAccess.Id, SupplierId = supplier.Id, Price = 1200000, Description = "Premium embossed white cowhide leather bag", ImageUrl = "/images/products/COWHIDELEATHERBAG-EMBOSSEDWHITE.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Túi Da Cowhide Brown",       Slug = "cowhide-bag-brown",   CategoryId = catAccess.Id, SupplierId = supplier.Id, Price = 1350000, Description = "Hairon brown cowhide leather bag", ImageUrl = "/images/products/COWHIDELEATHERBAG-HAIRON BROWN.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Mũ Papa Cap Red",            Slug = "papa-cap-red",        CategoryId = catAccess.Id, SupplierId = supplier.Id, Price = 250000, Description = "Classic red papa cap", ImageUrl = "/images/products/Papacap_red.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                        new Product { Name = "Mũ IGIFMS Cap",               Slug = "igifms-cap",          CategoryId = catAccess.Id, SupplierId = supplier.Id, Price = 290000, Description = "Limited edition IGIFMS cap", ImageUrl = "/images/products/igifms_cap.png", CreatedAt = DateTime.UtcNow, IsActive = true },
                    };
                    db.Products.AddRange(products);
                    await db.SaveChangesAsync();

                    // Add SKUs for each product
                    var sizes = new[] { "S", "M", "L", "XL" };
                    var colors = new[] { "Black", "White", "Navy" };
                    var rndSku = new Random();
                    var skusToAdd = new List<ProductSku>();

                    foreach (var p in products)
                    {
                        foreach (var size in sizes)
                        {
                            skusToAdd.Add(new ProductSku
                            {
                                ProductId = p.Id,
                                SKU = $"{p.Slug.ToUpper()[..Math.Min(8, p.Slug.Length)]}-{size}",
                                SkuCode = $"{p.Slug.ToUpper()[..Math.Min(8, p.Slug.Length)]}-{size}",
                                Color = colors[rndSku.Next(colors.Length)],
                                Size = size,
                                SellingPrice = p.Price,
                                CostPrice = p.Price * 0.5m,
                                Stock = rndSku.Next(20, 100),
                                IsActive = true,
                                CreatedAt = DateTime.UtcNow
                            });
                        }
                    }
                    db.ProductSkus.AddRange(skusToAdd);
                    await db.SaveChangesAsync();
                }

                // 5. CRM Data Seed (only if not seeded)
                if (!await db.Users.AnyAsync(u => u.Email != null && u.Email.Contains("@samplecrm.com")))
                {
                    await SeedSampleCrmData(db, userManager);
                }

                // 6. Professional HRM & Payroll Data Seed
                await SeedHrmData(db, userManager);

                Console.WriteLine("[DB_INIT] Initialization successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB_INIT_FATAL] Error: {ex.Message}");
                throw;
            }
        }

        public static async Task SeedSampleCrmData(ApplicationDbContext db, UserManager<ApplicationUser> userManager, bool append = false)
        {
            if (!append)
            {
                Console.WriteLine("[DB_INIT] >>> Phase 1: Robust Purge & Clean <<<");

                // 1. Identification & Purge (Ensure clean slate for sample CRM)
                var sampleUsers = await db.Users.Where(u => u.Email != null && u.Email.Contains("@samplecrm.com")).ToListAsync();
            var sampleUserIds = sampleUsers.Select(u => u.Id).ToList();

            if (sampleUserIds.Any())
            {
                Console.WriteLine($"[DB_INIT] Found {sampleUserIds.Count} legacy sample users. Wiping all related history...");

                var orders = await db.Orders.Where(o => sampleUserIds.Contains(o.UserId ?? "")).ToListAsync();
                var orderIds = orders.Select(o => o.Id).ToList();
                if (orderIds.Any())
                {
                    var details = await db.OrderDetails.Where(od => orderIds.Contains(od.OrderId)).ToListAsync();
                    db.OrderDetails.RemoveRange(details);
                    db.Orders.RemoveRange(orders);
                }

                var customers = await db.Customers.Where(c => sampleUserIds.Contains(c.UserId ?? "")).ToListAsync();
                var customerIds = customers.Select(c => c.Id).ToList();
                if (customerIds.Any())
                {
                    var loyalty = await db.LoyaltyTransactions.Where(lt => customerIds.Contains(lt.CustomerId)).ToListAsync();
                    db.LoyaltyTransactions.RemoveRange(loyalty);
                    db.Customers.RemoveRange(customers);
                }

                var notifs = await db.Notifications.Where(n => sampleUserIds.Contains(n.UserId ?? "")).ToListAsync();
                db.Notifications.RemoveRange(notifs);

                await db.SaveChangesAsync();

                foreach (var user in sampleUsers)
                {
                    await userManager.DeleteAsync(user);
                }
                Console.WriteLine("[DB_INIT] Purge Completed.");
            }
            }

        // Database Provider Connectivity Check
            var provider = db.Database.ProviderName ?? "";
            bool isPostgres = provider.Contains("Npgsql", StringComparison.OrdinalIgnoreCase);

            Console.WriteLine($"[DB_INIT] Using provider: {provider}");

            // 2. Foundation Verification
            var store = await db.Stores.FirstOrDefaultAsync();
            if (store == null)
            {
                store = new Store { Name = "BN Fashion Flagship", Address = "HCM", Phone = "0900000000", ManagerName = "Admin", IsActive = true };
                db.Stores.Add(store);
                await db.SaveChangesAsync();
            }

            var skus = await db.ProductSkus.Where(s => !s.IsDeleted).ToListAsync();
            if (!skus.Any())
            {
                throw new Exception("Không tìm thấy dữ liệu Sản phẩm/SKU. Vui lòng nạp Sản phẩm trước khi nạp CRM.");
            }

            // 3. Strategic Seeding (20 High-Quality Profiles)
            var sampleCusList = new (string name, string email, DateTime join, string avatar, string phone)[]
            {
                ("Nguyễn Quốc Bảo",   "bao.nq@samplecrm.com",  DateTime.UtcNow.AddMonths(-12), "https://i.pravatar.cc/150?u=1", "0901234567"),
                ("Trần Lê Minh",    "minh.tl@samplecrm.com", DateTime.UtcNow.AddMonths(-11), "https://i.pravatar.cc/150?u=2", "0901234568"),
                ("Phạm Hương Ly",   "ly.ph@samplecrm.com",   DateTime.UtcNow.AddMonths(-10), "https://i.pravatar.cc/150?u=3", "0901234569"),
                ("Lê Hoàng Dũng",   "dung.lh@samplecrm.com",  DateTime.UtcNow.AddMonths(-9),  "https://i.pravatar.cc/150?u=4", "0901234570"),
                ("Vũ Thành Trung",  "trung.vt@samplecrm.com", DateTime.UtcNow.AddMonths(-8),  "https://i.pravatar.cc/150?u=5", "0901234571"),
                ("Đặng Thu Thảo",   "thao.dt@samplecrm.com",  DateTime.UtcNow.AddMonths(-7),  "https://i.pravatar.cc/150?u=6", "0901234572"),
                ("Ngô Chí Hùng",    "hung.nc@samplecrm.com",  DateTime.UtcNow.AddMonths(-6),  "https://i.pravatar.cc/150?u=7", "0901234573"),
                ("Bùi Diệu Nhi",    "nhi.bd@samplecrm.com",   DateTime.UtcNow.AddMonths(-5),  "https://i.pravatar.cc/150?u=8", "0901234574"),
                ("Lý Quang Diệu",   "dieu.lq@samplecrm.com",  DateTime.UtcNow.AddMonths(-4),  "https://i.pravatar.cc/150?u=9", "0901234575"),
                ("Hồ Ngọc Hà",      "ha.hn@samplecrm.com",    DateTime.UtcNow.AddMonths(-3),  "https://i.pravatar.cc/150?u=10", "0901234576"),
                ("Trịnh Gia Bảo",   "bao.tg@samplecrm.com",   DateTime.UtcNow.AddMonths(-11), "https://i.pravatar.cc/150?u=11", "0901234577"),
                ("Mai Phương Thúy", "thuy.mp@samplecrm.com",  DateTime.UtcNow.AddMonths(-10), "https://i.pravatar.cc/150?u=12", "0901234578"),
                ("Nguyễn Cao Kỳ", "ky.nc@samplecrm.com",  DateTime.UtcNow.AddMonths(-9),  "https://i.pravatar.cc/150?u=13", "0901234579"),
                ("Thái Công Vinh",  "vinh.tc@samplecrm.com",  DateTime.UtcNow.AddMonths(-8),  "https://i.pravatar.cc/150?u=14", "0901234580"),
                ("Lương Bằng Quang","quang.lb@samplecrm.com", DateTime.UtcNow.AddMonths(-7),  "https://i.pravatar.cc/150?u=15", "0901234581"),
                ("Võ Hạ Trâm",      "tram.vh@samplecrm.com",  DateTime.UtcNow.AddMonths(-6),  "https://i.pravatar.cc/150?u=16", "0901234582"),
                ("Đào Anh Tuấn",    "tuan.da@samplecrm.com",  DateTime.UtcNow.AddMonths(-5),  "https://i.pravatar.cc/150?u=17", "0901234583"),
                ("Kiều Minh Tuấn",  "tuan.km@samplecrm.com",  DateTime.UtcNow.AddMonths(-4),  "https://i.pravatar.cc/150?u=18", "0901234584"),
                ("Trần Ngọc Trinh", "trinh.tn@samplecrm.com", DateTime.UtcNow.AddMonths(-3),  "https://i.pravatar.cc/150?u=19", "0901234585"),
                ("Nguyễn Quang Hải","hai.nq@samplecrm.com",   DateTime.UtcNow.AddMonths(-2),  "https://i.pravatar.cc/150?u=20", "0901234586")
            };

            string suffix = append ? $"+{DateTime.UtcNow.Ticks}@samplecrm.com" : "@samplecrm.com";

            Random rnd = new Random();
            foreach (var s in sampleCusList)
            {
                string uniqueEmail = s.email.Replace("@samplecrm.com", suffix);
                try {
                    var user = new ApplicationUser { 
                        UserName = uniqueEmail, Email = uniqueEmail, FullName = s.name, 
                        JoinDate = s.join, AvatarUrl = s.avatar, EmailConfirmed = true, 
                        MembershipPoints = rnd.Next(100, 2000) 
                    };
                    
                    var res = await userManager.CreateAsync(user, "User@123");
                    if (res.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "User");
                        
                        // IMPORTANT: Set ALL required fields for Customer
                        var customer = new Customer { 
                            UserId = user.Id, 
                            FullName = s.name,
                            Email = uniqueEmail,
                            Phone = s.phone,
                            Address = "Hồ Chí Minh, Việt Nam",
                            LoyaltyPoints = user.MembershipPoints,
                            JoinDate = s.join,
                            Tier = user.MembershipPoints >= 1000 ? 2 : (user.MembershipPoints >= 500 ? 1 : 0)
                        };
                        db.Customers.Add(customer);
                        await db.SaveChangesAsync();

                        // Orders Seeding (3 to 12 orders per user)
                        int orderCount = rnd.Next(3, 13);
                        var userOrders = new List<Order>();
                        for (int i = 0; i < orderCount; i++)
                        {
                            DateTime orderDate = s.join.AddDays(rnd.Next(0, (int)(DateTime.UtcNow - s.join).TotalDays));
                            var orderStatus = (OrderStatus)rnd.Next(1, 7); // Range 1-6
                            
                            var order = new Order {
                                UserId = user.Id, 
                                CustomerId = customer.Id, 
                                StoreId = store.Id,
                                OrderCode = $"BN-{rnd.Next(1000, 9999)}-{Guid.NewGuid().ToString().Substring(0,4).ToUpper()}", 
                                CreatedAt = orderDate,
                                Status = orderStatus, 
                                PaymentMethod = (PaymentMethod)rnd.Next(1, 4),
                                PaymentStatus = (orderStatus == OrderStatus.Completed || orderStatus == OrderStatus.Shipped) ? PaymentStatus.Paid : PaymentStatus.Unpaid,
                                CustomerName = user.FullName, 
                                Phone = s.phone,
                                Address = "Quận 1, TP. Hồ Chí Minh",
                                OrderDetails = new List<OrderDetail>()
                            };

                            // 1 to 5 SKUs per order
                            int itemsCount = rnd.Next(1, 6);
                            decimal total = 0;
                            for (int j = 0; j < itemsCount; j++)
                            {
                                var sku = skus[rnd.Next(skus.Count)];
                                var qty = rnd.Next(1, 4);
                                var price = sku.PriceOverride > 0 ? sku.PriceOverride.Value : sku.SellingPrice;
                                
                                order.OrderDetails.Add(new OrderDetail { 
                                    ProductSkuId = sku.Id, 
                                    ProductId = sku.ProductId, 
                                    Quantity = qty, 
                                    UnitPrice = price,
                                    Subtotal = price * qty
                                });
                                total += (price * qty);
                            }
                            order.SubTotal = total; 
                            order.TotalAmount = total;
                            userOrders.Add(order);
                        }
                        db.Orders.AddRange(userOrders);

                        // Loyalty & Notifications
                        db.LoyaltyTransactions.Add(new LoyaltyTransaction { 
                            CustomerId = customer.Id, 
                            Points = user.MembershipPoints, 
                            Description = "Chào mừng thành viên & Tích lũy mua hàng", 
                            CreatedAt = s.join.AddDays(1) 
                        });
                        
                        db.Notifications.Add(new Notification { 
                            UserId = user.Id, 
                            Title = "Chào mừng!", 
                            Message = $"Chào {s.name}, FashionStore tặng bạn {user.MembershipPoints} điểm thưởng!", 
                            CreatedAt = s.join,
                            IsRead = true
                        });
                        await db.SaveChangesAsync();
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"[DB_INIT_ERR] Failed seeding user {s.email}: {ex.Message}");
                }
            }

            // 4. Seed Campaigns
            var existingCamps = await db.Campaigns.Where(c => c.Name.Contains("Sale") || c.Name.Contains("Bản tin")).ToListAsync();
            db.Campaigns.RemoveRange(existingCamps);
            
            db.Campaigns.AddRange(
                new Campaign { Name = "Siêu sale Hè rực rỡ", StartDate = DateTime.UtcNow.AddMonths(-1), EndDate = DateTime.UtcNow, TargetSegment = "Loyal", NotificationTitle = "Quà tặng Hè!", NotificationMessage = "Ưu đãi 20% cho bạn.", IsSent = true, SentAt = DateTime.UtcNow.AddDays(-15), RecipientCount = 8, CreatedAt = DateTime.UtcNow.AddMonths(-1) },
                new Campaign { Name = "Bản tin Thu Đông 2026", StartDate = DateTime.UtcNow.AddDays(-5), EndDate = DateTime.UtcNow.AddDays(25), TargetSegment = "All", NotificationTitle = "BST Mới!", NotificationMessage = "Khám phá ngay phong cách Thu Đông.", IsSent = false, CreatedAt = DateTime.UtcNow.AddDays(-5) }
            );
            await db.SaveChangesAsync();

            Console.WriteLine("[DB_INIT] Enterprise seeding complete (20 users).");
        }

        public static async Task SeedHrmData(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            Console.WriteLine("[DB_INIT] >>> Phase 4: Professional HRM & Payroll Data Seeding <<<");

            // 0. Ensure Foundation Hierarchy exists
            if (!await db.Departments.AnyAsync(d => d.Name == "Ban Giám Đốc"))
            {
                Console.WriteLine("[DB_INIT] Seeding professional HRM hierarchy...");
                
                // Departments
                var depts = new List<Department>
                {
                    new Department { Name = "Ban Giám Đốc", Description = "Điều hành chiến lược và quản trị hệ thống", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Department { Name = "Phòng Kinh Doanh & Marketing", Description = "Tăng trưởng doanh thu và nhận diện thương hiệu", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Department { Name = "Bộ Phận Vận Hành Store", Description = "Quản lý showroom và dịch vụ khách hàng", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Department { Name = "Hậu Cần & Kho Vận", Description = "Quản lý chuỗi cung ứng và tồn kho", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Department { Name = "Tài Chính & Hành Chính", Description = "Quản lý ngân sách, lương bổng và nhân sự", IsActive = true, CreatedAt = DateTime.UtcNow }
                };
                db.Departments.AddRange(depts);
                await db.SaveChangesAsync();

                // Salary Components
                var components = new List<SalaryComponent>
                {
                    new SalaryComponent { Name = "Phụ cấp Ăn trưa", Type = SalaryComponentType.Addition, DefaultAmount = 750000, IsActive = true, CreatedAt = DateTime.UtcNow },
                    new SalaryComponent { Name = "Phụ cấp Xăng xe", Type = SalaryComponentType.Addition, DefaultAmount = 500000, IsActive = true, CreatedAt = DateTime.UtcNow },
                    new SalaryComponent { Name = "Thưởng KPI Doanh số", Type = SalaryComponentType.Addition, DefaultAmount = 2000000, IsActive = true, CreatedAt = DateTime.UtcNow },
                    new SalaryComponent { Name = "Khấu trừ Bảo hiểm (BHXH)", Type = SalaryComponentType.Deduction, DefaultAmount = 1500000, IsActive = true, CreatedAt = DateTime.UtcNow }
                };
                db.SalaryComponents.AddRange(components);
                await db.SaveChangesAsync();

                // Employees
                var primaryStore = await db.Stores.FirstOrDefaultAsync();
                int storeId = primaryStore?.Id ?? 1;

                var employeesSeeding = new List<Employee>
                {
                    new Employee { 
                        FullName = "Nguyễn Trần Minh Tâm", Position = "Giám đốc Điều hành", 
                        Email = "tâm.ntm@bnstore.vn", Phone = "0901234001", 
                        HireDate = DateTime.UtcNow.AddYears(-3), BaseSalaryPerHour = 250000,
                        DepartmentId = depts[0].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Lê Thị Hồng Hạnh", Position = "Trưởng phòng Kinh doanh", 
                        Email = "hanh.lth@bnstore.vn", Phone = "0901234002", 
                        HireDate = DateTime.UtcNow.AddYears(-2), BaseSalaryPerHour = 120000,
                        DepartmentId = depts[1].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Phạm Văn Dũng", Position = "Quản lý Cửa hàng", 
                        Email = "dung.pv@bnstore.vn", Phone = "0901234003", 
                        HireDate = DateTime.UtcNow.AddYears(-1), BaseSalaryPerHour = 85000,
                        DepartmentId = depts[2].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Trần Minh Hoàng", Position = "Nhân viên Kho", 
                        Email = "hoang.tm@bnstore.vn", Phone = "0901234004", 
                        HireDate = DateTime.UtcNow.AddMonths(-6), BaseSalaryPerHour = 55000,
                        DepartmentId = depts[3].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Nguyễn Bảo Ngọc", Position = "Chuyên viên Tư vấn", 
                        Email = "ngoc.nb@bnstore.vn", Phone = "0901234005", 
                        HireDate = DateTime.UtcNow.AddMonths(-3), BaseSalaryPerHour = 45000,
                        DepartmentId = depts[2].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Đặng Thu Thảo", Position = "Kế toán trưởng", 
                        Email = "thao.dt@bnstore.vn", Phone = "0901234006", 
                        HireDate = DateTime.UtcNow.AddYears(-2), BaseSalaryPerHour = 110000,
                        DepartmentId = depts[4].Id, StoreId = storeId, IsActive = true 
                    }
                };

                db.Employees.AddRange(employeesSeeding);
                await db.SaveChangesAsync();
                
                Console.WriteLine("[DB_INIT] HRM Foundation Hierarchy seeded.");
            }

            // 0b. Robust Identity User Linkage - Runs even if Employees already existed
            var allEmployees = await db.Employees.ToListAsync();
            bool hasChanges = false;
            foreach (var emp in allEmployees)
            {
                var user = await userManager.FindByEmailAsync(emp.Email);
                if (user == null)
                {
                    user = new ApplicationUser 
                    { 
                        UserName = emp.Email, 
                        Email = emp.Email, 
                        FullName = emp.FullName, 
                        EmailConfirmed = true,
                        JoinDate = emp.HireDate
                    };
                    var result = await userManager.CreateAsync(user, "Staff@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Staff");
                        Console.WriteLine($"[DB_INIT] Created Staff account for: {emp.Email}");
                    }
                }
                else if (!await userManager.IsInRoleAsync(user, "Staff"))
                {
                    await userManager.AddToRoleAsync(user, "Staff");
                    Console.WriteLine($"[DB_INIT] Assigned Staff role to existing: {emp.Email}");
                }

                if (string.IsNullOrEmpty(emp.UserId))
                {
                    emp.UserId = user?.Id;
                    hasChanges = true;
                }
            }
            if (hasChanges) await db.SaveChangesAsync();

            // 1. Foundation: Shifts (Ca làm việc)
            if (!await db.Shifts.AnyAsync())
            {
                var store1 = await db.Stores.FirstOrDefaultAsync();
                int storeId1 = store1?.Id ?? 1;

                var shifts = new List<Shift>
                {
                    new Shift { Name = "Ca Sáng (Morning)", StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(12, 30, 0), StoreId = storeId1, IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Shift { Name = "Ca Chiều (Afternoon)", StartTime = new TimeSpan(13, 30, 0), EndTime = new TimeSpan(17, 30, 0), StoreId = storeId1, IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Shift { Name = "Ca Tối (Evening)", StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(22, 0, 0), StoreId = storeId1, IsActive = true, CreatedAt = DateTime.UtcNow }
                };
                db.Shifts.AddRange(shifts);
                await db.SaveChangesAsync();
                Console.WriteLine("[DB_INIT] Shifts seeded.");
            }

            var employees = await db.Employees.ToListAsync();
            if (!employees.Any()) return;

            // 2. Foundation: Leave Balances (Quỹ phép 2026)
            if (!await db.LeaveBalances.AnyAsync(lb => lb.Year == 2026))
            {
                foreach (var emp in employees)
                {
                    db.LeaveBalances.Add(new LeaveBalance
                    {
                        EmployeeId = emp.Id,
                        Year = 2026,
                        AnnualDaysTotal = 12,
                        AnnualDaysUsed = 0,
                        SickDaysTotal = 5,
                        SickDaysUsed = 0,
                        CreatedAt = DateTime.UtcNow
                    });
                }
                await db.SaveChangesAsync();
                Console.WriteLine("[DB_INIT] Leave Balances seeded.");
            }

            // 3. Weekly Schedules (Xếp lịch: Tuần qua & Tuần tới)
            var shiftsList = await db.Shifts.ToListAsync();
            if (!await db.Schedules.AnyAsync())
            {
                Random rnd = new Random();
                var startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1).AddDays(-7); // Monday last week
                var schedulesToAdd = new List<Schedule>();

                for (int i = 0; i < 14; i++) // 14 days
                {
                    var date = startDate.AddDays(i);
                    foreach (var emp in employees)
                    {
                        // Randomly assign 1 shift per day for most employees
                        if (rnd.Next(10) > 2) // 80% attendance
                        {
                            var shift = shiftsList[rnd.Next(shiftsList.Count)];
                            schedulesToAdd.Add(new Schedule
                            {
                                EmployeeId = emp.Id,
                                ShiftId = shift.Id,
                                Date = date,
                                Status = ScheduleStatus.Scheduled,
                                CreatedAt = DateTime.UtcNow
                            });
                        }
                    }
                }
                db.Schedules.AddRange(schedulesToAdd);
                await db.SaveChangesAsync();
                Console.WriteLine("[DB_INIT] Weekly Schedules seeded.");
            }

            // 4. Attendance (Chấm công dựa trên lịch - Bao gồm cả "Hôm nay")
            if (!await db.Attendances.AnyAsync(a => a.Date == DateTime.Today))
            {
                var currentSchedules = await db.Schedules
                    .Include(s => s.Shift)
                    .Where(s => s.Date <= DateTime.Today) // Include today
                    .ToListAsync();

                Random rnd = new Random();
                var attendancesToAdd = new List<Attendance>();
                foreach (var sched in currentSchedules)
                {
                    // If it's today, only check-in for morning/afternoon shifts
                    if (sched.Date == DateTime.Today && sched.Shift.StartTime > DateTime.UtcNow.TimeOfDay)
                        continue; 

                    // Mock check-in/out
                    var checkIn = sched.Shift.StartTime.Add(TimeSpan.FromMinutes(rnd.Next(-10, 10)));
                    var checkOut = sched.Date < DateTime.Today ? sched.Shift.EndTime.Add(TimeSpan.FromMinutes(rnd.Next(-5, 15))) : (TimeSpan?)null;
                    double totalHours = checkOut.HasValue ? (checkOut.Value - checkIn).TotalHours : 0;

                    attendancesToAdd.Add(new Attendance
                    {
                        EmployeeId = sched.EmployeeId,
                        Date = sched.Date,
                        CheckIn = checkIn,
                        CheckOut = checkOut,
                        TotalHours = totalHours,
                        Status = sched.Date < DateTime.Today ? (totalHours >= 4 ? AttendanceStatus.Present : AttendanceStatus.Late) : AttendanceStatus.Present,
                        CreatedAt = DateTime.UtcNow
                    });
                }
                db.Attendances.AddRange(attendancesToAdd);
                await db.SaveChangesAsync();
                Console.WriteLine("[DB_INIT] Attendance data (including today) seeded.");
            }

            // 5. Leave Requests (Đơn nghỉ phép)
            if (!await db.LeaveRequests.AnyAsync())
            {
                var admin = await userManager.Users.FirstOrDefaultAsync(u => u.Email == "admin@gmail.com");
                
                db.LeaveRequests.AddRange(
                    new LeaveRequest { 
                        EmployeeId = employees[3].Id, // Trần Minh Hoàng
                        StartDate = DateTime.Today.AddDays(-5), EndDate = DateTime.Today.AddDays(-4), 
                        Type = LeaveType.Sick, Status = LeaveStatus.Approved, 
                        Reason = "Sốt siêu vi", AdminNote = "Đã nhận giấy báo y tế",
                        ApprovedById = admin?.Id, CreatedAt = DateTime.UtcNow.AddDays(-6) 
                    },
                    new LeaveRequest { 
                        EmployeeId = employees[4].Id, // Nguyễn Bảo Ngọc
                        StartDate = DateTime.Today.AddDays(2), EndDate = DateTime.Today.AddDays(2), 
                        Type = LeaveType.Annual, Status = LeaveStatus.Pending, 
                        Reason = "Giải quyết việc gia đình", CreatedAt = DateTime.UtcNow 
                    }
                );
                await db.SaveChangesAsync();
                Console.WriteLine("[DB_INIT] Leave Requests seeded.");
            }

            // 6. KPI Reviews (Đánh giá tháng 3 & Tháng 4/2026)
            if (!await db.KpiReviews.AnyAsync(k => k.Month == 4 && k.Year == 2026))
            {
                var reviewer = await userManager.Users.FirstOrDefaultAsync(u => u.Email == "admin@gmail.com");
                if (reviewer != null)
                {
                    Random rnd = new Random();
                    foreach (var month in new[] { 3, 4 })
                    {
                        if (await db.KpiReviews.AnyAsync(k => k.Month == month && k.Year == 2026)) continue;

                        foreach (var emp in employees)
                        {
                            var sales = (decimal)(rnd.Next(70, 95) + rnd.NextDouble());
                            var attitude = (decimal)(rnd.Next(80, 100) + rnd.NextDouble());
                            var teamwork = (decimal)(rnd.Next(75, 100) + rnd.NextDouble());
                            var total = (sales + attitude + teamwork) / 3;

                            db.KpiReviews.Add(new KpiReview
                            {
                                EmployeeId = emp.Id,
                                ReviewerId = reviewer.Id,
                                Month = month,
                                Year = 2026,
                                SalesScore = sales,
                                AttitudeScore = attitude,
                                TeamworkScore = teamwork,
                                TotalScore = total,
                                Rank = total >= 90 ? KpiRank.A : (total >= 80 ? KpiRank.B : KpiRank.C),
                                Notes = $"Đánh giá định kỳ tháng {month}.",
                                CreatedAt = DateTime.UtcNow
                            });
                        }
                    }
                    await db.SaveChangesAsync();
                }
                Console.WriteLine("[DB_INIT] KPI Reviews (March & April) seeded.");
            }

            // 7. Payroll: March & April 2026
            if (!await db.Payrolls.AnyAsync(p => p.Month == 4 && p.Year == 2026))
            {
                foreach (var month in new[] { 3, 4 })
                {
                    if (await db.Payrolls.AnyAsync(p => p.Month == month && p.Year == 2026)) continue;

                    var monthAttendances = await db.Attendances
                        .Where(a => a.Date.Month == month && a.Date.Year == 2026)
                        .ToListAsync();

                    foreach (var emp in employees)
                    {
                        var empAttendances = monthAttendances.Where(a => a.EmployeeId == emp.Id).ToList();
                        var totalHours = empAttendances.Sum(a => a.TotalHours);
                        if (totalHours == 0) totalHours = (month == 3 ? 160 : 24); // Default logic

                        var hourlyRate = emp.BaseSalaryPerHour;
                        var baseSalary = (decimal)totalHours * hourlyRate;
                        var additions = 1250000m; 
                        var deductions = baseSalary * 0.105m; 
                        var netSalary = baseSalary + additions - deductions;

                        db.Payrolls.Add(new Payroll
                        {
                            EmployeeId = emp.Id,
                            Month = month,
                            Year = 2026,
                            TotalHoursWorked = totalHours,
                            BaseHourlyRate = hourlyRate,
                            TotalBaseSalary = baseSalary,
                            TotalAdditions = additions,
                            TotalDeductions = deductions,
                            NetSalary = netSalary,
                            Status = month == 3 ? PayrollStatus.Paid : PayrollStatus.Draft,
                            ProcessedDate = month == 3 ? DateTime.UtcNow : (DateTime?)null,
                            Note = $"Quyết toán lương tháng {month}/2026",
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }
                await db.SaveChangesAsync();
                Console.WriteLine("[DB_INIT] Payroll (March & April) seeded.");
            }

            Console.WriteLine("[DB_INIT] HRM & Payroll professional seeding complete.");
        }
    }
}
