using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class FinnhubRepository : IFinnhubRepository
{
    public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
        throw new NotImplementedException();
    }

    public Task<List<Dictionary<string, object>>?> GetStocks()
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
    {
        throw new NotImplementedException();
    }
}