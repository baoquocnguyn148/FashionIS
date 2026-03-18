-- StyleVibe Fashion MIS - Seed Data Script
-- Chạy script này sau khi đã tạo schema để có dữ liệu demo

USE StyleVibeDb;
GO

-- 1. Stores (Cửa hàng)
INSERT INTO Stores (Name, Address, Phone, ManagerName, IsActive, CreatedAt)
VALUES 
    ('StyleVibe Quận 1', '123 Nguyễn Huệ, Quận 1, TP.HCM', '0281234567', 'Nguyễn Văn A', 1, GETUTCDATE()),
    ('StyleVibe Quận 3', '456 Lê Văn Sỹ, Quận 3, TP.HCM', '0282345678', 'Trần Thị B', 1, GETUTCDATE()),
    ('StyleVibe Quận 7', '789 Nguyễn Thị Thập, Quận 7, TP.HCM', '0283456789', 'Lê Văn C', 1, GETUTCDATE());
GO

-- 2. Categories (Danh mục)
INSERT INTO Categories (Name, Description, ImageUrl, DisplayOrder, CreatedAt)
VALUES 
    ('Áo', 'Áo thun, áo sơ mi, áo khoác', NULL, 1, GETUTCDATE()),
    ('Quần', 'Quần jean, quần kaki, quần short', NULL, 2, GETUTCDATE()),
    ('Váy', 'Váy ngắn, váy dài, đầm', NULL, 3, GETUTCDATE()),
    ('Áo khoác', 'Áo khoác gió, áo khoác dạ', NULL, 4, GETUTCDATE()),
    ('Phụ kiện', 'Túi xách, ví, mũ, khăn', NULL, 5, GETUTCDATE());
GO

-- 3. Suppliers (Nhà cung cấp)
INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address, LeadTimeDays, IsActive, CreatedAt)
VALUES 
    ('Công ty Thời trang ABC', 'Nguyễn Văn X', '0901234567', 'contact@abc.com', 'Hà Nội', 7, 1, GETUTCDATE()),
    ('Xưởng may XYZ', 'Trần Thị Y', '0902345678', 'info@xyz.com', 'TP.HCM', 5, 1, GETUTCDATE()),
    ('Nhà cung cấp DEF', 'Lê Văn Z', '0903456789', 'sales@def.com', 'Đà Nẵng', 10, 1, GETUTCDATE());
GO

-- 4. Products (Sản phẩm)
INSERT INTO Products (Name, Description, ImageUrl, IsActive, CategoryId, SupplierId, CreatedAt)
VALUES 
    ('Áo thun basic cổ tròn', 'Áo thun cotton 100%, form rộng, thoáng mát', NULL, 1, 1, 1, GETUTCDATE()),
    ('Quần jean slim fit', 'Quần jean form slim, chất liệu denim cao cấp', NULL, 1, 2, 1, GETUTCDATE()),
    ('Váy liền thân A-line', 'Váy dáng A-line, vải chiffon mềm mại', NULL, 1, 3, 2, GETUTCDATE()),
    ('Áo khoác gió chống nước', 'Áo khoác gió nhẹ, chống nước, có mũ trùm đầu', NULL, 1, 4, 3, GETUTCDATE()),
    ('Túi xách da thật', 'Túi xách da bò thật, thiết kế tối giản', NULL, 1, 5, 2, GETUTCDATE());
GO

-- 5. ProductSkus (SKU - Size + Color)
-- Lấy ProductId từ Products vừa insert
DECLARE @Product1 INT = (SELECT Id FROM Products WHERE Name = 'Áo thun basic cổ tròn');
DECLARE @Product2 INT = (SELECT Id FROM Products WHERE Name = 'Quần jean slim fit');
DECLARE @Product3 INT = (SELECT Id FROM Products WHERE Name = 'Váy liền thân A-line');
DECLARE @Product4 INT = (SELECT Id FROM Products WHERE Name = 'Áo khoác gió chống nước');
DECLARE @Product5 INT = (SELECT Id FROM Products WHERE Name = 'Túi xách da thật');

