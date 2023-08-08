using Application.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.RepositoryContracts;

namespace Application.Services.FinnhubServices;

public class FinnhubCompanyProfile : IFinnhubCompanyProfile
{
    private readonly IFinnhubRepository _repository;
    public FinnhubCompanyProfile(IFinnhubRepository repository)
    {
        _repository = repository;
    }

    public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        var profile = await _repository.GetCompanyProfile(stockSymbol);
        if (profile is null)
        {
            throw new FinhubException("No profile", "The profile has no value");
        }

        return new Dictionary<string, object>(profile);
    }
}
