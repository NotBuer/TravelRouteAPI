using Application.CommandHandler;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints;

internal static class TravelRouteGroup
{
    private const string BaseRoute = "/travel-route";
    
    internal static void MapTravelRouteGroup(this WebApplication app)
    {
        app.MapPost(BaseRoute, 
            async (
                ITravelRouteCommandHandler travelRouteCommandHandler, 
                [FromBody] TravelRouteRequest request, 
                CancellationToken cancellationToken) =>
            {
                var response = await travelRouteCommandHandler.HandleAdd(request, cancellationToken);
                
                return response == null ? 
                    Results.UnprocessableEntity() : 
                    Results.Created(BaseRoute, response);
            });
        
        app.MapPut(BaseRoute,
            async (
                ITravelRouteCommandHandler travelRouteCommandHandler,
                [FromBody] TravelRouteUpdateRequest request,
                CancellationToken cancellationToken) =>
            {
                var response = await travelRouteCommandHandler.HandleUpdate(request, cancellationToken);

                return Results.Ok(response);
            });

        app.MapDelete(BaseRoute,
            async (
                ITravelRouteCommandHandler TravelRouteCommandHandler,
                [FromBody] TravelRouteDeleteRequest request,
                CancellationToken cancellationToken) =>
            {
                await TravelRouteCommandHandler.HandleDelete(request, cancellationToken);
                return Results.Ok();
            });


        // TODO: Get's
    }
}