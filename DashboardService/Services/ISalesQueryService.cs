using DashboardService.Api.Queries;

namespace DashboardService.Services;

public interface ISalesQueryService
{
    GetTotalSalesResult GetTotalSales(GetTotalSalesQuery query);
    GetAgentsSalesResult GetAgentsSales(GetAgentsSalesQuery query);
    GetSalesTrendsResult GetSalesTrends(GetSalesTrendsQuery query);
}
