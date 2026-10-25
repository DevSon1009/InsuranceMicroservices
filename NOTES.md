# Ghi chú bài thực hành 4
- Đã tạo thêm DashboardService (3 project) vì BlazorWasmClient tham chiếu DashboardService.Api.
- Các lớp DTO/Command/Query trong các project *.Api là lớp tạm (stub) để solution build được; sẽ viết đầy đủ ở bài sau.
- Cài MediatR 12.4.1 và đăng ký trong Program.cs của các service.
- CSDL: chạy postgres/createdatabases.sql (4 database lab_netmicro_*).
- Còn 4 warning NU1903/NU1901 của gói Steeltoe.Discovery.Eureka (trong thư mục được cấp).

# Ghi chú bài thực hành 6 (Phần 4: API Gateway với Ocelot)

- Task 1 (AgentPortalApiGateway): thêm `UseUrls("http://localhost:8099")` (ưu tiên biến `ASPNETCORE_URLS` khi chạy Docker), bổ sung `ServiceUrl` và `ValidateCertificates` cho Eureka trong appsettings.json. Các gói Ocelot.Provider.Eureka, Ocelot.Cache.CacheManager, ocelot.json, GlobalConfiguration và route đã có sẵn từ trước. Dự án dùng Ocelot 23.x nên khóa là `Routes` (đề dùng `ReRoutes` của Ocelot 12).
- Task 2 (AuthService, cổng 6060): `POST /api/User` nhận `{login, password}`, trả `{token, userName, roles, avatar, userType, expiresIn}`. JWT ký HS256 cùng khóa với gateway, có claim `userType=SALESMAN` và `nameidentifier`. Tài khoản thử: `jimmy.sales`, `mary.sales`, `admin` (mật khẩu `secret`).
- Task 3 (ChatService, cổng 4099): SignalR hub `/agentsChat` (`[Authorize]`, đọc token từ query `access_token`), phương thức `SendMessage`, gửi `ReceiveMessage(user, avatar, text)` và `ReceiveNotification(text)`.
- Task 4 (DashboardService, cổng 5035): `POST /api/Dashboard/total-sales | agents-sales | sales-trends`, đăng ký Eureka với tên `DashboardService`. Dữ liệu bán hàng hiện là dữ liệu mẫu trong bộ nhớ (`InMemorySalesRepository`), chưa lấy từ sự kiện RabbitMQ.
- Các service Auth/Chat/Dashboard được viết theo hợp đồng mà BlazorWasmClient đang gọi, không dùng code mẫu của giảng viên.

