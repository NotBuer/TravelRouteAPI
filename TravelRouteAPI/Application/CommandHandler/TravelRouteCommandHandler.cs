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
        TravelRouteAddRequest request,
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

    public async Task<TravelRouteResponse> HandleUpdate(
        TravelRouteUpdateRequest request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync([request.Id], cancellationToken);

        if (entity is null)
            throw new InvalidOperationException(
                $"Operation: '{nameof(TravelRouteCommandHandler)}.{nameof(HandleUpdate)}()' entity with id: {request.Id} not found!");
        
        entity.Origin = request.Origin;
        entity.Destination = request.Destination;
        entity.Price = request.Price;

        _dbSet.Update(entity);
        
        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException _)
        {
            throw new InvalidOperationException(
                $"Operation: '{nameof(TravelRouteCommandHandler)}.{nameof(HandleUpdate)}()' failed to save changes!");
        }

        return new TravelRouteResponse
        {
            Origin = entity.Origin,
            Destination = entity.Destination,
            Price = entity.Price
        };
    }

    public async Task HandleDelete(
        TravelRouteDeleteRequest request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync([request.Id], cancellationToken);
        
        if (entity is null)
            throw new InvalidOperationException(
                $"Operation: '{nameof(TravelRouteCommandHandler)}.{nameof(HandleDelete)}()' entity with id: {request.Id} not found!");

        _dbSet.Remove(entity);
        
        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException _)
        {
            throw new InvalidOperationException(
                $"Operation: '{nameof(TravelRouteCommandHandler)}.{nameof(HandleDelete)}()' failed to save changes!");
        }
    }
}