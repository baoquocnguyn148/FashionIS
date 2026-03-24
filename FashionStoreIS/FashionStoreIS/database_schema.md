# FashionStoreIS - Database Schema Layout

Tài liệu này mô tả chi tiết kiến trúc Cơ sở dữ liệu (Database Schema) của dự án **FashionStoreIS (BN STORE)**. Dự án sử dụng **Entity Framework Core (EF Core)** với kỹ thuật Code-First trên nền tảng **Oracle 11g**.

Tất cả các bảng dưới đây đều kế thừa `BaseEntity` với các trường mặc định:
- `Id` (INT, Primary Key)
- `CreatedAt` (DATETIME2)
- `UpdatedAt` (DATETIME2)

---

## 1. Hệ thống Quản lý Sản phẩm (Catalog)

### `Categories` (Danh mục)
Lưu trữ cây phân cấp danh mục sản phẩm.
- `Name` (NVARCHAR): Tên danh mục (vd: Áo, Quần)
- `Slug` (VARCHAR): Đường dẫn URL thân thiện
- `Description` (NVARCHAR): Đoạn mô tả
- `DisplayOrder` (INT): Thứ tự hiển thị
- `IsActive` (BIT): Bật/Tắt
- `ParentCategoryId` (INT, Lookup `Categories`): ID của danh mục cha (để tạo Sub-menu)

### `Products` (Sản phẩm)
Thông tin tổng thể của một dòng sản phẩm.
- `CategoryId` (INT, Foreign Key): ID của Danh mục
- `Name` (NVARCHAR(200)): Tên sản phẩm
- `Slug` (VARCHAR(200)): Đường dẫn thân thiện
- `ShortDescription` (NVARCHAR): Mô tả ngắn
- `Description` (NVARCHAR): Mô tả chi tiết (HTML)
- `Price` (DECIMAL): Giá bán gốc
- `SellingPrice` (DECIMAL): Giá khuyến mãi
- `ImageUrl` (NVARCHAR): URL ảnh đại diện chính
- `Stock` (INT): Số lượng tổng tồn kho
- `IsActive` (BIT): Bật/Tắt hiển thị

### `ProductSkus` (Biến thể Sản phẩm / SKU)
Lưu trữ Size, Màu sắc và số lượng tồn kho chi tiết của từng thuộc tính cụ thể.
- `ProductId` (INT, Foreign Key): Bảng `Products`
- `SkuCode` (VARCHAR(50)): Mã SKU vạch
- `Size` (NVARCHAR(50)): Kích thước (vd: S, M, L, XL, 40, 41)
- `Color` (NVARCHAR(50)): Màu sắc
- `Stock` (INT): Tồn kho của biến thể này
- `PriceOverride` (DECIMAL, Nullable): Giá tiền ghi đè (nếu biến thể đắt/rẻ hơn)
- `IsActive` (BIT): Bật/Tắt
- `RowVersion` (BYTE[]): Dùng để xử lý Optimistic Concurrency (Xung đột tranh tiền khi Checkout)

### `ProductImages` (Thư viện Ảnh Gallery)
- `ProductId` (INT, Foreign Key): Bảng `Products`
- `ImageUrl` (NVARCHAR(500)): URL ảnh
- `DisplayOrder` (INT): Cấu hình thứ tự ảnh trên PDP (Product Detail Page)

---

## 2. Hệ thống Mua hàng & Vận hành (Order & Fulfillment)

### `Orders` (Đơn hàng)
Lưu trữ thông tin giỏ hàng đã thanh toán/đặt trước của khách.
- `OrderCode` (VARCHAR): Mã hiển thị hóa đơn (HN-10023)
- `UserId` (VARCHAR, FK): Trỏ tới `AspNetUsers` (Nếu đã đăng nhập)
- `CustomerId` (INT, FK): Trỏ tới User Profile thông tin đầy đủ
- `StoreId` (INT, FK): Chi nhánh chịu trách nhiệm
- `VoucherId` (INT, Nullable FK): Mã KM áp dụng
- `Status` (Enum): `Pending`, `Confirmed`, `Processing`, `Shipped`, `Completed`, `Cancelled`
- `PaymentMethod` (Enum): `Cash` (COD), `Transfer`, `CreditCard`
- `PaymentStatus` (Enum): `Unpaid`, `Paid`, `Refunded`
- `TotalAmount` (DECIMAL): Tổng tiền thanh toán
- `DiscountAmount` (DECIMAL): Số tiền được giảm 
- `CustomerName`, `Phone`, `Address`: Lưu cứng địa chỉ giao hàng tại thời điểm đặt

### `OrderDetails` (Chi tiết Đơn hàng)
- `OrderId` (INT, FK): ID Đơn hàng
- `ProductId` (INT, Nullable FK): ID Sản phẩm gốc
- `ProductSkuId` (INT, Nullable FK): ID Biến thể
- `Quantity` (INT): Số lượng mua
- `UnitPrice` (DECIMAL): Giá tiền 1 đơn vị
- `DiscountPercent` (DECIMAL): % KM riêng lẻ (nếu có)
- `Subtotal` (DECIMAL): `(UnitPrice * Quantity)`

