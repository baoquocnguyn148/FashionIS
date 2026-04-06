# 🌟 FashionStoreIS (BN STORE) - Enterprise MIS & E-Commerce System

**FashionStoreIS (BN STORE)** là một hệ thống thông tin quản lý (MIS) và thương mại điện tử (E-Commerce) quy mô lớn, được xây dựng trên nền tảng **ASP.NET Core 10.0** mới nhất. Hệ thống không chỉ phục vụ việc bán hàng trực tuyến mà còn tích hợp các phân hệ quản lý doanh nghiệp (ERP) chuyên sâu như Nhân sự (HRM), Kho vận (SCM), và Phân tích chiến lược (BI).

---

## 🚀 Các Phân Hệ Chính (Core Modules)

### 1. Hệ Thống Thương Mại Điện Tử (Storefront & POS)
- **Thiết kế Luxury Minimalism**: Giao diện tối giản, tập trung vào sản phẩm, lấy cảm hứng từ các thương hiệu thời trang cao cấp.
- **Tính năng Động**: Bảng size thông minh (Size Guide) và hệ thống Voucher tương tác hỗ trợ sao chép mã nhanh.
- **POS (Point of Sale)**: Tích hợp tại quầy cho phép quét SKU, thanh toán và in hóa đơn đồng bộ với kho tổng.
- **Thanh toán VnPay**: Tích hợp cổng thanh toán 2.1.0 với bảo mật HMACSHA512.

### 2. Quản Trị Nhân Sự & Tiền Lương (HRM & Payroll)
- **Chấm Công (Attendance)**: Theo dõi giờ làm việc, tự động tính toán tăng ca (OT).
- **Tính Lương Thông Minh**: Tính toán Net Salary dựa trên giờ công thực tế, phụ cấp, khấu trừ và đặc biệt là thưởng/phạt dựa trên **KPI Rank**.
- **Quản lý Nghỉ Phép**: Quy trình duyệt đơn phép (`LeaveRequest`) và theo dõi số dư phép còn lại.
- **Đánh Giá KPI**: Đánh giá năng lực nhân viên theo từng tháng để tối ưu hóa hiệu suất làm việc.

### 3. Quản Trị Chuỗi Cung Ứng & Kho (SCM & Inventory)
- **Đa Chi Nhánh (Multi-Store)**: Quản lý tồn kho biệt lập theo từng cửa hàng nhưng báo cáo tập trung.
- **Quy Trình Nhập Hàng (PO)**: Từ lập đơn nhập (`PurchaseOrder`) đến giá vốn hàng bán (`UnitCost`), hỗ trợ đo lường biên lợi nhuận (`Gross Margin`).
- **Audit Kho**: Nhật ký biến động kho (`StockAdjustments`) giúp minh bạch mọi giao dịch xuất/nhập/hao hụt.

### 4. Hệ Thống Hỗ Trợ Ra Quyết Định (DSS & Strategic BI)
- **Phân Khúc RFM**: Tự động phân loại khách hàng (Champions, At Risk, Loyal...) hỗ trợ chiến dịch Marketing cá nhân hóa.
- **Phân Tích ABC**: Phân loại danh mục sản phẩm dựa trên sức đóng góp doanh thu.
- **Dự Báo Tài Chính (Forecasting)**: Sử dụng các mô hình hồi quy để dự đoán dòng tiền và nhu cầu thị trường.
- **Hybrid DB Strategy**: Hệ thống ETL tự động chuyển đổi dữ liệu từ Transaction DB sang **Data Warehouse (SQLite)** phục vụ báo cáo.

---

## 🛠 Nền Tảng Kỹ Thuật (Tech Stack)
- **Framework:** .NET 10.0, ASP.NET Core MVC
- **Database Chính (OLTP):** PostgreSQL (mặc định) / Oracle 11g (tương thích hoàn toàn)
- **Database Phân tích (OLAP):** SQLite (Fact & Dimensions Star Schema)
- **Thư viện chính:** Entity Framework Core, Identity Auth, VnPay SDK, ClosedXML (Excel Export), Chart.js.
- **Thiết kế:** Vanilla CSS Custom, Bootstrap 5, FontAwesome 6, Google Fonts (Outfit/Inter).

---

## ⚙ Hướng dẫn Cài đặt & Khởi chạy (Setup Guide)

1. **Yêu Cầu Hệ Thống:**
   - [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
   - PostgreSQL 14+ hoặc Oracle 11g.

2. **Cấu hình Connection Strings (`appsettings.json`):**
   ```json
   "ConnectionStrings": {
     "PostgresConnection": "Host=localhost;Database=fashionstore_migrated_v2;Username=postgres;Password=YOUR_PASSWORD;",
     "AnalyticsConnection": "Host=localhost;Database=analytics_migrated_v2;Username=postgres;Password=YOUR_PASSWORD;"
   }
   ```

3. **Khởi Chạy Hệ Thống:**
   - Cập nhật Database:
     ```bash
     dotnet ef database update
     ```
   - Chạy dự án: `dotnet run`
   - **Tài khoản Admin mật định:** `admin@bnstore.vn` / `Admin@123`
   - *Lưu ý*: Lần đầu tiên chạy, `DbInitializer` sẽ tự động tạo dữ liệu mẫu bao gồm hàng chục khách hàng, đơn hàng, dữ liệu KPI và Payroll để bạn kiểm tra tính năng MIS.

---

**FashionStoreIS** không chỉ là một trang web bán hàng, mà là một giải pháp quản trị doanh nghiệp toàn diện, sẵn sàng cho các nghiệp vụ bán lẻ thực tế ở quy mô chuỗi cửa hàng. 🚀
