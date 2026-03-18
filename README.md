# StyleVibe Fashion MIS

Hệ thống thông tin quản lý tích hợp toàn diện cho chuỗi bán lẻ thời trang StyleVibe.

## 🏗️ Kiến trúc

Dự án được xây dựng theo **Clean Architecture** với 4 lớp:

- **StyleVibe.Domain**: Entities, Enums, Interfaces (Core domain)
- **StyleVibe.Application**: Services, DTOs, Business Logic
- **StyleVibe.Infrastructure**: DbContext, Repositories, External Services
- **StyleVibe.Web**: Controllers, Views, Presentation Layer

## 📦 Công nghệ sử dụng

- **.NET 10.0** (ASP.NET Core MVC)
- **Entity Framework Core 10.0.4**
- **Oracle DB** (đang dùng trong source hiện tại)
- **Bootstrap 5.3**
- **Python FastAPI** (DSS/ML Service - đang phát triển)

## ✅ Đã hoàn thành

### 1. Kiến trúc & Database
- ✅ Clean Architecture với 4 projects
- ✅ Domain Entities đầy đủ (Stores, Products, Orders, Inventory, Customers, Employees, Loyalty, PurchaseOrders)
- ✅ DbContext với EF Core configuration
- ✅ Enums (OrderStatus, PaymentMethod, CustomerTier, StockAdjustmentReason)

### 2. UI Theme
- ✅ Custom CSS theme theo phong cách fashion e-commerce (đen/trắng/xám với accent đỏ)
- ✅ Responsive layout với Bootstrap 5
- ✅ Navigation menu với dropdown cho Admin

### 3. User Storefront
- ✅ **Products Controller & Views**: Browse products, filter by category, product details
- ✅ **Cart Controller**: Shopping cart với sessionStorage
- ✅ **Product Service**: Get products, categories, SKUs

### 4. POS Module
- ✅ **POS Controller**: Màn hình bán hàng tại quầy
- ✅ **POS Service**: Tạo đơn hàng, cập nhật tồn kho, tích điểm loyalty
- ✅ Flow: Chọn cửa hàng → Thêm SKU vào giỏ → Thanh toán → Tự động trừ tồn kho

### 5. Admin Dashboard
- ✅ **Admin Dashboard**: KPI cards (Tổng sản phẩm, đơn hàng, khách hàng, doanh thu)
- ✅ Doanh thu tháng này vs tháng trước
- ✅ Top 10 sản phẩm bán chạy
- ✅ Quick actions links

## 🚧 Đang phát triển / Cần làm tiếp

### 1. Admin CRUD Modules
- [ ] **AdminProductsController**: CRUD sản phẩm, SKUs
- [ ] **AdminOrdersController**: Xem danh sách đơn hàng, chi tiết, filter
- [ ] **AdminInventoryController**: Quản lý tồn kho, stock adjustments
- [ ] **AdminCustomersController**: Quản lý khách hàng, loyalty points
- [ ] **AdminEmployeesController**: Quản lý nhân viên

### 2. MIS Reports
- [ ] Tích hợp SQL Views (`vw_DailyRevenue`, `vw_ProductSales`, `vw_MonthlySummary`)
- [ ] Export Excel/PDF (ClosedXML, QuestPDF)
- [ ] Charts với ApexCharts.js

### 3. DSS / ML Service (Python FastAPI)
- [ ] `/forecast/sales` - Dự báo doanh thu (Prophet)
- [ ] `/forecast/demand` - Dự báo nhu cầu per SKU (XGBoost)
- [ ] `/analysis/rfm` - Phân tích RFM khách hàng (scikit-learn)
- [ ] `/dss/restock` - Gợi ý đặt hàng (ROP formula)
- [ ] `/simulation/price-change` - What-if price simulation
- [ ] `/dss/auto-decisions` - Top 5 gợi ý hành động tự động

### 4. Database Setup
- [ ] EF Core Migrations
- [ ] Seed data (Stores, Categories, Products, SKUs, Inventory)
- [ ] SQL Views creation script

## 🚀 Hướng dẫn chạy

### Prerequisites
- .NET SDK 10.0+
- SQL Server (LocalDB hoặc SQL Server Express)
- Visual Studio 2022 hoặc VS Code

### Setup Database (Oracle)

1. Thiết lập connection string (khuyến nghị dùng biến môi trường để tránh hardcode mật khẩu):

- **Windows PowerShell**:

```powershell
$env:ORACLE_CONNECTION_STRING="User Id=...;Password=...;Data Source=localhost:1521/XE"
```

2. Hoặc set trong `appsettings.Development.json` / `appsettings.json` (không nên commit mật khẩu).

Ví dụ (không chứa mật khẩu thật):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=...;Password=...;Data Source=localhost:1521/XE"
  }
}
```

3. Tạo migration và update database:
```powershell
cd StyleVibe.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../StyleVibe.Web
dotnet ef database update --startup-project ../StyleVibe.Web
```

4. Seed dữ liệu demo:
```powershell
# Oracle seed script: StyleVibe.Web/Data/SeedData.oracle.sql
```

### Chạy ứng dụng

```powershell
cd StyleVibe.Web
dotnet run
```

Truy cập: `https://localhost:5001` hoặc `http://localhost:5000`

## 📁 Cấu trúc thư mục

```
StyleVibe/
├── StyleVibe.Domain/          # Core domain entities & enums
│   ├── Entities/
│   ├── Enums/
│   └── Common/
├── StyleVibe.Application/      # Business logic & services
│   ├── Interfaces/
│   └── Services/
├── StyleVibe.Infrastructure/   # Data access & external services
│   └── Data/
└── StyleVibe.Web/              # Presentation layer
    ├── Controllers/
    ├── Views/
    └── wwwroot/
```

## 📝 Notes

- **POS Module**: Hiện tại dùng SKU Id để demo. Có thể cải tiến với autocomplete/search sản phẩm.
- **Cart**: Dùng sessionStorage cho demo. Production nên dùng database hoặc Redis.
- **DSS Service**: Sẽ chạy độc lập trên port 8000, giao tiếp với .NET qua HTTP REST API.

## 👥 Tác giả

- **Môn học**: ITE1129E – Hệ thống thông tin quản lý
- **Giảng viên**: Trần Thành Công
- **Lớp**: B01E – HK2B 2025-2026

---

**Version**: 1.0.0  
**Last Updated**: 2026
