-- StyleVibe Fashion MIS - Oracle Seed Data (works with schema.sql triggers)
-- Run this after executing schema.sql
-- Notes:
-- - Inserts rely on table triggers to generate Id values.
-- - Uses RETURNING INTO to wire foreign keys.

SET SERVEROUTPUT ON;

DECLARE
  v_store1_id NUMBER;
  v_store2_id NUMBER;
  v_store3_id NUMBER;

  v_cat_ao_id NUMBER;
  v_cat_quan_id NUMBER;
  v_cat_vay_id NUMBER;
  v_cat_aokhoac_id NUMBER;
  v_cat_phukien_id NUMBER;

  v_sup1_id NUMBER;
  v_sup2_id NUMBER;
  v_sup3_id NUMBER;

  v_prod1_id NUMBER;
  v_prod2_id NUMBER;
  v_prod3_id NUMBER;
  v_prod4_id NUMBER;
  v_prod5_id NUMBER;

  v_sku_id NUMBER;
BEGIN
  -- Stores
  INSERT INTO Stores (Name, Address, Phone, ManagerName, IsActive)
  VALUES ('StyleVibe Quận 1', '123 Nguyễn Huệ, Quận 1, TP.HCM', '0281234567', 'Nguyễn Văn A', 1)
  RETURNING Id INTO v_store1_id;

  INSERT INTO Stores (Name, Address, Phone, ManagerName, IsActive)
  VALUES ('StyleVibe Quận 3', '456 Lê Văn Sỹ, Quận 3, TP.HCM', '0282345678', 'Trần Thị B', 1)
  RETURNING Id INTO v_store2_id;

  INSERT INTO Stores (Name, Address, Phone, ManagerName, IsActive)
  VALUES ('StyleVibe Quận 7', '789 Nguyễn Thị Thập, Quận 7, TP.HCM', '0283456789', 'Lê Văn C', 1)
  RETURNING Id INTO v_store3_id;

  -- Categories
  INSERT INTO Categories (Name, Description, ImageUrl, DisplayOrder)
  VALUES ('Áo', 'Áo thun, áo sơ mi, áo khoác', NULL, 1)
  RETURNING Id INTO v_cat_ao_id;

  INSERT INTO Categories (Name, Description, ImageUrl, DisplayOrder)
  VALUES ('Quần', 'Quần jean, quần kaki, quần short', NULL, 2)
  RETURNING Id INTO v_cat_quan_id;

  INSERT INTO Categories (Name, Description, ImageUrl, DisplayOrder)
  VALUES ('Váy', 'Váy ngắn, váy dài, đầm', NULL, 3)
  RETURNING Id INTO v_cat_vay_id;

  INSERT INTO Categories (Name, Description, ImageUrl, DisplayOrder)
  VALUES ('Áo khoác', 'Áo khoác gió, áo khoác dạ', NULL, 4)
  RETURNING Id INTO v_cat_aokhoac_id;

  INSERT INTO Categories (Name, Description, ImageUrl, DisplayOrder)
  VALUES ('Phụ kiện', 'Túi xách, ví, mũ, khăn', NULL, 5)
  RETURNING Id INTO v_cat_phukien_id;

  -- Suppliers
  INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address, LeadTimeDays, IsActive)
  VALUES ('Công ty Thời trang ABC', 'Nguyễn Văn X', '0901234567', 'contact@abc.com', 'Hà Nội', 7, 1)
  RETURNING Id INTO v_sup1_id;

  INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address, LeadTimeDays, IsActive)
  VALUES ('Xưởng may XYZ', 'Trần Thị Y', '0902345678', 'info@xyz.com', 'TP.HCM', 5, 1)
  RETURNING Id INTO v_sup2_id;

  INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address, LeadTimeDays, IsActive)
  VALUES ('Nhà cung cấp DEF', 'Lê Văn Z', '0903456789', 'sales@def.com', 'Đà Nẵng', 10, 1)
  RETURNING Id INTO v_sup3_id;

  -- Products
  INSERT INTO Products (Name, Description, ImageUrl, IsActive, CategoryId, SupplierId)
  VALUES ('Áo thun basic cổ tròn', 'Áo thun cotton 100%, form rộng, thoáng mát', NULL, 1, v_cat_ao_id, v_sup1_id)
  RETURNING Id INTO v_prod1_id;

  INSERT INTO Products (Name, Description, ImageUrl, IsActive, CategoryId, SupplierId)
  VALUES ('Quần jean slim fit', 'Quần jean form slim, chất liệu denim cao cấp', NULL, 1, v_cat_quan_id, v_sup1_id)
  RETURNING Id INTO v_prod2_id;

  INSERT INTO Products (Name, Description, ImageUrl, IsActive, CategoryId, SupplierId)
  VALUES ('Váy liền thân A-line', 'Váy dáng A-line, vải chiffon mềm mại', NULL, 1, v_cat_vay_id, v_sup2_id)
  RETURNING Id INTO v_prod3_id;

  INSERT INTO Products (Name, Description, ImageUrl, IsActive, CategoryId, SupplierId)
  VALUES ('Áo khoác gió chống nước', 'Áo khoác gió nhẹ, chống nước, có mũ trùm đầu', NULL, 1, v_cat_aokhoac_id, v_sup3_id)
  RETURNING Id INTO v_prod4_id;

  INSERT INTO Products (Name, Description, ImageUrl, IsActive, CategoryId, SupplierId)
  VALUES ('Túi xách da thật', 'Túi xách da bò thật, thiết kế tối giản', NULL, 1, v_cat_phukien_id, v_sup2_id)
  RETURNING Id INTO v_prod5_id;

  -- ProductSkus (a minimal set)
  INSERT INTO ProductSkus (SkuCode, "Size", Color, CostPrice, SellingPrice, IsActive, ProductId)
  VALUES ('P001-M-TRA', 'M', 'Trắng', 80000, 150000, 1, v_prod1_id)
  RETURNING Id INTO v_sku_id;
  INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, LastUpdated, StoreId, ProductSkuId)
  VALUES (80, 10, 200, SYSTIMESTAMP, v_store1_id, v_sku_id);

  INSERT INTO ProductSkus (SkuCode, "Size", Color, CostPrice, SellingPrice, IsActive, ProductId)
  VALUES ('P001-M-DEN', 'M', 'Đen', 80000, 150000, 1, v_prod1_id)
  RETURNING Id INTO v_sku_id;
  INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, LastUpdated, StoreId, ProductSkuId)
  VALUES (60, 10, 200, SYSTIMESTAMP, v_store1_id, v_sku_id);

  INSERT INTO ProductSkus (SkuCode, "Size", Color, CostPrice, SellingPrice, IsActive, ProductId)
  VALUES ('P002-30-XANH', '30', 'Xanh navy', 200000, 450000, 1, v_prod2_id)
  RETURNING Id INTO v_sku_id;
  INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, LastUpdated, StoreId, ProductSkuId)
  VALUES (45, 10, 200, SYSTIMESTAMP, v_store2_id, v_sku_id);

  INSERT INTO ProductSkus (SkuCode, "Size", Color, CostPrice, SellingPrice, IsActive, ProductId)
  VALUES ('P003-M-HONG', 'M', 'Hồng', 150000, 350000, 1, v_prod3_id)
  RETURNING Id INTO v_sku_id;
  INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, LastUpdated, StoreId, ProductSkuId)
  VALUES (30, 10, 200, SYSTIMESTAMP, v_store3_id, v_sku_id);

  INSERT INTO ProductSkus (SkuCode, "Size", Color, CostPrice, SellingPrice, IsActive, ProductId)
  VALUES ('P004-L-DEN', 'L', 'Đen', 300000, 650000, 1, v_prod4_id)
  RETURNING Id INTO v_sku_id;
  INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, LastUpdated, StoreId, ProductSkuId)
  VALUES (25, 10, 200, SYSTIMESTAMP, v_store2_id, v_sku_id);

  INSERT INTO ProductSkus (SkuCode, "Size", Color, CostPrice, SellingPrice, IsActive, ProductId)
  VALUES ('P005-ONE-NAU', 'One Size', 'Nâu', 400000, 850000, 1, v_prod5_id)
  RETURNING Id INTO v_sku_id;
  INSERT INTO Inventories (QuantityOnHand, ReorderPoint, MaxStockLevel, LastUpdated, StoreId, ProductSkuId)
  VALUES (15, 10, 200, SYSTIMESTAMP, v_store1_id, v_sku_id);

  COMMIT;
  DBMS_OUTPUT.PUT_LINE('Seed OK');
END;
/

