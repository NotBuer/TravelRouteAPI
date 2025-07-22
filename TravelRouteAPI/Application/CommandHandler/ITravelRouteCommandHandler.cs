using Application.Request;
using Application.Response;

namespace Application.CommandHandler;

public interface ITravelRouteCommandHandler
{
    public Task<TravelRouteResponse?> HandleAdd(
        TravelRouteRequest request, 
        CancellationToken cancellationToken = default);
    
    public Task<TravelRouteResponse> HandleUpdate(
        TravelRouteUpdateRequest request, 
        CancellationToken cancellationToken = default);
    
    public Task HandleDelete(
        TravelRouteDeleteRequest request, 
        CancellationToken cancellationToken = default);
}