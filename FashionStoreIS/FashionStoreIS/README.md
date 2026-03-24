# 🌟 FashionStoreIS (BN STORE) - E-Commerce System

**FashionStoreIS** là một hệ thống thương mại điện tử chuyên biệt (E-Commerce) được xây dựng trên nền tảng **ASP.NET Core MVC** (.NET 8.0) với phong cách thiết kế Minimalism tối giản, hiện đại (Lấy cảm hứng từ Stressmama UI). 

Hệ thống được thiết kế để chịu tải cao, giải quyết các bài toán phức tạp về đồng bộ kho (`Data Concurrency`), Quản trị người dùng đa cấp độ (`Identity Roles`), và Phân tích Dữ liệu Data Warehouse (`ETL`).

---

## 🚀 Các Tính Năng Nổi Bật (Key Features)

### 1. Giao diện Cửa Hàng Hiện Đại (Storefront UI/UX)
- **Thiết kế Tối Giản (Minimalism)**: Product Grid mượt mà 4-cột, khoảng cách padding tiêu chuẩn, tập trung tối đa vào sản phẩm với thanh Sort/Filter Sticky-top. Hình ảnh Placeholder được thay bằng AI-Generated Premium Assets.
- **Mobile-First Navigation**: Hamburger Drawer Menu với Submenu Drop-down (Accordion) và thanh Search ẩn tinh tế.
- **Bộ Lọc Động (Dynamic Filtering)**: Hỗ trợ Filter theo Category (Áo, Quần, Giày Dép với size đặc biệt like 40,41,42) kết hợp với Giá, Từ khóa Tìm Kiếm. Phân trang Ajax cực xịn không mất Param.
- **Hồ Sơ Cá Nhân (User Profile)**: Redesign lại bảng điều khiển Khách Hàng chuyên nghiệp giống Shopee/Lazada (Menu tab ngang xử lý Đơn Hàng theo trạng thái Pending, Confirmed...). Có màn hình Empty-state sinh động.

### 2. Xử Lý Luồng Nghiệp Vụ Chặt Chẽ (Business Logic)
- **Tránh Xung Đột Thanh Toán (Optimistic Concurrency)**: Sử dụng kỹ thuật cấp phát Byte `RowVersion` cho bảng `ProductSkus` để chốt chặn Race Condition (2 khách mua cùng 1 áo cuối cùng).
- **Hủy Đơn Thông Minh (User Cancel Order) & Hoàn Kho**: Tích hợp luồng cho phép User tự hủy đơn. Khi hủy thành công ở trạng thái Pending, tự động nhả lại (Restore) số lượng Tồn kho (`Stock`) và Lượt áp Voucher. 
- **Bảo Vệ Tải File**: Trang bị thuật toán quét cấu trúc Hex "Magic Bytes" (JPEG/PNG/WEBP Headers) để lọc các hiểm họa Up-shell/Script độc diễn ra dưới vỏ bọc Đổi Avatar Profile.
- **Chống Đúp Chuột Giỏ Hàng**: Xử lý JS Spinner Loading State cho nút "Thêm vào giỏ" để vô hiệu hóa Spam Click Async.

### 3. Identity & Phân Quyền (Authentication & Roles)
- Sửa đổi hoàn toàn **ASP.NET Core Identity** để tương thích 100% với SQL Cú pháp nghiêm ngặt của Oracle 11g (Khắc phục mọi lỗi ORA-00933, ORA-02291 của OracleProvider).
- Bổ sung Custome fields (`AvatarUrl`, `MembershipPoints`) vào `ApplicationUser`.
- Admin Panel phân luồng quyền hạn `SuperAdmin` (Full access) và `Staff` rõ ràng. Dashboard Admin hiển thị chính xác mọi số liệu Tồn / Thu / Role. 

### 4. Data Warehouse & Power BI Endpoint
- Xây dựng riêng 1 Database độc lập (`analytics.db` - SQLite) bằng kiến trúc **Star Schema** (Fact & Dimensions).
- Hệ thống `IHostedService` (Background Worker) liên tục chạy ngầm (ETL Pipeline) kéo luồng Data Sales từ Oracle sang SQLite.
- Trích xuất tự động `COGS` (Giá vốn hàng bán qua các lô PurchaseOrder) lên PowerBI bằng Endpoint Export CSV `0-Driver Configuration`.

---

## 🛠 Nền Tảng Kỹ Thuật (Tech Stack)
- **Framework:** .NET 8.0, ASP.NET Core MVC
- **Database Chính (OLTP):** Oracle 11g Express Edition / Enterprise (Oracle.EntityFrameworkCore)
- **Database Phân tích (OLAP):** SQLite (Entity Framework Core)
- **Front-end:** HTML5, CSS3, JavaScript (jQuery AJAX), Bootstrap 5, FontAwesome 6, Google Fonts (Inter/Outfit).
- **ORMs:** Entity Framework Core Code-First Migrations.

---

## ⚙ Hướng dẫn Cài đặt & Khởi chạy (Setup Guide)

1. **Yêu Cầu Hệ Thống:**
   - .NET 8 SDK
   - Oracle Database 11g (XE hoặc EE) đang chạy ở cổng 1521.
   - User schema đã tạo sẵn (`C##FASHIONSTORE` hoặc tùy chỉnh theo ConnectionString).

2. **Cấu hình Connection Strings (appsettings.json):**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=C##USER;Password=PASSWORD;",
     "AnalyticsConnection": "Data Source=analytics.db"
   }
   ```

3. **Tạo Database & Seeding Data:**
   - Mở Terminal tại Folder chứa `FashionStoreIS.csproj`
   - Chạy lệnh cập nhật Database:
     ```bash
     dotnet ef database update
     ```
   - Chạy Project: `dotnet run`
   - *Lưu ý*: Lớp `DbInitializer` sẽ tự động tiêm (Seed) hàng chục sản phẩm Mẫu Cao cấp, Categories, SKUs, Tài khoản User (`admin@bnstore.vn`/ `Admin@123`) ngay trong lần chạy đầu tiên.

4. **Khu Vực Quản Trị (Admin Panel):**
   - Đăng nhập bằng tài khoản `SuperAdmin`
   - Bấm vào link **Khu Vực Quản Trị** ở Nav Menu để vào hệ thống chỉnh sửa Catalog, Voucher, Order. Dữ liệu ChartJS sẽ báo cáo tự động tại đây.

---
**FashionStoreIS** không chỉ là một Project bài tập mà đã vươn tầm thành một Architecture vững chắc, sẵn sàng để Scale-up (Mở rộng) cho các nghiệp vụ Bán lẻ thực tế. Chúc bạn có một trải nghiệm code và test hoàn hảo! 🚀
