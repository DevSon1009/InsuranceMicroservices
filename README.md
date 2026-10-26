# Hệ thống Microservices quản lý bảo hiểm — InsuranceMicroservices

## 1. Giới thiệu dự án

**InsuranceMicroservices** là dự án xây dựng hệ thống quản lý bảo hiểm theo kiến trúc Microservices, sử dụng nền tảng .NET 8 và ASP.NET Core.

Dự án được thực hiện nhằm tìm hiểu và áp dụng kiến trúc dịch vụ độc lập, xây dựng RESTful API, quản lý dữ liệu, khám phá dịch vụ và giao tiếp giữa các thành phần trong hệ thống.

Hệ thống được chia thành nhiều dịch vụ với các chức năng riêng biệt như xác thực, quản lý hợp đồng bảo hiểm, tìm kiếm hợp đồng, tính phí bảo hiểm, quản lý sản phẩm, thanh toán và quản lý tài liệu.

## 2. Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#
- **Nền tảng:** .NET 8, ASP.NET Core
- **Kiến trúc:** Microservices, RESTful API, API Gateway
- **Xử lý nghiệp vụ:** MediatR, mô hình xử lý Command/Query
- **Khám phá dịch vụ:** Eureka Service Discovery
- **Cơ sở dữ liệu:** PostgreSQL
- **Giao diện:** Blazor WebAssembly
- **Kiểm thử:** Unit Test và Integration Test
- **Công cụ phát triển:** Visual Studio, .NET CLI, Git

## 3. Các chức năng và thành phần chính

| Thành phần | Chức năng |
|---|---|
| AgentPortalApiGateway | Tiếp nhận và định tuyến các yêu cầu API |
| AuthService | Xử lý các chức năng liên quan đến xác thực |
| PolicyService | Quản lý hợp đồng bảo hiểm |
| PolicySearchService | Tìm kiếm thông tin hợp đồng |
| PricingService | Tính toán phí bảo hiểm |
| ProductService | Quản lý sản phẩm bảo hiểm |
| PaymentService | Xử lý các nghiệp vụ liên quan đến thanh toán |
| DocumentsService | Quản lý tài liệu |
| ChatService | Cung cấp các chức năng liên quan đến trò chuyện |
| DashboardService | Cung cấp dữ liệu cho bảng điều khiển |
| BlazorWasmClient | Giao diện người dùng sử dụng Blazor WebAssembly |
| Eureka Server | Hỗ trợ đăng ký và khám phá dịch vụ |

*Lưu ý: Chức năng cụ thể của từng thành phần cần được đối chiếu với phần triển khai thực tế trong mã nguồn.*

## 4. Yêu cầu môi trường

Trước khi chạy dự án, cần cài đặt:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/downloads)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) hoặc Visual Studio Code

Kiểm tra môi trường .NET bằng lệnh:

```bash
dotnet --version
dotnet --list-sdks
```

## 5. Hướng dẫn tải mã nguồn

Mở Terminal, PowerShell hoặc Command Prompt và chạy:

```bash
git clone https://github.com/DevSon1009/InsuranceMicroservices.git
cd InsuranceMicroservices
```

Khôi phục các thư viện cần thiết:

```bash
dotnet restore InsuranceMicroservices.sln
```

Có thể mở file `InsuranceMicroservices.sln` bằng Visual Studio 2022 để xem và quản lý toàn bộ solution.

## 6. Cấu hình cơ sở dữ liệu

### Bước 1: Cài đặt PostgreSQL

Cài đặt PostgreSQL và khởi động dịch vụ cơ sở dữ liệu.

### Bước 2: Tạo cơ sở dữ liệu

Kiểm tra thư mục `postgres/` và file `createdatabases.sql` trong repository.

Nếu file này chứa các lệnh khởi tạo cơ sở dữ liệu phù hợp với môi trường của bạn, hãy thực thi chúng bằng công cụ PostgreSQL.

### Bước 3: Cấu hình kết nối

Mở file cấu hình của từng dịch vụ, chẳng hạn như `appsettings.json` hoặc `appsettings.Development.json`.

Cập nhật connection string để phù hợp với PostgreSQL trên máy tính của bạn.

Không đưa mật khẩu, khóa bí mật hoặc thông tin đăng nhập cá nhân lên GitHub.

## 7. Hướng dẫn chạy dự án

### Bước 1: Khởi động Eureka Server

Mở thư mục `eureka-server/`, đọc cấu hình và hướng dẫn khởi chạy tương ứng.

