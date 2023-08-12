using Application.Exceptions;
using Application.Models;
using Application.Models.Configuration;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetAllStocksController : ControllerBase
{
    private readonly TradingOptions _options;
    private readonly ILogger<GetAllStocksController> _logger;
    private readonly IFinnhubStockService _service;
    public GetAllStocksController(ILogger<GetAllStocksController> logger, IFinnhubStockService service, IOptions<TradingOptions> options)
    {
        _logger = logger;
        _service = service;
        _options = options.Value;
    }
   
    [HttpGet(Name = "GetStocks")]
    public async Task<ActionResult<List<Dictionary<string, object>>>> GetAllStocks([FromQuery]int pageNumber =1, [FromQuery]int pageSize = 200)
    {
        var filteredStocks = new List<Dictionary<string, object>?>();
        var stocks = new List<Stock>();
        try
        {
            var topStocks = _options.Top25PopularStocks.Split(',');
            var fetchedStocks = await _service.GetStocks();
            filteredStocks = fetchedStocks.Where(c => topStocks.Contains(c["displaySymbol"].ToString())).ToList();
            
            stocks = filteredStocks
                .Select(c => new Stock
                    { StockSymbol = c?["description"].ToString(), StockName = c?["displaySymbol"].ToString() })
                .ToList();
        }
        catch (FinhubException ex)
        {
            _logger.LogError("An Error Occurred while fetching stocks {Description}", ex.Description);
        }

        return Ok(stocks);
    }
}
