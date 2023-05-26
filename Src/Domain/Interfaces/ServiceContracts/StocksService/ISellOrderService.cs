using Domain.Entities;

namespace Domain.Interfaces.ServiceContracts.StocksService;

public interface ISellOrderService
{
    Task<SellOrder> CreateSellOrder(SellOrder sellOrder);
    Task<List<SellOrder>> GetSellOrders();
}