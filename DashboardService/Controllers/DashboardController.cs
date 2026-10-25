using DashboardService.Api.Queries;
using DashboardService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DashboardService.Controllers;

/// <summary>Các endpoint mà DashboardClient (qua API Gateway) gọi tới.</summary>
[ApiController]
[Route("api/Dashboard")]
public class DashboardController : ControllerBase
{
    private readonly ISalesQueryService queries;

    public DashboardController(ISalesQueryService queries)
    {
        this.queries = queries;
    }

    [HttpPost("total-sales")]
    public ActionResult<GetTotalSalesResult> TotalSales([FromBody] GetTotalSalesQuery query) =>
        Ok(queries.GetTotalSales(query));

    [HttpPost("agents-sales")]
    public ActionResult<GetAgentsSalesResult> AgentsSales([FromBody] GetAgentsSalesQuery query) =>
        Ok(queries.GetAgentsSales(query));

    [HttpPost("sales-trends")]
    public ActionResult<GetSalesTrendsResult> SalesTrends([FromBody] GetSalesTrendsQuery query) =>
        Ok(queries.GetSalesTrends(query));
}