### `Vouchers` (Khuyến mãi)
- `Code` (VARCHAR(50)): Mã Code giảm giá (vd: TET2026)
- `Description` (NVARCHAR)
- `DiscountType` (Enum): `Percent` (Phần trăm), `Amount` (Tiền mặt trực tiếp)
- `DiscountValue` (DECIMAL): Giá trị giảm (vd: Tiền=20k, % = 10)
- `MinOrderValue` (DECIMAL): Giá trị ĐH tối thiểu
- `MaxDiscountAmount` (DECIMAL): Số tiền giảm tối đa (nếu dùng %)
- `UsageLimit` (INT): Giới hạn lượt sử dụng tổng 
- `UsedCount` (INT): Lượt đã dùng
- `StartDate` (DATETIME2)
- `EndDate` (DATETIME2)

---

## 3. Hệ thống Logistic Nội bộ (Supply Chain)

### `PurchaseOrders` (Đơn Nhập Hàng)
Quản lý luồng nhập sản phẩm/vật tư vào Kho chi nhánh từ Nhà cung cấp.
- `PurchaseOrderCode` (VARCHAR)
- `SupplierId` (INT, FK): Trỏ tới `Suppliers`
- `StoreId` (INT, FK): Trỏ tới `Stores` (Chi nhánh nhập kho)
- `ApplicationUserId` (VARCHAR, FK): Trỏ tới nhân viên thực hiện (Nhân viên kho)
- `Status` (Enum): `Draft`, `Pending`, `Approved`, `Completed`, `Cancelled`
- `TotalAmount` (DECIMAL): Tổng giá trị nhập

### `PurchaseOrderDetails` (Chi tiết đơn nhập)
- `PurchaseOrderId` (INT)
- `ProductId`, `ProductSkuId`: ID Sản phẩm/Biến thể
- `UnitCost` (DECIMAL): Giá vốn nhập khẩu (Phục vụ đo lường COGS / Margin)
- `Quantity` (INT): Số lượng lô hàng
- `SubTotal` (DECIMAL)

### `Stores` (Chi nhánh Shop)
- `Name`, `Address`, `Phone`, `Email`, `IsActive`

### `Suppliers` (Nhà Cung Cấp)
- `Name`, `ContactName`, `Phone`, `Email`, `Address`

---

## 4. Bảo mật và Người dùng (Identity & Users)

Dự án mở rộng dựa trên **ASP.NET Core Identity** (các bảng mặc định `AspNetUsers`, `AspNetRoles`, v.v..).
Class `ApplicationUser` bổ sung thêm các thuộc tính:
- `FullName` (NVARCHAR)
- `AvatarUrl` (NVARCHAR): Link ảnh Profile
- `DateOfBirth` (DATETIME)
- `Gender` (VARCHAR)
- `CustomerTier` (Enum): Cấp VIP của tài khoản
- `MembershipPoints` (INT): Điểm thân thiết

### `Customers` (Bản ghi Khách hàng Vật lý)
- `ApplicationUserId` (VARCHAR, Nullable FK): Liên kết với tk Identity.
- `UserId` (VARCHAR)
- `FullName`, `Email`, `PhoneNumber`, `Address`, `City`, `District`, `Ward`

### `Employees` (Nhân sự & Nhân viên Cửa hàng)
- `ApplicationUserId` (VARCHAR, FK): Liên kết với tk Identity (Admin/Staff).
- `UserId` (VARCHAR)
- `FullName`, `Email`, `PhoneNumber`, `Role` (Enum), `StoreId` (FK)

### `LoyaltyTransactions` (Giao dịch Điểm thưởng)
- `ApplicationUserId` (VARCHAR, FK): Trỏ tới User.
- `Points` (INT): Khoản cộng/trừ điểm.
- `Type` (Enum): `Earned` (Tích lũy), `Redeemed` (Tiêu thụ), `Refunded` (Hoàn trả).
- `Description` (NVARCHAR), `ReferenceId` (INT - Đơn hàng liên quan)

---

## 5. Quản lý Tồn kho & Cấu hình Hiển thị Hệ thống (Misc)

### `Banners` (Bảng rôn & Pop-up KM)
Cấu hình đồ thị Hero banner trang chủ.
- `Title` (NVARCHAR)
- `ImageUrl` (NVARCHAR): File ảnh quảng cáo.
- `LinkUrl` (VARCHAR): Trỏ tới list SP Sale
- `IsActive` (BIT), `DisplayOrder` (INT)
- `StartDate`, `EndDate` (DATETIME2)

### `Inventory` (Kiểm kho)
Giám sát chi tiết luồng tồn cho kho cụ thể (Support Multi-Store POS).
- `StoreId` (INT, FK), `ProductId` (INT, FK), `ProductSkuId` (INT, FK)
- `Stock` (INT): Tồn ở chi nhánh này.

### `StockAdjustments` (Chi tiết Biến động Kho Cục Bộ)
Audit Trail dùng để giải trình số tồn hao hụt.
- `InventoryId` (INT, FK)
- `Type` (Enum): `Addition` (Cộng vào), `Subtraction` (Trừ đi)
- `Quantity` (INT)
- `Reason` (Enum): `Restock`, `Sale`, `Return`, `Damage`, `Loss`.

---

## 6. Phân hệ Data Warehouse Analytics (SQLite Độc lập)
Không sử dụng Oracle mà lưu xuất song song sang DB `analytics.db` phục vụ PowerBI.
Gồm các bảng **Star Schema**:
- `Fact_Sales` (Sự kiện Mua Hàng)
- `Dim_Product` (Chiều dữ liệu SP)
- `Dim_Customer` (Khách hàng)
- `Dim_Date` (Mốc thời gian)
