# 🛡️ InsuranceMicroservices – Hệ thống quản lý bảo hiểm

## 1. Giới thiệu dự án

**InsuranceMicroservices** là dự án xây dựng hệ thống quản lý bảo hiểm theo kiến trúc Microservices, sử dụng C# và nền tảng .NET 8 / ASP.NET Core.

Dự án hướng đến việc tìm hiểu và áp dụng kiến trúc Microservices, xây dựng RESTful API, quản lý dữ liệu, khám phá dịch vụ và giao tiếp giữa các thành phần trong hệ thống.

Các nghiệp vụ chính bao gồm:

- Xác thực và quản lý người dùng.
- Quản lý hợp đồng bảo hiểm.
- Tìm kiếm thông tin hợp đồng.
- Quản lý sản phẩm bảo hiểm.
- Tính toán phí bảo hiểm.
- Xử lý thanh toán.
- Quản lý tài liệu.
- Trò chuyện và Dashboard.

## 2. Công nghệ sử dụng

| Công nghệ | Mục đích |
|---|---|
| C# | Ngôn ngữ lập trình |
| .NET 8 | Nền tảng phát triển |
| ASP.NET Core | Xây dựng Backend API |
| Microservices | Kiến trúc hệ thống |
| RESTful API | Giao tiếp giữa các dịch vụ |
| API Gateway | Định tuyến yêu cầu |
| MediatR | Xử lý nghiệp vụ Command/Query |
| Eureka | Service Discovery |
| PostgreSQL | Cơ sở dữ liệu |
| Blazor WebAssembly | Giao diện người dùng |
| Unit Test / Integration Test | Kiểm thử phần mềm |
| Git / GitHub | Quản lý mã nguồn |

## 3. Các thành phần chính

| Thành phần | Chức năng |
|---|---|
| AgentPortalApiGateway | API Gateway |
| AuthService | Xác thực người dùng |
| PolicyService | Quản lý hợp đồng bảo hiểm |
| PolicySearchService | Tìm kiếm hợp đồng |
| PricingService | Tính toán phí bảo hiểm |
| ProductService | Quản lý sản phẩm bảo hiểm |
| PaymentService | Xử lý thanh toán |
| DocumentsService | Quản lý tài liệu |
| ChatService | Chức năng trò chuyện |
| DashboardService | Cung cấp dữ liệu Dashboard |
| BlazorWasmClient | Giao diện Blazor |
| Eureka Server | Đăng ký và khám phá dịch vụ |

## 4. Cấu trúc dự án

```text
InsuranceMicroservices/
│
├── AgentPortalApiGateway/
│
├── AuthService/
├── AuthService.Api/
├── AuthService.Test/
│
├── PolicyService/
├── PolicyService.Api/
├── PolicyService.Test/
│
├── PolicySearchService/
├── PolicySearchService.Api/
├── PolicySearchService.Test/
│
├── PricingService/
├── PricingService.Api/
├── PricingService.Test/
├── PricingService.IntegrationTest/
│
├── ProductService/
├── ProductService.Api/
├── ProductService.Test/
│
├── PaymentService/
├── PaymentService.Api/
├── PaymentService.Test/
│
├── DocumentsService/
├── DocumentsService.Api/
├── DocumentsService.Test/
│
├── ChatService/
├── ChatService.Api/
├── ChatService.Test/
│
├── DashboardService/
├── DashboardService.Api/
├── DashboardService.Test/
│
├── BlazorWasmClient/
├── Web/
├── eureka-server/
├── postgres/
├── scripts/
│
├── InsuranceMicroservices.sln
├── NOTES.md
└── README.md
```

## 5. Yêu cầu môi trường

