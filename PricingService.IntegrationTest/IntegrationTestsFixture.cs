using System.Threading.Tasks;
using Alba;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;
using Xunit;

namespace PricingService.IntegrationTest;

public class IntegrationTestsFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer pgSqlContainer =
        new PostgreSqlBuilder()
            .WithDatabase("lab_netmicro_pricing")
            .WithCleanUp(true)
            .Build();

    public IAlbaHost SystemUnderTest { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        await pgSqlContainer.StartAsync();

        SystemUnderTest = await AlbaHost.For<global::Program>(builder =>
        {
            builder.UseSetting(
                "ConnectionStrings:DefaultConnection",
                pgSqlContainer.GetConnectionString());

            builder.ConfigureServices((context, services) =>
            {
                SetupServices(context, services);
            });
        });
    }

    public async Task DisposeAsync()
    {
        if (SystemUnderTest is not null)
        {
            await SystemUnderTest.DisposeAsync();
        }

        await pgSqlContainer.DisposeAsync();
    }

    protected virtual void SetupServices(
    Microsoft.AspNetCore.Hosting.WebHostBuilderContext ctx,
    IServiceCollection services)
    {
    }

    protected Task SetupData()
    {
        return Task.CompletedTask;
    }
}