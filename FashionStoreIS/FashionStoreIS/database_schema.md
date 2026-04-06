# FashionStoreIS - Enterprise Database Schema (PostgreSQL)

Tài liệu này mô tả chi tiết kiến trúc Cơ sở dữ liệu (Database Schema) của dự án **FashionStoreIS (BN STORE)**. Dự án sử dụng **Entity Framework Core (EF Core)** với kỹ thuật Code-First, tối ưu hóa cho **PostgreSQL** và tương thích ngược với **Oracle 11g**.

Tất cả các bảng nghiệp vụ đều kế thừa `BaseEntity` với các trường mặc định:
- `Id` (INT/SERIAL, Primary Key)
- `CreatedAt` (TIMESTAMP): Thời điểm tạo bản ghi.
- `UpdatedAt` (TIMESTAMP): Thời điểm cập nhật cuối cùng.
- `IsDeleted` (BOOLEAN): Trạng thái xóa mềm (Soft Delete).

---

## 1. Phân hệ Thương Mại & Sản Phẩm (Catalog & Sales)

### `Categories`
Lưu trữ cây phân cấp danh mục sản phẩm.
- `Name`, `Slug`, `Description`, `ImageUrl`, `DisplayOrder`, `IsActive`
- `ParentCategoryId` (Self-referencing FK): Danh mục cha.

### `Products`
Thông tin tổng thể của sản phẩm.
- `Name`, `Slug`, `Price` (Base), `Description`, `ImageUrl`, `IsActive`
- `CategoryId` (FK), `SupplierId` (FK)

### `ProductSkus`
Biến thể chi tiết (Size/Color) của sản phẩm.
- `SKU`, `SkuCode`, `Size`, `Color`, `CostPrice`, `SellingPrice`, `PriceOverride`, `Stock`.
- **Note**: `Stock` được dùng làm `Concurrency Token` để tránh xung tranh khi thanh toán.

### `Orders` & `OrderDetails`
- `Orders`: `OrderCode`, `TotalAmount`, `SubTotal`, `DiscountAmount`, `Status`, `PaymentMethod`, `UserId` (FK), `CustomerId` (FK), `VoucherId` (FK).
- `OrderDetails`: `OrderId` (FK), `ProductId` (FK), `ProductSkuId` (FK), `Quantity`, `UnitPrice`, `Subtotal`, `DiscountPercent`.

### `Vouchers`
- `Code`, `DiscountAmount`, `MinOrderAmount`, `ExpiryDate`, `IsActive`, `MaxUsageCount`, `UsedCount`.

---

## 2. Phân Hệ Quản Trị Nhân Sự (HRM & Payroll)

### `Employees` & `Departments`
- `Employees`: `FullName`, `Position`, `BaseSalaryPerHour`, `Email`, `Phone`, `StoreId` (FK), `DepartmentId` (FK), `BankDetails`.
- `Departments`: `Name` (Phòng ban: Sales, Marketing, IT, v.v.).

### `Attendances` (Chấm công)
- `EmployeeId` (FK), `Date`, `CheckIn`, `CheckOut`, `TotalHours`.

### `Payrolls` & `PayrollItems`
- `Payrolls`: `Month`, `Year`, `TotalHoursWorked`, `BaseHourlyRate`, `TotalBaseSalary`, `TotalAdditions`, `TotalDeductions`, `NetSalary`, `Status`.
- `PayrollItems`: `PayrollId` (FK), `SalaryComponentId` (FK), `Amount`, `Note`.

### `SalaryComponents`
Định nghĩa các khoản Phụ cấp/Khấu trừ (Ăn trưa, Bảo hiểm, Thưởng chuyên cần).
- `Name`, `Type` (Addition/Deduction), `DefaultAmount`.

### `Shifts` & `Schedules`
- `Shifts`: Ca làm việc (Sáng, Chiều, Tối) kèm giờ bắt đầu/kết thúc.
- `Schedules`: Phân lịch làm việc cho từng `Employee` tại các `Shift`.

### `KpiReviews`
- `EmployeeId` (FK), `ReviewerId` (FK), `Month`, `Year`, `SalesScore`, `TeamworkScore`, `TotalScore`, `Rank` (A/B/C/D).
- **Note**: Rank này ảnh hưởng trực tiếp đến hệ số thưởng trong `Payroll`.

---

## 3. Phân Hệ Kho Vận & Chuỗi Cung Ứng (SCM)

### `Inventory` & `StockAdjustments`
- `Inventory`: Liên kết `StoreId` (FK) với `ProductSkuId` (FK) để theo dõi tồn kho tại từng điểm bán.
- `StockAdjustments`: Audit trail cho mọi thay đổi kho (Lý do: Bán hàng, Nhập hàng, Hao hụt, Hoàn trả).

### `PurchaseOrders` & `PurchaseOrderDetails`
- `PurchaseOrders`: Quản lý vận đơn nhập hàng từ Nhà cung cấp.
- `PurchaseOrderDetails`: `UnitCost` (Giá vốn nhập), `Quantity`, `Subtotal`.

### `Suppliers` & `Stores`
- Quản lý thông tin đối tác cung ứng và danh sách mạng lưới cửa hàng toàn hệ thống.

---

## 4. Phân Hệ CRM & Marketing

### `Customers`
Mở rộng thông tin người dùng từ `ApplicationUser`.
- `FullName`, `Phone`, `Email`, `UserId` (Identity FK).

### `LoyaltyTransactions`
- Nhật ký tích/đổi điểm thưởng (`Points`) của khách hàng dựa trên hóa đơn.

### `Campaigns` & `Notifications`
- `Campaigns`: Quản lý các chiến dịch Marketing qua Email/App gửi đến các Segments (Champions, At Risk, v.v.).
- `Notifications`: Hệ thống thông báo đẩy (Push notification) cho người dùng.

---

## 5. Metadata & Personalization
- `Banners`: Cấu hình ảnh quảng cáo trang chủ.
- `WishlistItems`: Danh sách sản phẩm yêu thích của khách hàng.
- `UserAddresses`: Sổ địa chỉ giao hàng.
- `ReturnRequests`: Quản lý quy trình đổi trả hàng.

---

## 6. Phân Hệ Phân Tích (Analytics Data Warehouse)
Lưu trữ tại `DataWarehouse.db` (SQLite) theo mô hình **Star Schema**:
- **Fact_Sales**: Chứa các sự kiện bán hàng và chỉ số tài chính (SalesAmount, COGS, GrossProfit).
- **Dim_Product**: Chiều thông tin sản phẩm (SCD Type 1/2).
- **Dim_Customer**: Chiều thông tin khách hàng và vùng địa lý.
- **Dim_Date**: Chiều thời gian (Ngày, Tháng, Quý, Năm, Cuối tuần).

---
*Tài liệu được cập nhật tự động dựa trên mã nguồn thực tế của ApplicationDbContext.*
