using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetAllStocksController : ControllerBase
{
    private readonly ILogger<GetAllStocksController> _logger;
    public GetAllStocksController(ILogger<GetAllStocksController> logger)
    {
        _logger = logger;
    }
   
    [HttpGet(Name = "GetStocks")]
    public IActionResult GetAllStocks()
    {
        return Ok();
    }
}