using System.Reflection;
using Application.Validations;
using Domain.Entities;
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