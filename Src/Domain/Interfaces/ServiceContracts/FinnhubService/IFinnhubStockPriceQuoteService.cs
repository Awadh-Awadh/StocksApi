namespace Application.Services;

public interface IFinnhubStockPriceQuoteService
{
    Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
}