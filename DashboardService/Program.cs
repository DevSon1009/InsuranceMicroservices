using DashboardService.Data;
using DashboardService.Services;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký với Eureka để API Gateway tìm thấy qua ServiceName "DashboardService"
builder.Services.AddEurekaDiscoveryClient();

builder.Services.AddSingleton<ISalesRepository, InMemorySalesRepository>();
builder.Services.AddSingleton<ISalesQueryService, SalesQueryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

public partial class Program { }
