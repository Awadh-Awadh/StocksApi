using Application.Exceptions;
using Domain.Interfaces.RepositoryContracts;
using Domain.Interfaces.ServiceContracts.FinnhubService;

namespace Application.Services.FinnhubServices;

public class FinnhubSearchStocksService : IFinnhubSearchStocksService
{
    private readonly IFinnhubRepository _repository;

    public FinnhubSearchStocksService(IFinnhubRepository repository)
    {
        _repository = repository;
    }

    public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
    {
        var stocks = await _repository.SearchStocks(stockSymbolToSearch);
        if (stocks is null)
        {
            Enumerable.Empty<Dictionary<string, object>>();
        }

        return new Dictionary<string, object>(stocks!);
    }
}
