using PricingService.Domain;

namespace PricingService.DataAccess;

public class InMemoryDataStore : IDataStore
{
    public InMemoryDataStore(ITariffRepository tariffs)
    {
        Tariffs = tariffs;
    }

    public ITariffRepository Tariffs { get; }

    public Task CommitChanges()
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
    }
}
