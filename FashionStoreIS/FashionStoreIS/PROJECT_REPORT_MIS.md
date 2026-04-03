# BÁO CÁO ĐỒ ÁN MÔN HỌC
## PHÁT TRIỂN HỆ THỐNG THÔNG TIN QUẢN LÝ (MIS)
### Tên đề tài: XÂY DỰNG HỆ THỐNG QUẢN TRỊ DOANH NGHIỆP THỜI TRANG ĐA CHI NHÁNH (FASHIONSTOREIS - BN STORE)

**Sinh viên thực hiện:** [Tên của bạn]
**Mã số sinh viên:** [MSSV của bạn]
**Lớp:** [Tên lớp]
**Giảng viên hướng dẫn:** [Tên giảng viên]
**Ngày hoàn thành:** 01/04/2026

---

## LỜI NÓI ĐẦU

Trong kỷ nguyên kinh tế số, ngành bán lẻ thời trang không còn chỉ dừng lại ở việc bán hàng trực tiếp mà đã chuyển mình thành một hệ sinh thái dữ liệu phức tạp. Việc quản lý hiệu quả một chuỗi thời trang đa chi nhánh đòi hỏi sự kết hợp nhuần nhuyễn giữa hoạt động vận hành (POS), quản trị chuỗi cung ứng (SCM), quan hệ khách hàng (CRM) và đặc biệt là năng lực phân tích dữ liệu chuyên sâu để hỗ trợ ra quyết định (DSS/ESS).

Đồ án mã nguồn **FashionStoreIS (BN STORE)** được xây dựng nhằm giải quyết bài toán quản trị toàn diện cho một doanh nghiệp thời trang hiện đại, từ khâu nhập hàng, tối ưu kho bãi đến việc phân tích hành vi khách hàng và dự báo chiến lược cho cấp lãnh đạo.

---

## CHƯƠNG 1: TỔNG QUAN VỀ HỆ THỐNG

### 1.1 Khái niệm dự án
**FashionStoreIS** là một Hệ thống Thông tin Quản lý (MIS) quy mô doanh nghiệp, được thiết kế theo mô hình kiến trúc phân tầng, tập trung vào khả năng mở rộng và xử lý dữ liệu lớn. Hệ thống phục vụ hai nhóm đối tượng chính:
1.  **Nhân viên vận hành & Khách hàng**: Thông qua giao diện POS, E-commerce và quản lý kho.
2.  **Cấp quản lý & Giám đốc (CEO/Executive)**: Thông qua các dashboard phân tích thông minh và hệ thống hỗ trợ ra quyết định (ESS).

### 1.2 Mục tiêu của hệ thống
- **Tự động hóa vận hành**: Quản lý đơn hàng, thanh toán trực tuyến (VnPay), quản lý kho đa điểm.
- **Tối ưu hóa nguồn lực**: Cảnh báo tồn kho thông minh, tối ưu hóa danh mục sản phẩm (Catalog).
- **Cá nhân hóa trải nghiệm**: Phân khúc khách hàng dựa trên hành vi mua sắm (RFM Analysis).
- **Hỗ trợ chiến lược**: Cung cấp các chỉ số tài chính (Revenue, Profit, Margin) và dự báo thị trường dựa trên dữ liệu thực tế.

---

## CHƯƠNG 2: KIẾN TRÚC VÀ CÔNG NGHỆ

Hệ thống được xây dựng trên những nền tảng công nghệ tiêu chuẩn doanh nghiệp hiện nay:

