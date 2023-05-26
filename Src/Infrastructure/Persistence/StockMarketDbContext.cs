using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class StockMarketDbContext : DbContext
{
    public StockMarketDbContext(DbContextOptions options) :base(options)
    {
        
    }
    public DbSet<BuyOrder> BuyOrders { get; set; }
    public DbSet<SellOrder> SellOrders { get; set; }
}