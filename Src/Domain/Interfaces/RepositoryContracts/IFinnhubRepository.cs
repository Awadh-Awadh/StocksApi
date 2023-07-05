namespace Domain.Interfaces;

public interface IFinnhubRepository
{
    Task<IDictionary<string, object>?> GetCompanyProfile(string stockSymbol);
    Task<IDictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    Task<List<Dictionary<string, object>>?> GetStocks();
    Task<IDictionary<string, object>?> SearchStocks(string stockSymbolToSearch);
}