namespace Application.Services;

public interface IFinnhubStockService
{
    Task<List<Dictionary<string, object>?>> GetStocks();
}