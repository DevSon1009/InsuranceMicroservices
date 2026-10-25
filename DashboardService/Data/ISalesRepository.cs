namespace DashboardService.Data;

public interface ISalesRepository
{
    IReadOnlyCollection<SalesRecord> GetAll();
}
