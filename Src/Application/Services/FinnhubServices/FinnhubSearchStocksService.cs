using Domain.Interfaces.ServiceContracts.FinnhubService;

namespace Application.Services.FinnhubServices;

public class FinnhubSearchStocksService :IFinnhubSearchStocksService
{
    public Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
    {
        throw new NotImplementedException();
    }
}