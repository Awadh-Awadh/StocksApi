using Domain.Entities;
using Domain.Interfaces.RepositoryContracts;
using Domain.Interfaces.ServiceContracts.StocksService;

namespace Application.Services.StocksServices;

public class BuyOrderService : IBuyOrderService
{
    private readonly IStocksRepository _repository;

    public BuyOrderService(IStocksRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
    {
       return await _repository.CreateBuyOrder(buyOrder);
    }

    public async Task<List<BuyOrder>> GetBuyOrders()
    {
        var orders = await _repository.GetBuyOrders();

        return orders;
    }
}