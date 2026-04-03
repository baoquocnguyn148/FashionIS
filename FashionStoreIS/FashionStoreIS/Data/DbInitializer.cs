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
                bool isSqlite = provider.Contains("Sqlite", StringComparison.OrdinalIgnoreCase);

                if (isSqlite)
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

                // 4. Seeding Products & Banners (Baseline)
                if (!await db.Banners.AnyAsync())
                {
                    db.Banners.AddRange(
                        new Banner { Title = "NEW COLLECTION 2026", SubTitle = "FOR DREAMERS ONLY", ImageUrl = "/uploads/banners/banner1.png", Position = "Hero", LinkUrl = "/Product/List", IsActive = true, DisplayOrder = 1, CreatedAt = DateTime.Now },
                        new Banner { Title = "PREMIUM TOPS", SubTitle = "ESSENTIALS", ImageUrl = "/uploads/banners/banner2.png", Position = "Category1", LinkUrl = "/Product/List?cat=tops", IsActive = true, DisplayOrder = 2, CreatedAt = DateTime.Now }
                    );
                    await db.SaveChangesAsync();
                }

                if (!await db.Products.AnyAsync())
                {
                    // Basic Categories
                    var catTops = new Category { Name = "Áo", Slug = "tops", DisplayOrder = 1, CreatedAt = DateTime.Now };
                    var catPants = new Category { Name = "Quần", Slug = "pants", DisplayOrder = 2, CreatedAt = DateTime.Now };
                    db.Categories.AddRange(catTops, catPants);
                    
                    var supplier = new Supplier { Name = "Main Supplier", Phone = "0900000000", Email = "supplier@main.local", CreatedAt = DateTime.Now };
                    db.Suppliers.Add(supplier);
                    await db.SaveChangesAsync();

                    var p1 = new Product { Name = "Áo thun BN Basic", Slug = "ao-thun-bn-basic", CategoryId = catTops.Id, SupplierId = supplier.Id, Price = 199000, ImageUrl = "https://placehold.co/400x500", CreatedAt = DateTime.Now, IsActive = true };
                    db.Products.Add(p1);
                    await db.SaveChangesAsync();

                    var sku1 = new ProductSku { ProductId = p1.Id, SKU = "TSHIRT-BLK-M", SkuCode = "TSHIRT-BLK-M", Color = "Black", Size = "M", SellingPrice = 199000, CostPrice = 100000, Stock = 100, IsActive = true, CreatedAt = DateTime.Now };
                    db.ProductSkus.Add(sku1);
                    await db.SaveChangesAsync();
                }

                // 5. CRM Data Seed (Manual or Auto Triggered)
                await SeedSampleCrmData(db, userManager);

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

            // 4. Seeding Professional HRM & Payroll Data (Check if professional set exists)
            if (!await db.Departments.AnyAsync(d => d.Name == "Ban Giám Đốc"))
            {
                Console.WriteLine("[DB_INIT] Seeding professional HRM hierarchy...");
                
                // Departments
                var depts = new List<Department>
                {
                    new Department { Name = "Ban Giám Đốc", Description = "Điều hành chiến lược và quản trị hệ thống", IsActive = true, CreatedAt = DateTime.Now },
                    new Department { Name = "Phòng Kinh Doanh & Marketing", Description = "Tăng trưởng doanh thu và nhận diện thương hiệu", IsActive = true, CreatedAt = DateTime.Now },
                    new Department { Name = "Bộ Phận Vận Hành Store", Description = "Quản lý showroom và dịch vụ khách hàng", IsActive = true, CreatedAt = DateTime.Now },
                    new Department { Name = "Hậu Cần & Kho Vận", Description = "Quản lý chuỗi cung ứng và tồn kho", IsActive = true, CreatedAt = DateTime.Now },
                    new Department { Name = "Tài Chính & Hành Chính", Description = "Quản lý ngân sách, lương bổng và nhân sự", IsActive = true, CreatedAt = DateTime.Now }
                };
                db.Departments.AddRange(depts);
                await db.SaveChangesAsync();

                // Salary Components
                var components = new List<SalaryComponent>
                {
                    new SalaryComponent { Name = "Phụ cấp Ăn trưa", Type = SalaryComponentType.Addition, DefaultAmount = 750000, IsActive = true, CreatedAt = DateTime.Now },
                    new SalaryComponent { Name = "Phụ cấp Xăng xe", Type = SalaryComponentType.Addition, DefaultAmount = 500000, IsActive = true, CreatedAt = DateTime.Now },
                    new SalaryComponent { Name = "Thưởng KPI Doanh số", Type = SalaryComponentType.Addition, DefaultAmount = 2000000, IsActive = true, CreatedAt = DateTime.Now },
                    new SalaryComponent { Name = "Khấu trừ Bảo hiểm (BHXH)", Type = SalaryComponentType.Deduction, DefaultAmount = 1500000, IsActive = true, CreatedAt = DateTime.Now }
                };
                db.SalaryComponents.AddRange(components);
                await db.SaveChangesAsync();

                // Employees
                var primaryStore = await db.Stores.FirstOrDefaultAsync();
                int storeId = primaryStore?.Id ?? 1;

                var employees = new List<Employee>
                {
                    new Employee { 
                        FullName = "Nguyễn Trần Minh Tâm", Position = "Giám đốc Điều hành", 
                        Email = "tâm.ntm@bnstore.vn", Phone = "0901234001", 
                        HireDate = DateTime.Now.AddYears(-3), BaseSalaryPerHour = 250000,
                        DepartmentId = depts[0].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Lê Thị Hồng Hạnh", Position = "Trưởng phòng Kinh doanh", 
                        Email = "hanh.lth@bnstore.vn", Phone = "0901234002", 
                        HireDate = DateTime.Now.AddYears(-2), BaseSalaryPerHour = 120000,
                        DepartmentId = depts[1].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Phạm Văn Dũng", Position = "Quản lý Cửa hàng", 
                        Email = "dung.pv@bnstore.vn", Phone = "0901234003", 
                        HireDate = DateTime.Now.AddYears(-1), BaseSalaryPerHour = 85000,
                        DepartmentId = depts[2].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Trần Minh Hoàng", Position = "Nhân viên Kho", 
                        Email = "hoang.tm@bnstore.vn", Phone = "0901234004", 
                        HireDate = DateTime.Now.AddMonths(-6), BaseSalaryPerHour = 55000,
                        DepartmentId = depts[3].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Nguyễn Bảo Ngọc", Position = "Chuyên viên Tư vấn", 
                        Email = "ngoc.nb@bnstore.vn", Phone = "0901234005", 
                        HireDate = DateTime.Now.AddMonths(-3), BaseSalaryPerHour = 45000,
                        DepartmentId = depts[2].Id, StoreId = storeId, IsActive = true 
                    },
                    new Employee { 
                        FullName = "Đặng Thu Thảo", Position = "Kế toán trưởng", 
                        Email = "thao.dt@bnstore.vn", Phone = "0901234006", 
                        HireDate = DateTime.Now.AddYears(-2), BaseSalaryPerHour = 110000,
                        DepartmentId = depts[4].Id, StoreId = storeId, IsActive = true 
                    }
                };
                db.Employees.AddRange(employees);
                await db.SaveChangesAsync();
                
                Console.WriteLine("[DB_INIT] HRM & Payroll professional data seeded successfully.");
            }

        // Oracle Schema Auto-Patch for modern CRM fields
            if (db.Database.ProviderName != null && db.Database.ProviderName.Contains("Oracle", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("[DB_INIT] Running schema auto-patch for Oracle CRM readiness...");
                var alterCmds = new[] {
                    "ALTER TABLE CUSTOMERS ADD (TIER NUMBER(10) DEFAULT 0)",
                    "ALTER TABLE CUSTOMERS ADD (LOYALTYPOINTS NUMBER(10) DEFAULT 0)",
                    "ALTER TABLE CUSTOMERS ADD (JOINDATE TIMESTAMP(7))",
                    "ALTER TABLE CUSTOMERS ADD (DATEOFBIRTH TIMESTAMP(7))",

                    "ALTER TABLE ORDERS ADD (SUBTOTAL NUMBER(14,0) DEFAULT 0)",
                    "ALTER TABLE ORDERS ADD (DISCOUNTAMOUNT NUMBER(14,0) DEFAULT 0)",
                    "ALTER TABLE ORDERS ADD (POINTSEARNED NUMBER(10) DEFAULT 0)",
                    "ALTER TABLE ORDERS ADD (CUSTOMERNAME NVARCHAR2(100))",
                    "ALTER TABLE ORDERS ADD (PHONE NVARCHAR2(20))",
                    "ALTER TABLE ORDERS ADD (ADDRESS NVARCHAR2(500))",
                    "ALTER TABLE ORDERS ADD (NOTE NVARCHAR2(500))",

                    "ALTER TABLE ORDERDETAILS ADD (SUBTOTAL NUMBER(14,0) DEFAULT 0)",
                    "ALTER TABLE ORDERDETAILS ADD (DISCOUNTPERCENT NUMBER(14,4) DEFAULT 0)",
                    
                    // HRM & Payroll Patches
                    "ALTER TABLE EMPLOYEES ADD (BASESALARYPERHOUR NUMBER(12,2) DEFAULT 0)",
                    "ALTER TABLE EMPLOYEES ADD (BANKACCOUNTNUMBER NVARCHAR2(50))",
                    "ALTER TABLE EMPLOYEES ADD (BANKNAME NVARCHAR2(100))",
                    "ALTER TABLE EMPLOYEES ADD (BANKACCOUNTNAME NVARCHAR2(100))",
                    "ALTER TABLE EMPLOYEES ADD (DEPARTMENTID NUMBER(10))"
                };

                foreach (var sql in alterCmds)
                {
                    try { await db.Database.ExecuteSqlRawAsync(sql); } catch { /* Ignore */ }
                }

                var createCmds = new[] {
                    "CREATE SEQUENCE HILOSEQUENCE START WITH 1 INCREMENT BY 1",
                    "CREATE TABLE LOYALTYTRANSACTIONS (ID NUMBER(10) PRIMARY KEY, CUSTOMERID NUMBER(10) NOT NULL, POINTS NUMBER(10) NOT NULL, DESCRIPTION NVARCHAR2(500), CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_LT_CUST FOREIGN KEY (CUSTOMERID) REFERENCES CUSTOMERS(ID))",
                    "CREATE TABLE NOTIFICATIONS (ID NUMBER(10) PRIMARY KEY, USERID VARCHAR2(450) NOT NULL, TITLE NVARCHAR2(200) NOT NULL, MESSAGE NVARCHAR2(1000) NOT NULL, ACTIONURL NVARCHAR2(255), ISREAD NUMBER(1) DEFAULT 0, CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_NOTIF_USER FOREIGN KEY (USERID) REFERENCES ASPNETUSERS(ID))",
                    "CREATE TABLE CAMPAIGNS (ID NUMBER(10) PRIMARY KEY, NAME NVARCHAR2(150) NOT NULL, DESCRIPTION NVARCHAR2(500), STARTDATE TIMESTAMP(7) NOT NULL, ENDDATE TIMESTAMP(7) NOT NULL, TARGETSEGMENT NVARCHAR2(50), NOTIFICATIONTITLE NVARCHAR2(200), NOTIFICATIONMESSAGE NVARCHAR2(1000), VOUCHERID NUMBER(10), ISSENT NUMBER(1) DEFAULT 0, SENTAT TIMESTAMP(7), RECIPIENTCOUNT NUMBER(10) DEFAULT 0, CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_CAMP_VOUCHER FOREIGN KEY (VOUCHERID) REFERENCES VOUCHERS(ID))",
                    "CREATE TABLE WISHLISTITEMS (ID NUMBER(10) PRIMARY KEY, USERID VARCHAR2(450) NOT NULL, PRODUCTID NUMBER(10) NOT NULL, CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_WL_USER FOREIGN KEY (USERID) REFERENCES ASPNETUSERS(ID), CONSTRAINT FK_WL_PRODUCT FOREIGN KEY (PRODUCTID) REFERENCES PRODUCTS(ID), CONSTRAINT UQ_WL_USER_PROD UNIQUE (USERID, PRODUCTID))",
                    
                    // HRM & Payroll Tables
                    "CREATE TABLE DEPARTMENTS (ID NUMBER(10) PRIMARY KEY, NAME NVARCHAR2(150) NOT NULL, DESCRIPTION NVARCHAR2(500), ISACTIVE NUMBER(1) DEFAULT 1, CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0)",
                    "CREATE TABLE ATTENDANCES (ID NUMBER(10) PRIMARY KEY, EMPLOYEEID NUMBER(10) NOT NULL, \"DATE\" TIMESTAMP(7) NOT NULL, CHECKIN INTERVAL DAY(0) TO SECOND(0), CHECKOUT INTERVAL DAY(0) TO SECOND(0), TOTALHOURS NUMBER(10,2) DEFAULT 0, STATUS NUMBER(10), NOTE NVARCHAR2(500), CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_ATT_EMP FOREIGN KEY (EMPLOYEEID) REFERENCES EMPLOYEES(ID))",
                    "CREATE TABLE LEAVEREQUESTS (ID NUMBER(10) PRIMARY KEY, EMPLOYEEID NUMBER(10) NOT NULL, STARTDATE TIMESTAMP(7) NOT NULL, ENDDATE TIMESTAMP(7) NOT NULL, TYPE NUMBER(10), STATUS NUMBER(10) DEFAULT 1, REASON NVARCHAR2(500), ADMINNOTE NVARCHAR2(500), APPROVEDBYID NVARCHAR2(450), CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_LV_EMP FOREIGN KEY (EMPLOYEEID) REFERENCES EMPLOYEES(ID))",
                    "CREATE TABLE SALARYCOMPONENTS (ID NUMBER(10) PRIMARY KEY, NAME NVARCHAR2(150) NOT NULL, TYPE NUMBER(10), DEFAULTAMOUNT NUMBER(12,2) DEFAULT 0, DESCRIPTION NVARCHAR2(500), ISACTIVE NUMBER(1) DEFAULT 1, CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0)",
                    "CREATE TABLE PAYROLLS (ID NUMBER(10) PRIMARY KEY, EMPLOYEEID NUMBER(10) NOT NULL, MONTH NUMBER(10), YEAR NUMBER(10), TOTALHOURSWORKED NUMBER(10,2) DEFAULT 0, BASEHOURLYRATE NUMBER(12,2) DEFAULT 0, TOTALBASESALARY NUMBER(12,2) DEFAULT 0, TOTALADDITIONS NUMBER(12,2) DEFAULT 0, TOTALDEDUCTIONS NUMBER(12,2) DEFAULT 0, NETSALARY NUMBER(12,2) DEFAULT 0, STATUS NUMBER(10) DEFAULT 1, PROCESSEDDATE TIMESTAMP(7), NOTE NVARCHAR2(500), CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_PAY_EMP FOREIGN KEY (EMPLOYEEID) REFERENCES EMPLOYEES(ID))",
                    "CREATE TABLE PAYROLLITEMS (ID NUMBER(10) PRIMARY KEY, PAYROLLID NUMBER(10) NOT NULL, SALARYCOMPONENTID NUMBER(10), AMOUNT NUMBER(12,2) DEFAULT 0, NOTE NVARCHAR2(500), CREATEDAT TIMESTAMP(7) DEFAULT CURRENT_TIMESTAMP, UPDATEDAT TIMESTAMP(7), ISDELETED NUMBER(1) DEFAULT 0, CONSTRAINT FK_PI_PAY FOREIGN KEY (PAYROLLID) REFERENCES PAYROLLS(ID), CONSTRAINT FK_PI_COMP FOREIGN KEY (SALARYCOMPONENTID) REFERENCES SALARYCOMPONENTS(ID))"
                };

                foreach (var sql in createCmds)
                {
                    try { await db.Database.ExecuteSqlRawAsync(sql); } catch { /* Ignore if exists */ }
                }

                Console.WriteLine("[DB_INIT] Oracle schema auto-patch applied.");
            }

            // 2. Foundation Verification
            var store = await db.Stores.FirstOrDefaultAsync();
            if (store == null)
            {
                store = new Store { Name = "BN Fashion Flagship", Address = "HCM", Phone = "0900000000", IsActive = true };
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
                ("Nguyễn Quốc Bảo",   "bao.nq@samplecrm.com",  DateTime.Now.AddMonths(-12), "https://i.pravatar.cc/150?u=1", "0901234567"),
                ("Trần Lê Minh",    "minh.tl@samplecrm.com", DateTime.Now.AddMonths(-11), "https://i.pravatar.cc/150?u=2", "0901234568"),
                ("Phạm Hương Ly",   "ly.ph@samplecrm.com",   DateTime.Now.AddMonths(-10), "https://i.pravatar.cc/150?u=3", "0901234569"),
                ("Lê Hoàng Dũng",   "dung.lh@samplecrm.com",  DateTime.Now.AddMonths(-9),  "https://i.pravatar.cc/150?u=4", "0901234570"),
                ("Vũ Thành Trung",  "trung.vt@samplecrm.com", DateTime.Now.AddMonths(-8),  "https://i.pravatar.cc/150?u=5", "0901234571"),
                ("Đặng Thu Thảo",   "thao.dt@samplecrm.com",  DateTime.Now.AddMonths(-7),  "https://i.pravatar.cc/150?u=6", "0901234572"),
                ("Ngô Chí Hùng",    "hung.nc@samplecrm.com",  DateTime.Now.AddMonths(-6),  "https://i.pravatar.cc/150?u=7", "0901234573"),
                ("Bùi Diệu Nhi",    "nhi.bd@samplecrm.com",   DateTime.Now.AddMonths(-5),  "https://i.pravatar.cc/150?u=8", "0901234574"),
                ("Lý Quang Diệu",   "dieu.lq@samplecrm.com",  DateTime.Now.AddMonths(-4),  "https://i.pravatar.cc/150?u=9", "0901234575"),
                ("Hồ Ngọc Hà",      "ha.hn@samplecrm.com",    DateTime.Now.AddMonths(-3),  "https://i.pravatar.cc/150?u=10", "0901234576"),
                ("Trịnh Gia Bảo",   "bao.tg@samplecrm.com",   DateTime.Now.AddMonths(-11), "https://i.pravatar.cc/150?u=11", "0901234577"),
                ("Mai Phương Thúy", "thuy.mp@samplecrm.com",  DateTime.Now.AddMonths(-10), "https://i.pravatar.cc/150?u=12", "0901234578"),
                ("Nguyễn Cao Kỳ", "ky.nc@samplecrm.com",  DateTime.Now.AddMonths(-9),  "https://i.pravatar.cc/150?u=13", "0901234579"),
                ("Thái Công Vinh",  "vinh.tc@samplecrm.com",  DateTime.Now.AddMonths(-8),  "https://i.pravatar.cc/150?u=14", "0901234580"),
                ("Lương Bằng Quang","quang.lb@samplecrm.com", DateTime.Now.AddMonths(-7),  "https://i.pravatar.cc/150?u=15", "0901234581"),
                ("Võ Hạ Trâm",      "tram.vh@samplecrm.com",  DateTime.Now.AddMonths(-6),  "https://i.pravatar.cc/150?u=16", "0901234582"),
                ("Đào Anh Tuấn",    "tuan.da@samplecrm.com",  DateTime.Now.AddMonths(-5),  "https://i.pravatar.cc/150?u=17", "0901234583"),
                ("Kiều Minh Tuấn",  "tuan.km@samplecrm.com",  DateTime.Now.AddMonths(-4),  "https://i.pravatar.cc/150?u=18", "0901234584"),
                ("Trần Ngọc Trinh", "trinh.tn@samplecrm.com", DateTime.Now.AddMonths(-3),  "https://i.pravatar.cc/150?u=19", "0901234585"),
                ("Nguyễn Quang Hải","hai.nq@samplecrm.com",   DateTime.Now.AddMonths(-2),  "https://i.pravatar.cc/150?u=20", "0901234586")
            };

            string suffix = append ? $"+{DateTime.Now.Ticks}@samplecrm.com" : "@samplecrm.com";

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
                        for (int i = 0; i < orderCount; i++)
                        {
                            DateTime orderDate = s.join.AddDays(rnd.Next(0, (int)(DateTime.Now - s.join).TotalDays));
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
                                Address = "Quận 1, TP. Hồ Chí Minh"
                            };
                            db.Orders.Add(order);
                            await db.SaveChangesAsync();

                            // 1 to 5 SKUs per order
                            int itemsCount = rnd.Next(1, 6);
                            decimal total = 0;
                            for (int j = 0; j < itemsCount; j++)
                            {
                                var sku = skus[rnd.Next(skus.Count)];
                                var qty = rnd.Next(1, 4);
                                var price = sku.PriceOverride > 0 ? sku.PriceOverride.Value : sku.SellingPrice;
                                
                                db.OrderDetails.Add(new OrderDetail { 
                                    OrderId = order.Id, 
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
                            await db.SaveChangesAsync();
                        }

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
                new Campaign { Name = "Siêu sale Hè rực rỡ", StartDate = DateTime.Now.AddMonths(-1), EndDate = DateTime.Now, TargetSegment = "Loyal", NotificationTitle = "Quà tặng Hè!", NotificationMessage = "Ưu đãi 20% cho bạn.", IsSent = true, SentAt = DateTime.Now.AddDays(-15), RecipientCount = 8, CreatedAt = DateTime.Now.AddMonths(-1) },
                new Campaign { Name = "Bản tin Thu Đông 2026", StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(25), TargetSegment = "All", NotificationTitle = "BST Mới!", NotificationMessage = "Khám phá ngay phong cách Thu Đông.", IsSent = false, CreatedAt = DateTime.Now.AddDays(-5) }
            );
            await db.SaveChangesAsync();

            Console.WriteLine("[DB_INIT] Enterprise seeding complete (20 users).");
        }
    }
}
