namespace DashboardService.Data;

/// <summary>
/// Dữ liệu bán hàng mẫu (cố định theo seed) trong 14 tháng gần nhất để Dashboard có số liệu hiển thị.
/// Khi tích hợp đầy đủ, dữ liệu này sẽ lấy từ sự kiện PolicyCreated của PolicyService.
/// </summary>
public class InMemorySalesRepository : ISalesRepository
{
    private static readonly string[] Products = { "TRI", "HSI", "FAI", "CAR" };
    private static readonly string[] Agents = { "jimmy.sales", "mary.sales", "admin" };

    private readonly List<SalesRecord> records;

    public InMemorySalesRepository()
    {
        var random = new Random(2026);
        var today = DateTime.Today;
        records = new List<SalesRecord>();

        for (var i = 1; i <= 150; i++)
        {
            var product = Products[random.Next(Products.Length)];
            records.Add(new SalesRecord(
                PolicyNumber: $"P-{i:D5}",
                ProductCode: product,
                AgentLogin: Agents[random.Next(Agents.Length)],
                SalesDate: today.AddDays(-random.Next(0, 420)),
                PremiumAmount: Math.Round(100m + random.Next(0, 900), 2)));
        }
    }

    public IReadOnlyCollection<SalesRecord> GetAll() => records;
}
