using Application.Request;
using Application.Response;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.CommandHandler;

public class TravelRouteCommandHandler(AppDbContext context) : ITravelRouteCommandHandler
{
    private readonly DbSet<TravelRoute> _dbSet = context.Set<TravelRoute>();
    
    public async Task<TravelRouteResponse?> HandleAdd(
        TravelRouteRequest request,
        CancellationToken cancellationToken)
    {
        var entity = _dbSet.Add(new TravelRoute
        {
            Origin = request.Origin,
            Destination = request.Destination,
            Price = request.Price
        });

        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException _)
        {
            throw new InvalidOperationException(
                $"Operation: '{nameof(TravelRouteCommandHandler)}.{nameof(HandleAdd)}()' failed to save changes!");
        }
        
        return entity.State == EntityState.Unchanged
            ? new TravelRouteResponse
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Price = request.Price
            }
            : null;
    }

    public async Task<TravelRouteResponse?> HandleUpdate(
        TravelRouteRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task HandleDelete(
        TravelRouteRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}