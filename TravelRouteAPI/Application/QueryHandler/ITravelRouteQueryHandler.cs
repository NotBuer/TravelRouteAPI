using Application.Request;
using Application.Response;

namespace Application.QueryHandler;

public interface ITravelRouteQueryHandler
{
    public Task<TravelRouteResponse> HandleGet(
        TravelRouteRequest request, 
        CancellationToken cancellationToken = default);
    
    public Task<TravelRouteResponse> HandleGetByOrigin(
        TravelRouteRequestByOrigin request, 
        CancellationToken cancellationToken = default);
}