using System.Text.Json;
using Application.Exceptions;
using Application.Models.Configuration;
using Domain.Interfaces.RepositoryContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories;

public class FinnhubRepository : IFinnhubRepository
{
    private readonly FinHubApi _settings;
    private readonly ILogger<FinnhubRepository> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    public FinnhubRepository(
        IOptions<FinHubApi> settings,
        ILogger<FinnhubRepository> logger, 
        IHttpClientFactory httpClientFactory)
    {
        _settings = settings.Value;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IDictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        var endpoint = $"{_settings.BaseUrl}/stock/profile2?symbol={stockSymbol}&token={_settings.Token}";
        try
        {
            var response = await Get(endpoint);
            var companyProfile = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            ArgumentNullException.ThrowIfNull(companyProfile);

            return companyProfile;
        }
        catch (FinhubException ex)
        {
            _logger.LogError("Error retrieving company profile {error}, {reason}", ex.Message, ex.Description);

            return default;
        }
    }

    public async Task<IDictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
        var endpoint = $"{_settings.BaseUrl}/?symbol={stockSymbol}&token={_settings.Token}";
        try
        {
            var response = await Get(endpoint);
            ArgumentNullException.ThrowIfNull(response);
            var parsedResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            return parsedResponse;
        }
        catch (FinhubException ex)
        {
            _logger.LogError("Error retrieving stock price {error}, {reason}", ex.Message,  ex.Description);

            return default;
        }
        
    }

    public async Task<List<Dictionary<string, object>>?> GetStocks()
    {
        var endpoint = $"{_settings.BaseUrl}/stock/symbol?exchange=US&token={_settings.Token}";
        try
        {
            var response = await Get(endpoint);
            ArgumentNullException.ThrowIfNull(response);
            var parsedResponse = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(response);

            return parsedResponse;
        }
        catch (FinhubException ex)
        {
            _logger.LogError("Could not get stock symbols {error}, {reason}", ex.Message, ex.Description);

            return default;
        }
    }

    public async Task<IDictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
    {
        var endpoint = $"{_settings.BaseUrl}/search?q={stockSymbolToSearch}&token={_settings.Token}";
        try
        {
            var response = await Get(endpoint);
            ArgumentNullException.ThrowIfNull(response);
            var parsedResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            return parsedResponse;

        }
        catch (FinhubException ex)
        {
            _logger.LogError("Could not get stock {error}, {reason}", ex.Message, ex.Description);

            return default;
        }
    }

    private async Task<string> Get(string endpoint)
    {
        var client = _httpClientFactory.CreateClient("FinhubApiClient");
        try
        {
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var rawResponse = await response.Content.ReadAsStringAsync();

                ArgumentNullException.ThrowIfNull(rawResponse);

                return rawResponse;
            }
            else
            {
                throw new FinhubException($"A {response.StatusCode} error occured", response.ReasonPhrase!);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred with message {message}", ex.Message);
            throw;
        }
    }
}

// GetCompanyProfile: https://finnhub.io/api/v1/stock/profile2?symbol={symbol}&token={token}

// GetStockPriceQuote: https://finnhub.io/api/v1/quote?symbol={symbol}&token={token}

// GetStocks: https://finnhub.io/api/v1/stock/symbol?exchange=US&token={token}

// SearchStocks: https://finnhub.io/api/v1/search?q={stockNameToSearch}&token={token}