using Domain.Entities;
using Domain.Interfaces.ServiceContracts.StocksService;

namespace Application.Services.StocksServices;

public class StockService : ISellOrderService
{
    public Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
    {
        throw new NotImplementedException();
    }

    public Task<List<SellOrder>> GetSellOrders()
    {
        throw new NotImplementedException();
    }
}