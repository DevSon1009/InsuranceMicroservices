using System.Collections.Concurrent;
using PricingService.Domain;

namespace PricingService.DataAccess;

public class InMemoryTariffRepository : ITariffRepository
{
    private readonly ConcurrentDictionary<string, Tariff> tariffs = new(StringComparer.OrdinalIgnoreCase);

    public Task<Tariff> this[string code] => WithCode(code);

    public Task<Tariff> WithCode(string code)
    {
        if (tariffs.TryGetValue(code, out var tariff))
            return Task.FromResult(tariff);

        throw new ApplicationException($"Tariff for product '{code}' was not found");
    }

    public void Add(Tariff tariff)
    {
        tariffs[tariff.Code] = tariff;
    }

    public Task<bool> Exists(string code)
    {
        return Task.FromResult(tariffs.ContainsKey(code));
    }
}
