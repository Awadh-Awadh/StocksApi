using Domain.Interfaces;
using Domain.Interfaces.RepositoryContracts;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDiModule
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IRepository, EfRepository>();
        services.AddScoped<IFinnhubRepository, FinnhubRepository>();
        services.AddScoped<IStocksRepository, StocksRepository>();

        services.AddDbContext<StockMarketDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        });
        return services;
    }
}