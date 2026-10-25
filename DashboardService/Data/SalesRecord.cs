namespace DashboardService.Data;

/// <summary>Một hợp đồng bảo hiểm đã bán.</summary>
public record SalesRecord(
    string PolicyNumber,
    string ProductCode,
    string AgentLogin,
    DateTime SalesDate,
    decimal PremiumAmount);
