using Domain.Entities;

namespace Domain.Interfaces.ServiceContracts.StocksService;

public interface IBuyOrderService
{
    Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder);
    Task<List<BuyOrder>> GetBuyOrders();
}