Khởi động Eureka Server trước các dịch vụ cần đăng ký với hệ thống khám phá dịch vụ.

### Bước 2: Khởi động các dịch vụ backend

Mở một Terminal riêng cho mỗi dịch vụ cần chạy.

Ví dụ, khởi động dịch vụ tính phí bảo hiểm:

```bash
dotnet run --project PricingService/PricingService.csproj
```

Khởi động API Gateway:

```bash
dotnet run --project AgentPortalApiGateway/AgentPortalApiGateway.csproj
```

Thực hiện tương tự với các dịch vụ khác theo nhu cầu sử dụng.

**Lưu ý:** Kiểm tra đường dẫn file `.csproj`, cổng chạy, cấu hình Eureka và các dịch vụ phụ thuộc trong mã nguồn trước khi thực hiện. Các lệnh trên là ví dụ minh họa theo cấu trúc dự án.

### Bước 3: Khởi động giao diện người dùng

Nếu dự án sử dụng Blazor WebAssembly, chạy lệnh:

```bash
dotnet run --project BlazorWasmClient/BlazorWasmClient.csproj
```

Đảm bảo URL của API Gateway được cấu hình chính xác trong ứng dụng giao diện.

Sau khi ứng dụng khởi động, truy cập địa chỉ được hiển thị trong Terminal để sử dụng.

### Bước 4: Kiểm tra hoạt động

- Kiểm tra các dịch vụ backend có khởi động thành công hay không.
- Kiểm tra Eureka có nhận diện được các dịch vụ cần thiết hay không.
- Kiểm tra kết nối PostgreSQL.
- Kiểm tra các API bằng Swagger hoặc công cụ như Postman, nếu được cấu hình.
- Kiểm tra giao diện người dùng có kết nối được với API Gateway hay không.

## 8. Chạy kiểm thử

Chạy toàn bộ các bài kiểm thử được khai báo trong solution:

```bash
dotnet test InsuranceMicroservices.sln
```

Hoặc kiểm thử riêng dịch vụ tính phí bảo hiểm:

```bash
dotnet test PricingService.Test/PricingService.Test.csproj
```

Đối với Integration Test, cần đảm bảo các cơ sở dữ liệu và dịch vụ phụ thuộc đã được cấu hình theo yêu cầu của bài kiểm thử.

## 9. Cấu trúc dự án

```text
InsuranceMicroservices/
├── AgentPortalApiGateway/
├── AuthService/
├── AuthService.Api/
├── AuthService.Test/
├── ChatService/
├── ChatService.Api/
├── ChatService.Test/
├── DashboardService/
├── DashboardService.Api/
├── DashboardService.Test/
├── DocumentsService/
├── DocumentsService.Api/
├── DocumentsService.Test/
├── PaymentService/
├── PaymentService.Api/
├── PaymentService.Test/
├── PolicySearchService/
├── PolicySearchService.Api/
├── PolicySearchService.Test/
├── PolicyService/
├── PolicyService.Api/
├── PolicyService.Test/
├── PricingService/
├── PricingService.Api/
├── PricingService.Test/
├── PricingService.IntegrationTest/
├── ProductService/
├── ProductService.Api/
├── ProductService.Test/
├── BlazorWasmClient/
├── Web/
├── eureka-server/
├── postgres/
├── scripts/
├── InsuranceMicroservices.sln
├── NOTES.md
└── README.md
```

## 10. Mục tiêu học tập

Thông qua dự án, người phát triển có cơ hội thực hành:

- Xây dựng ứng dụng backend bằng ASP.NET Core và .NET 8.
- Phân chia hệ thống thành các dịch vụ theo kiến trúc Microservices.
- Xây dựng và kiểm thử RESTful API.
- Tìm hiểu API Gateway và cơ chế khám phá dịch vụ với Eureka.
- Làm việc với PostgreSQL và cấu hình kết nối cơ sở dữ liệu.
- Áp dụng MediatR và cách tổ chức xử lý nghiệp vụ.
- Thực hiện Unit Test và Integration Test.

## 11. Tác giả

**Nguyễn Hoàng Sơn**

- GitHub cá nhân: https://github.com/DevSon1009
- Repository dự án: https://github.com/DevSon1009/InsuranceMicroservices

---

*Dự án được xây dựng phục vụ mục đích học tập, thực hành và nghiên cứu kiến trúc Microservices với nền tảng .NET.*
