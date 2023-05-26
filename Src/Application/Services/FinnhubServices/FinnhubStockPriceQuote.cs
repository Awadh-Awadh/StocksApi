namespace Application.Services.FinnhubServices;

public class FinnhubStockPriceQuote : IFinnhubStockPriceQuoteService
{
    public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
        throw new NotImplementedException();
    }
}