Cần cài đặt các công cụ:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [Git](https://git-scm.com/downloads)
- [PostgreSQL](https://www.postgresql.org/download/)

Kiểm tra phiên bản .NET:

```cmd
dotnet --version
dotnet --list-sdks
```

## 6. Tải mã nguồn dự án

Mở CMD hoặc PowerShell:

```cmd
git clone https://github.com/DevSon1009/InsuranceMicroservices.git
```

Di chuyển vào thư mục dự án:

```cmd
cd /d D:\InsuranceMicroservices
```

Khôi phục các thư viện:

```cmd
dotnet restore InsuranceMicroservices.sln
```

Mở solution bằng Visual Studio:

```cmd
start InsuranceMicroservices.sln
```

## 7. Cấu hình cơ sở dữ liệu

### Bước 1: Cài đặt PostgreSQL

Cài đặt PostgreSQL và khởi động dịch vụ cơ sở dữ liệu.

### Bước 2: Kiểm tra database

Truy cập thư mục:

```text
postgres/
```

Kiểm tra các file SQL và tài nguyên khởi tạo cơ sở dữ liệu.

### Bước 3: Cấu hình Connection String

Mở file `appsettings.json` hoặc `appsettings.Development.json` của từng dịch vụ.

Ví dụ:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=InsuranceDB;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

Lưu ý: Đây là cấu hình minh họa. Cần sử dụng đúng tên Connection String và Database theo từng dịch vụ thực tế.

Không công khai mật khẩu hoặc thông tin đăng nhập trên GitHub.

## 8. Build và chạy dự án

### 8.1. Build toàn bộ Solution

Di chuyển đến thư mục dự án:

```cmd
cd /d D:\InsuranceMicroservices
```

Khôi phục package:

```cmd
dotnet restore InsuranceMicroservices.sln
```

Build toàn bộ Solution:

```cmd
dotnet build InsuranceMicroservices.sln
```

Nếu xuất hiện `Build succeeded` nghĩa là quá trình biên dịch thành công.

### 8.2. Build từng module Test

Có thể build riêng từng project kiểm thử để kiểm tra lỗi biên dịch.

**PaymentService.Test:**

```cmd
dotnet build PaymentService.Test\PaymentService.Test.csproj
```

**ProductService.Test:**

```cmd
dotnet build ProductService.Test\ProductService.Test.csproj
```

Các lệnh trên chỉ biên dịch project kiểm thử, không thực thi các bài Unit Test.

### 8.3. Chạy Backend

Ví dụ chạy PricingService:

```cmd
dotnet run --project PricingService.Api\PricingService.Api.csproj
```

Chạy API Gateway:

```cmd
dotnet run --project AgentPortalApiGateway\AgentPortalApiGateway.csproj
```

Các dịch vụ khác được khởi động tương tự theo cấu hình và file `.csproj` thực tế.

### 8.4. Chạy giao diện người dùng

Nếu sử dụng Blazor WebAssembly:

```cmd
dotnet run --project BlazorWasmClient\BlazorWasmClient.csproj
```

Truy cập địa chỉ được hiển thị trong Terminal sau khi ứng dụng khởi động.

Lưu ý: Cần cấu hình API Gateway và các dịch vụ phụ thuộc trước khi sử dụng giao diện.

## 9. Kiểm thử dự án (Testing)

Dự án sử dụng Unit Test và Integration Test để kiểm tra hoạt động của các thành phần.

### 9.1. Chạy Unit Test PaymentService

```cmd
dotnet test PaymentService.Test\PaymentService.Test.csproj
```

### 9.2. Chạy Unit Test ProductService

```cmd
dotnet test ProductService.Test\ProductService.Test.csproj
```

### 9.3. Chạy Integration Test PricingService

```cmd
dotnet test PricingService.IntegrationTest\PricingService.IntegrationTest.csproj
```

### 9.4. Chạy toàn bộ Test trong Solution

```cmd
dotnet test InsuranceMicroservices.sln
```

### 9.5. Phân biệt Build và Test

| Lệnh | Chức năng |
|---|---|
| `dotnet restore` | Khôi phục các thư viện |
| `dotnet build` | Biên dịch mã nguồn |
| `dotnet test` | Thực thi các bài kiểm thử |
| `dotnet run` | Khởi chạy ứng dụng |

### 9.6. Kết quả kiểm thử

Khi chạy kiểm thử, cần chú ý các thông báo:

- `Passed`: Bài kiểm thử thành công.
- `Failed`: Bài kiểm thử thất bại.
- `Skipped`: Bài kiểm thử bị bỏ qua.
- `Build succeeded`: Biên dịch thành công.
- `Build FAILED`: Có lỗi trong quá trình biên dịch.

Đối với Integration Test, cần kiểm tra thêm các dịch vụ phụ thuộc và cơ sở dữ liệu theo cấu hình kiểm thử.

## 10. Mục tiêu và kiến thức đạt được

Thông qua dự án, người phát triển có cơ hội thực hành:

- Xây dựng Backend bằng C# và ASP.NET Core.
- Thiết kế hệ thống theo kiến trúc Microservices.
- Xây dựng RESTful API.
- Tìm hiểu API Gateway.
- Triển khai Service Discovery với Eureka.
- Làm việc với PostgreSQL.
- Áp dụng MediatR trong xử lý nghiệp vụ.
- Thực hiện Unit Test và Integration Test.
- Quản lý mã nguồn bằng Git và GitHub.

## 11. Tác giả

**Nguyễn Hoàng Sơn**

- GitHub cá nhân: https://github.com/DevSon1009
- Repository: https://github.com/DevSon1009/InsuranceMicroservices

Tham quan GitHub cá nhân để tìm hiểu thêm về các dự án và quá trình học tập, phát triển phần mềm.

---

⭐ Nếu thấy dự án hữu ích, hãy Star repository để ủng hộ.

**InsuranceMicroservices – Hệ thống quản lý bảo hiểm theo kiến trúc Microservices với .NET 8.**
