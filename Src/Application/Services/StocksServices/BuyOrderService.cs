using Domain.Entities;
using Domain.Interfaces.ServiceContracts.StocksService;

namespace Application.Services.StocksServices;

public class BuyOrderService : IBuyOrderService
{
    public Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
    {
        throw new NotImplementedException();
    }

    public Task<List<BuyOrder>> GetBuyOrders()
    {
        throw new NotImplementedException();
    }
}