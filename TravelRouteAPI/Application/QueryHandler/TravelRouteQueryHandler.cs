using Application.Response;
using Domain.Entities;
using Domain.Enums;
using Domain.RouteFinder;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.QueryHandler;

public class TravelRouteQueryHandler(AppDbContext context) : ITravelRouteQueryHandler
{
    private readonly DbSet<TravelRoute> _dbSet = context.Set<TravelRoute>();

    public async Task<RouteFoundResponse> HandleGetRouteByLowestPrice(
        TravelPoint origin,
        TravelPoint destination,
        CancellationToken cancellationToken)
    {
        var availableRoutes = await _dbSet.ToHashSetAsync(cancellationToken);

        var route = RouteFinder.FindRouteByLowestPrice(availableRoutes, origin, destination);

        return new RouteFoundResponse
        {
            TravelRoutePoints = route.TravelRoutePoints,
            FinalPrice = route.FinalPrice,
            Message = $"{
                string.Join("-", route.TravelRoutePoints.Select(x => x.ToString()))} " +
                      $"at costs of ${route.FinalPrice}" 
        };
    }
}