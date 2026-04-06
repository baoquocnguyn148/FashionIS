# 🌟 BN STORE - E-Commerce Management Information System (MIS)

**BN STORE (FashionStoreIS)** là hệ thống thương mại điện tử chuyên biệt được xây dựng trên nền tảng **ASP.NET Core MVC 8.0**. Dự án áp dụng kiến trúc **Clean Code & Monolith**, thiết kế giao diện Minimalist hiện đại nhằm tối ưu hóa trải nghiệm người dùng (UX) và hiệu suất hệ thống (Performance).

Hệ thống quản lý toàn diện vòng đời mua sắm: từ danh mục sản phẩm (Mega Catalog), chi tiết sản phẩm, giỏ hàng, cho đến quy trình đặt hàng tích hợp kiểm soát đồng thời (Concurrency Control), tự động hóa quản trị tồn kho và khuyến mãi.

---

## 📸 Giao diện Hệ thống (Screenshots)

### 1. Minimalist Homepage (Trang Chủ)
Giao diện tiếp cận người dùng với phong cách thời trang cao cấp, tối ưu hóa Hero Banner và Navigation Bar trong suốt.
<br>
![Homepage Hero](docs/images/homepage.png)

### 2. Mega Catalog Grid (Danh Mục Sản Phẩm)
Lưới sản phẩm 4-cột, kết hợp thanh công cụ Sort/Filter dính (Sticky-top). Tích hợp AJAX Filter đa chiều không yêu cầu tải lại trang.
<br>
![Product List Grid](docs/images/product_list.png)

### 3. Product Detail Page (Chi Tiết Sản Phẩm)
Quản lý biến thể màu sắc và kích cỡ (Color/Size). Tích hợp thuật toán chặn thao tác kép (Double Submission Prevention) trên nút thêm vào giỏ hàng.
<br>
![Product Detail](docs/images/product_detail.png)

### 4. Identity & Security (Thành viên & Bảo mật)
Sử dụng ASP.NET Core Identity tương thích với Oracle 11g. Tích hợp xác thực cấu trúc khối tệp tin (Magic Bytes Validation) để chặn mã độc ngụy trang ảnh trong luồng tải lên Avatar.
<br>
![Login Page Redirect](docs/images/login.png)

---

## 🚀 Các Tính Năng Kỹ Thuật Cốt Lõi (Core Technical Features)

### 1. Storefront UI/UX & Tương tác Người Dùng
- **Minimalist Design**: Thiết kế lưới sản phẩm tối giản, hỗ trợ hình ảnh Placeholder độ phân giải cao.
- **Mobile-First Navigation**: Hệ thống menu di động (Hamburger Drawer) tích hợp thanh tìm kiếm.
- **Dynamic Filtering**: Lọc sản phẩm đa chiều (Danh mục, mức giá, từ khóa) kết hợp phân trang dữ liệu tĩnh (Static Data Pagination) giúp tối ưu hiệu năng.
- **Customer Control Panel**: Trang quản lý hồ sơ cá nhân hiện đại. Hỗ trợ tính năng chủ động quản lý và hủy đơn hàng với trạng thái tương quan.

### 2. Business Logic & Toàn Vẹn Dữ Liệu
- **Optimistic Concurrency**: Cấu hình `#RowVersion` cho bảng `ProductSkus` để phòng chống Race Condition khi nhiều người dùng cùng mua một sản phẩm tại cùng một thời điểm.
- **Resource Restoration**: Thuật toán tự động phục hồi số lượng tồn kho (`Stock`) và lượt sử dụng Voucher khi khách hàng/quản trị viên hủy đơn hàng thành công (Trạng thái Pending).
- **File Integrity Validation**: Phân tích trực tiếp chuỗi Hex Headers (Magic Bytes) để xác thực độ chính xác của hình ảnh (JPG, PNG, WEBP), ngăn chặn bypass Extension phổ thông.

### 3. Data Warehouse & Analytics Operations
- Thiết kế cơ sở dữ liệu phân tích song song (`analytics.db` bằng SQLite) theo tiêu chuẩn **Star Schema** (Fact & Dimensions). 
- Hệ thống hỗ trợ lên biểu đồ dữ liệu bằng PowerBI thông qua các bản ghi được tự động đồng bộ hóa (ETL) từ Oracle.

---

## 🤖 AI Shopping Assistant (Trợ lý mua sắm AI)

Hệ thống tích hợp một trợ lý ảo thông minh dựa trên mô hình ngôn ngữ lớn (LLM), giúp cá nhân hóa trải nghiệm khách hàng:
- **Bilingual Search Strategy**: Tự động dịch thuật và tối ưu hóa từ khóa tìm kiếm giữa Tiếng Việt và Tiếng Anh để khớp với dữ liệu sản phẩm.
- **Size Advice Expert**: Tư vấn kích cỡ (S, M, L, XL) dựa trên chỉ số chiều cao, cân nặng và form dáng sản phẩm.
- **Order Tracking**: Tra cứu trạng thái đơn hàng thời gian thực thông qua mã vận đơn (HDxxxx).
- **Interactive Product Cards**: Hiển thị sản phẩm dưới dạng thẻ Markdown sinh động, bao gồm hình ảnh, giá cả và liên kết trực tiếp đến trang chi tiết.
- **Agentic Workflow**: Sử dụng LangGraph để xây dựng quy trình suy luận (Reasoning) và gọi công cụ (Tool Calling) chính xác theo ý định người dùng.

---

## 🛠 Tech Stack (Công nghệ Sử dụng)
- **Backend (Web):** .NET 8.0 SDK, ASP.NET Core MVC (C#)
- **Backend (AI):** Python 3.11+, FastAPI, LangChain, LangGraph
- **Database (OLTP):** Oracle Database 11g Express/Enterprise
- **Database (OLAP):** SQLite (Local Analytics)
- **ORM:** Entity Framework Core (Code-First Migration)
- **Front-End:** HTML5, CSS3, JavaScript (hỗ trợ jQuery AJAX), Bootstrap 5, FontAwesome 6.
- **LLM Engine:** LM Studio (Local Inference)

---

## ⚙ Hướng dẫn Cài đặt & Khởi chạy (Setup Guide)

1. **Yêu Cầu Môi Trường (Prerequisites):**
   - Cài đặt **.NET 8 SDK**.
   - **Oracle Database 11g** (XE hoặc EE), listening trên cổng 1521. Schema mặc định cấu hình tại `appsettings.json`.

2. **Cấu hình Connection Strings (appsettings.json):**
   `json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=C##USER;Password=PASSWORD;",
     "AnalyticsConnection": "Data Source=analytics.db"
   }
   `

3. **Cập Nhật Database & Seeding Data:**
   - Mở Terminal tại thư mục chứa file `.csproj` và thực thi lệnh:
     `ash
     dotnet ef database update
     `
   - Quá trình Data Seeding (`DbInitializer`) sẽ tự động sinh dữ liệu Dummy và phân quyền tài khoản Admin khởi tạo (`admin@bnstore.vn`).

4. **Cài đặt Chatbot AI (Tùy chọn):**
   - Di chuyển vào thư mục chatbot: `cd chatbot`
   - Cài đặt thư viện Python: `pip install -r requirements.txt`
   - Khởi chạy LM Studio và load model (Vd: Gemma-3-4b) tại port 1234.
   - Chạy server chatbot: `python main.py` (Mặc định chạy tại port 8000).

5. **Khởi Chạy Ứng Dụng Web:**
   `ash
   dotnet run
   `
   *Truy cập ứng dụng thông qua URL https://localhost:7290/ trên trình duyệt để kiểm thử.*
