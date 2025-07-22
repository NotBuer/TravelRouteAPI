using Application.CommandHandler;
using Application.QueryHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ITravelRouteCommandHandler, TravelRouteCommandHandler>();
        services.AddScoped<ITravelRouteQueryHandler, TravelRouteQueryHandler>();
        
        return services;
    }
}