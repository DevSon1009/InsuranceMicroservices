using PricingService.DataAccess;
using PricingService.Domain;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddEurekaDiscoveryClient();

// Kho bieu phi luu trong bo nho (nap san TRI, HSI, FAI, CAR)
builder.Services.AddSingleton<ITariffRepository>(_ => TariffSeeder.CreateRepository());
builder.Services.AddSingleton<IDataStore, InMemoryDataStore>();

// Newtonsoft de doc duoc QuestionAnswer (lop truu tuong co JsonConverter)
builder.Services.AddControllers().AddNewtonsoftJson();
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
