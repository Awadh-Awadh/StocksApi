namespace Domain.Interfaces;

public interface IFinnhubCompanyProfile
{
    Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
}