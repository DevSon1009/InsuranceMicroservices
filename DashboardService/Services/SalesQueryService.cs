using DashboardService.Api.Queries;
using DashboardService.Api.Queries.Dtos;
using DashboardService.Data;

namespace DashboardService.Services;

public class SalesQueryService : ISalesQueryService
{
    private readonly ISalesRepository repository;

    public SalesQueryService(ISalesRepository repository)
    {
        this.repository = repository;
    }

    public GetTotalSalesResult GetTotalSales(GetTotalSalesQuery query)
    {
        var sales = Filter(query.SalesDateFrom, query.SalesDateTo)
            .Where(r => string.IsNullOrEmpty(query.ProductCode) || r.ProductCode == query.ProductCode)
            .ToList();

        return new GetTotalSalesResult
        {
            Total = Summarize(sales),
            PerProductTotal = sales
                .GroupBy(r => r.ProductCode)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => Summarize(g))
        };
    }

    public GetAgentsSalesResult GetAgentsSales(GetAgentsSalesQuery query)
    {
        return new GetAgentsSalesResult
        {
            PerAgentTotal = Filter(query.SalesDateFrom, query.SalesDateTo)
                .GroupBy(r => r.AgentLogin)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => Summarize(g))
        };
    }

    public GetSalesTrendsResult GetSalesTrends(GetSalesTrendsQuery query)
    {
        var periods = Filter(query.SalesDateFrom, query.SalesDateTo)
            .GroupBy(r => PeriodKey(r.SalesDate, query.Unit))
            .OrderBy(g => g.Key, StringComparer.Ordinal) // định dạng yyyy-MM-dd nên sắp xếp chuỗi = sắp xếp thời gian
            .Select(g => new PeriodSales { Period = g.Key, Sales = Summarize(g) })
            .ToList();

        return new GetSalesTrendsResult { PeriodsSales = periods };
    }

    private IEnumerable<SalesRecord> Filter(DateTime? from, DateTime? to)
    {
        return repository.GetAll().Where(r =>
            (!from.HasValue || r.SalesDate.Date >= from.Value.Date) &&
            (!to.HasValue || r.SalesDate.Date <= to.Value.Date));
    }

    private static SalesResult Summarize(IEnumerable<SalesRecord> records)
    {
        var list = records as IList<SalesRecord> ?? records.ToList();
        return new SalesResult
        {
            PoliciesCount = list.Count,
            PremiumAmount = list.Sum(r => r.PremiumAmount)
        };
    }

    private static string PeriodKey(DateTime date, TimeUnit unit) => unit switch
    {
        TimeUnit.Day => date.ToString("yyyy-MM-dd"),
        TimeUnit.Year => date.ToString("yyyy"),
        _ => date.ToString("yyyy-MM")
    };
}