INSERT INTO ProductSkus (SkuCode, Size, Color, CostPrice, SellingPrice, ProductId, IsActive, CreatedAt)
VALUES 
    -- Áo thun basic
    ('P001-S-TRA', 'S', 'Trắng', 80000, 150000, @Product1, 1, GETUTCDATE()),
    ('P001-M-TRA', 'M', 'Trắng', 80000, 150000, @Product1, 1, GETUTCDATE()),
    ('P001-L-TRA', 'L', 'Trắng', 80000, 150000, @Product1, 1, GETUTCDATE()),
    ('P001-S-DEN', 'S', 'Đen', 80000, 150000, @Product1, 1, GETUTCDATE()),
    ('P001-M-DEN', 'M', 'Đen', 80000, 150000, @Product1, 1, GETUTCDATE()),
    ('P001-L-DEN', 'L', 'Đen', 80000, 150000, @Product1, 1, GETUTCDATE()),
    
    -- Quần jean
    ('P002-28-XANH', '28', 'Xanh navy', 200000, 450000, @Product2, 1, GETUTCDATE()),
    ('P002-30-XANH', '30', 'Xanh navy', 200000, 450000, @Product2, 1, GETUTCDATE()),
    ('P002-32-XANH', '32', 'Xanh navy', 200000, 450000, @Product2, 1, GETUTCDATE()),
    ('P002-28-DEN', '28', 'Đen', 200000, 450000, @Product2, 1, GETUTCDATE()),
    ('P002-30-DEN', '30', 'Đen', 200000, 450000, @Product2, 1, GETUTCDATE()),
    
    -- Váy liền thân
    ('P003-S-HONG', 'S', 'Hồng', 150000, 350000, @Product3, 1, GETUTCDATE()),
    ('P003-M-HONG', 'M', 'Hồng', 150000, 350000, @Product3, 1, GETUTCDATE()),
    ('P003-L-HONG', 'L', 'Hồng', 150000, 350000, @Product3, 1, GETUTCDATE()),
    ('P003-S-XANH', 'S', 'Xanh dương', 150000, 350000, @Product3, 1, GETUTCDATE()),
    ('P003-M-XANH', 'M', 'Xanh dương', 150000, 350000, @Product3, 1, GETUTCDATE()),
    
    -- Áo khoác gió
    ('P004-M-DEN', 'M', 'Đen', 300000, 650000, @Product4, 1, GETUTCDATE()),
    ('P004-L-DEN', 'L', 'Đen', 300000, 650000, @Product4, 1, GETUTCDATE()),
    ('P004-M-XAM', 'M', 'Xám', 300000, 650000, @Product4, 1, GETUTCDATE()),
    ('P004-L-XAM', 'L', 'Xám', 300000, 650000, @Product4, 1, GETUTCDATE()),
    
    -- Túi xách
    ('P005-ONE-DEN', 'One Size', 'Đen', 400000, 850000, @Product5, 1, GETUTCDATE()),
    ('P005-ONE-NAU', 'One Size', 'Nâu', 400000, 850000, @Product5, 1, GETUTCDATE());
GO

-- 6. Inventories (Tồn kho) - Mỗi cửa hàng có tồn kho cho từng SKU
DECLARE @Store1 INT = (SELECT Id FROM Stores WHERE Name = 'StyleVibe Quận 1');
DECLARE @Store2 INT = (SELECT Id FROM Stores WHERE Name = 'StyleVibe Quận 3');
DECLARE @Store3 INT = (SELECT Id FROM Stores WHERE Name = 'StyleVibe Quận 7');

-- Tồn kho cho Store 1 (Quận 1)
INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, StoreId, ProductSkuId, LastUpdated, CreatedAt)
SELECT 
    50 + ABS(CHECKSUM(NEWID())) % 50, -- Random 50-100
    10,
    200,
    @Store1,
    Id,
    GETUTCDATE(),
    GETUTCDATE()
FROM ProductSkus;
GO

-- Tồn kho cho Store 2 (Quận 3)
INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, StoreId, ProductSkuId, LastUpdated, CreatedAt)
SELECT 
    30 + ABS(CHECKSUM(NEWID())) % 40, -- Random 30-70
    10,
    200,
    @Store2,
    Id,
    GETUTCDATE(),
    GETUTCDATE()
FROM ProductSkus;
GO

-- Tồn kho cho Store 3 (Quận 7)
INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, StoreId, ProductSkuId, LastUpdated, CreatedAt)
SELECT 
    40 + ABS(CHECKSUM(NEWID())) % 45, -- Random 40-85
    10,
    200,
    @Store3,
    Id,
    GETUTCDATE(),
    GETUTCDATE()
FROM ProductSkus;
GO

-- 7. Customers (Khách hàng demo)
INSERT INTO Customers (FullName, Phone, Email, Address, Tier, LoyaltyPoints, JoinDate, CreatedAt)
VALUES 
    ('Nguyễn Thị Mai', '0901111111', 'mai@email.com', 'TP.HCM', 2, 150, GETUTCDATE(), GETUTCDATE()),
    ('Trần Văn Nam', '0902222222', 'nam@email.com', 'Hà Nội', 1, 50, GETUTCDATE(), GETUTCDATE()),
    ('Lê Thị Hoa', '0903333333', 'hoa@email.com', 'Đà Nẵng', 3, 500, GETUTCDATE(), GETUTCDATE());
GO

PRINT '✅ Seed data đã được thêm thành công!';
PRINT 'Bạn có thể kiểm tra bằng cách:';
PRINT '1. Vào /Test/CheckConnection để xem thống kê';
PRINT '2. Vào /Products để xem sản phẩm';
PRINT '3. Vào /Pos để test bán hàng';
GO