### 2.1 Backend & Middleware
- **Framework**: ASP.NET Core 9.0 (C#) - Hiệu năng cao, bảo mật và hỗ trợ Dependency Injection mạnh mẽ.
- **ORM (Object-Relational Mapping)**: Entity Framework Core (Code-First) - Quản trị database thông qua mã nguồn, dễ dàng di trú (Migration).
- **Security**: ASP.NET Core Identity tích hợp RBAC (Role-Based Access Control) giúp quản lý quyền hạn chi tiết (Admin, Staff, Customer).

### 2.2 Cơ sở dữ liệu (Database Architecture)
Hệ thống sử dụng kiến trúc **Hybrid Database** để tối ưu hóa cả tính ổn định và năng lực phân tích:
- **Oracle 11g (Primary Database)**: Lưu trữ toàn bộ dữ liệu giao dịch (OLTP). Đảm bảo tính toàn vẹn (ACID) cho các giao dịch mua bán, thanh toán và quản lý người dùng.
- **SQLite (Analytics/Executive Storage)**: Đóng vai trò như một **Data Warehouse** mini. Dữ liệu từ Oracle được trích xuất (ETL) sang SQLite để phục vụ các truy vấn phân tích phức tạp, tránh gây gánh nặng cho database chính.

### 2.3 Frontend & UI/UX
- **Razor Pages & MVC**: Công cụ dựng trang mạnh mẽ tích hợp sẵn trong ASP.NET Core.
- **CSS Framework**: Vanilla CSS & Custom Design System - Tạo giao diện chuyên nghiệp, mượt mà (Luxury Look).
- **Data Visualization**: **Chart.js** - Chuyển đổi dữ liệu thô thành các biểu đồ tương tác sinh động cho quản lý.

---

## CHƯƠNG 3: THIẾT KẾ CƠ SỞ DỮ LIỆU

Hệ thống được thiết kế với hơn 30 bảng, chia thành các phân hệ logic:

### 3.1 Phân hệ Sản phẩm & Tồn kho (Catalog & Inventory)
- `Products`, `Categories`, `ProductSkus`: Quản lý biến thể màu sắc, kích thước.
- `Inventory`, `StockAdjustments`: Theo dõi biến động kho theo từng chi nhánh.
- `PurchaseOrders`: Quản lý luồng nhập hàng từ nhà cung cấp (Suppliers).

### 3.2 Phân hệ Giao dịch (Order & Payment)
- `Orders`, `OrderDetails`: Lưu trữ lịch sử mua hàng.
- `Vouchers`, `Campaigns`: Quản lý các chương trình khuyến mãi và Marketing.
- `VnPayIntegration`: Tích hợp cổng thanh toán trực tuyến.

### 3.3 Phân hệ Khách hàng (CRM & Identity)
- `ApplicationUser`: Mở rộng từ IdentityUser để lưu trữ Loyalty Points và Profile.
- `Customers`, `Employees`: Thông tin chi tiết chủ thể trong hệ thống.
- `LoyaltyTransactions`: Theo dõi lịch sử tích điểm và đổi thưởng.

### 3.4 Data Warehouse Schema (Analytics)
Hệ thống sử dụng mô hình **Star Schema** phục vụ BI:
- **Fact_Sales**: Lưu trữ sự kiện bán hàng.
- **Dim_Product, Dim_Customer, Dim_Date**: Các chiều dữ liệu để lọc và tổng hợp báo cáo.

---

## CHƯƠNG 4: CÁC PHÂN HỆ CHỨC NĂNG CHÍNH

### 4.1 Quản lý Bán hàng & Trải nghiệm Khách hàng
- **Hệ thống POS (Point of Sale)**: Tích hợp tại cửa hàng cho phép nhân viên quét mã SKU, áp dụng Voucher và thanh toán nhanh.
- **Thanh toán trực tuyến**: Tích hợp VnPay giúp khách hàng thanh toán an toàn qua Mobile Banking hoặc ví điện tử.
- **Loyalty Program**: Hệ thống tích điểm tự động dựa trên giá trị đơn hàng, xếp hạng hội viên (Tier).

### 4.2 Quản trị Chuỗi cung ứng (SCM)
- **Quản lý đa kho**: Chuyển hàng giữa các chi nhánh, kiểm kê tồn kho theo thời gian thực.
- **Quy trình nhập hàng (Procurement)**: Từ lập đơn nhập (PO) đến xác nhận nhập kho (GRN), tính toán giá vốn nhập (Unit Cost) để xác định lợi nhuận gộp (Gross Margin).

---

## CHƯƠNG 5: HỆ THỐNG HỖ TRỢ RA QUYẾT ĐỊNH (DSS & ESS)

Đây là phân hệ tinh hoa nhất của **FashionStoreIS**, giúp hệ thống từ một phần mềm quản lý đơn thuần trở thành một **Hệ thống Thông tin Chiến lược**.

### 5.1 Strategic Analytics (ESS)
Sử dụng `StrategicAnalyticsService` để tính toán các chỉ số tài chính vĩ mô:
- **Phân tích Doanh thu & Lợi nhuận**: Theo dõi CAGR (tỷ lệ tăng trưởng kép), Net Profit Margin.
- **Dự báo Tài chính (Financial Forecasting)**: Sử dụng thuật toán hồi quy (simulated) để dự báo dòng tiền 6 tháng tiếp theo.

### 5.2 CRM Intelligence (Phân khúc RFM)
Sử dụng `RfmSegmentationService` để phân loại khách hàng dựa trên:
- **Recency**: Lần cuối mua hàng.
- **Frequency**: Tần suất mua.
- **Monetary**: Tổng giá trị chi tiêu.
*Hệ thống tự động phân nhóm thành: Champions, Loyal, At Risk, Hibernating... để quản lý có chiến dịch Marketing phù hợp.*

### 5.3 Inventory Intelligence
Dịch vụ `InventoryIntelligenceService` giúp:
- **Phân tích ABC**: Phân loại sản phẩm dựa trên đóng góp doanh thu (A: 80% doanh thu, B: 15%, C: 5%).
- **Cảnh báo vượt ngưỡng**: Tự động thông báo khi mặt hàng Hot sắp hết hoặc tồn kho quá lâu (Dead stock).

### 5.4 External Data Integration
Tích hợp dữ liệu từ thị trường (Market Analysis):
- Theo dõi giá đối thủ cạnh tranh (Competitor tracking).
- Phân tích xu hướng (Market Trend) và tâm lý người tiêu dùng (Sentiment Analysis).

---

## KẾT LUẬN

**FashionStoreIS** không chỉ là một ứng dụng web, mà là một giải pháp quản trị doanh nghiệp toàn diện. Thông qua việc kết hợp giữa dữ liệu giao dịch mạnh mẽ trên Oracle và năng lực phân tích thông minh trên SQLite, hệ thống mang lại cái nhìn 360 độ về sức khỏe doanh nghiệp.

**Thành quả đạt được:**
- Xây dựng thành công kiến trúc đa Database linh hoạt.
- Triển khai được các dịch vụ phân tích dữ liệu chuyên sâu (RFM, ABC, Forecasting).
- Giao diện Admin Dashboards trực quan, sẵn sàng cho việc điều hành thực tế.

---
*Tài liệu này được soạn thảo dựa trên cấu trúc kỹ thuật thực tế của mã nguồn dự án FashionStoreIS.*
