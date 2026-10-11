# Ghi chú bài thực hành 4
- Đã tạo thêm DashboardService (3 project) vì BlazorWasmClient tham chiếu DashboardService.Api.
- Các lớp DTO/Command/Query trong các project *.Api là lớp tạm (stub) để solution build được; sẽ viết đầy đủ ở bài sau.
- Cài MediatR 12.4.1 và đăng ký trong Program.cs của các service.
- CSDL: chạy postgres/createdatabases.sql (4 database lab_netmicro_*).
- Còn 4 warning NU1903/NU1901 của gói Steeltoe.Discovery.Eureka (trong thư mục được cấp).
