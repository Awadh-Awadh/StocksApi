using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class StocksRepository : IStocksRepository
{
    public Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
    {
        throw new NotImplementedException();
    }

    public Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
    {
        throw new NotImplementedException();
    }

    public Task<List<BuyOrder>> GetBuyOrders()
    {
        throw new NotImplementedException();
    }

    public Task<List<SellOrder>> GetSellOrders()
    {
        throw new NotImplementedException();
    }
}