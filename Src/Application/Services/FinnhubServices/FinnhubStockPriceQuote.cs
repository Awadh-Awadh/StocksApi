using Domain.Interfaces.RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Application.Services.FinnhubServices;

public class FinnhubStockPriceQuote : IFinnhubStockPriceQuoteService
{
    private IFinnhubRepository _finnhubRepository;
    private readonly ILogger<IFinnhubRepository> _logger;

    public FinnhubStockPriceQuote(IFinnhubRepository finnhubRepository, ILogger<IFinnhubRepository> logger)
    {
        _finnhubRepository = finnhubRepository;
        _logger = logger;
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
        var priceQuote = await _finnhubRepository.GetStockPriceQuote(stockSymbol);
        if (priceQuote is null)
        {
            _logger.LogInformation("PriceQuote not found");
        }

        return new Dictionary<string, object>(priceQuote!);
    }
}