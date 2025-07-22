using Application.Response;
using Domain.Enums;

namespace Application.QueryHandler;

public interface ITravelRouteQueryHandler
{
    public Task<RouteFoundResponse> HandleGetByOriginAndDestination(
        TravelPoint origin,
        TravelPoint destination,
        CancellationToken cancellationToken = default);
}