#nullable disable
using System;
using System.Collections.Generic;
using DashboardService.Api.Queries.Dtos;

namespace DashboardService.Api.Queries
{
    public class GetTotalSalesQuery
    {
        public string ProductCode { get; set; }
        public DateTime? SalesDateFrom { get; set; }
        public DateTime? SalesDateTo { get; set; }
    }

    public class GetTotalSalesResult
    {
        public SalesResult Total { get; set; }
        public Dictionary<string, SalesResult> PerProductTotal { get; set; } = new Dictionary<string, SalesResult>();
    }

    public class GetAgentsSalesQuery
    {
        public DateTime? SalesDateFrom { get; set; }
        public DateTime? SalesDateTo { get; set; }
    }

    public class GetAgentsSalesResult
    {
        public Dictionary<string, SalesResult> PerAgentTotal { get; set; } = new Dictionary<string, SalesResult>();
    }

    public class GetSalesTrendsQuery
    {
        public DateTime? SalesDateFrom { get; set; }
        public DateTime? SalesDateTo { get; set; }
        public TimeUnit Unit { get; set; }
    }

    public class GetSalesTrendsResult
    {
        public List<PeriodSales> PeriodsSales { get; set; } = new List<PeriodSales>();
    }
}

namespace DashboardService.Api.Queries.Dtos
{
    public enum TimeUnit
    {
        Day,
        Month,
        Year
    }

    public class SalesResult
    {
        public int PoliciesCount { get; set; }
        public decimal PremiumAmount { get; set; }
    }

    public class PeriodSales
    {
        public string Period { get; set; }
        public SalesResult Sales { get; set; }
    }
}

