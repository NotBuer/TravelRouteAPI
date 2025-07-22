using Application.Request;
using Application.Response;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.QueryHandler;

public class TravelRouteQueryHandler(AppDbContext context) : ITravelRouteQueryHandler
{
    private readonly DbSet<TravelRoute> _dbSet = context.Set<TravelRoute>();
    
    public async Task<TravelRouteResponse> HandleGet(
        TravelRouteRequest request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<TravelRouteResponse> HandleGetByOrigin(
        TravelRouteRequestByOrigin request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}