using Domain.Entities;
using Domain.Interfaces.RepositoryContracts;
using Domain.Interfaces.ServiceContracts.StocksService;

namespace Application.Services.StocksServices;

public class SellOrderService : ISellOrderService
{
    private readonly IStocksRepository _repository;

    public SellOrderService(IStocksRepository repository)
    {
        _repository = repository;
    }

    public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
    {
        var saleOrder = await _repository.CreateSellOrder(sellOrder);

        return saleOrder;
    }

    public async Task<List<SellOrder>> GetSellOrders()
    {
        var orders = await _repository.GetSellOrders();

        return orders;
    }
}