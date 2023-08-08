using Application.Exceptions;
using Application.Services;
using Domain.Interfaces.ServiceContracts.FinnhubService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetAllStocksController : ControllerBase
{
    private readonly ILogger<GetAllStocksController> _logger;
    private readonly IFinnhubStockService _service;
    public GetAllStocksController(ILogger<GetAllStocksController> logger, IFinnhubStockService service)
    {
        _logger = logger;
        _service = service;
    }
   
    [HttpGet(Name = "GetStocks")]
    public async Task<ActionResult<List<Dictionary<string, object>>>> GetAllStocks()
    {
        var stocks = new List<Dictionary<string, object>>();
        try
        {
            var fetchedStocks = await _service.GetStocks();
            stocks = fetchedStocks!;
        }
        catch (FinhubException ex)
        {
            _logger.LogError("An Error Occurred while fetching stocks {Description}", ex.Description);
        }

        return Ok(stocks);
    }
}