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
        TravelRouteRequest request, 
        CancellationToken cancellationToken = default);
}