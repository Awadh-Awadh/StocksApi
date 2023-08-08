using Domain.Interfaces.RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Application.Services.FinnhubServices;

public class FinnhubStockService : IFinnhubStockService
{
    private readonly IFinnhubRepository _repository;
    private readonly ILogger<FinnhubStockService> _logger;

    public FinnhubStockService(IFinnhubRepository repository, ILogger<FinnhubStockService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<Dictionary<string, object>?>> GetStocks()
    {
        var stocks = await _repository.GetStocks();
        if (stocks is null)
        {
            _logger.LogInformation("No Stocks Found");
            return new List<Dictionary<string, object>?>();
        }

        return new List<Dictionary<string, object>?>(stocks);
    }
}