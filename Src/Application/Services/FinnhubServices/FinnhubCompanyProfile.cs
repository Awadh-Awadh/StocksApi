using Domain.Interfaces;

namespace Application.Services.FinnhubServices;

public class FinnhubCompanyProfile : IFinnhubCompanyProfile
{
    public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        // calls the finnhub repository if no data throw exception
        throw new NotImplementedException();
    }
}