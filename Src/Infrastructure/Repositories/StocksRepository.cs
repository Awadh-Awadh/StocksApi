using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.RepositoryContracts;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StocksRepository : IStocksRepository
{
    private readonly StockMarketDbContext _db;

    public StocksRepository(StockMarketDbContext db)
    {
        _db = db;
    }

    public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
    {
        await _db.AddAsync(buyOrder);
        await _db.SaveChangesAsync();

        return buyOrder;
    }

    public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
    {
        await _db.AddAsync(sellOrder);
        await _db.SaveChangesAsync();

        return sellOrder;
    }

    public async Task<List<BuyOrder>> GetBuyOrders()
    {
        List<BuyOrder> buyOrders = await _db.BuyOrders
            .OrderByDescending(temp => temp.DateAndTimeOfOrder)
            .ToListAsync();

        return buyOrders;
    }

    public async Task<List<SellOrder>> GetSellOrders()
    {
        List<SellOrder> sellOrders = await _db.SellOrders
            .OrderByDescending(temp => temp.DateAndTimeOfOffer)
            .ToListAsync();

        return sellOrders;
    }
}