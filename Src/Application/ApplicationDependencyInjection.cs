using System.Reflection;
using Application.Services;
using Application.Services.FinnhubServices;
using Application.Services.StocksServices;
using Application.Validations;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.ServiceContracts.FinnhubService;
using Domain.Interfaces.ServiceContracts.StocksService;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        //ConfigureValidations(services); This is for automatic registration
        AddValidators(services); // manual registration using dependency injection.
        services.AddScoped<IBuyOrderService, BuyOrderService>();
        services.AddScoped<ISellOrderService, SellOrderService>();
        services.AddScoped<IFinnhubStockService, FinnhubStockService>();
        services.AddScoped<IFinnhubCompanyProfile, FinnhubCompanyProfile>();
        services.AddScoped<IFinnhubSearchStocksService, FinnhubSearchStocksService>();
        services.AddScoped<IFinnhubStockPriceQuoteService, FinnhubStockPriceQuote>();

        return services;
    }
    private static void ConfigureValidations(IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    private static void AddValidators(IServiceCollection services)
    {
        services.AddTransient<IValidator<BuyOrder>, BuyOrderValidator>();
        services.AddTransient<IValidator<SellOrder>, SellOrderValidator>();
    }

}