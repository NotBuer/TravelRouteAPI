using Application.CommandHandler;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints;

internal static class TravelRouteGroup
{
    private const string BaseRoute = "/travel-route";
    
    internal static void MapTravelRouteGroup(this WebApplication app)
    {
        // TODO: Create
        app.MapPost(BaseRoute, 
            async (
                ITravelRouteCommandHandler travelRouteCommandHandler, 
                [FromBody] TravelRouteRequest request, 
                CancellationToken cancellationToken) =>
            {
                var response = await travelRouteCommandHandler.HandleAdd(request, cancellationToken);
                
                return response == null ? 
                    Results.InternalServerError() : 
                    Results.Created(BaseRoute, response);
            });

        // TODO: Update
        app.MapPut(BaseRoute,
            async (
                ITravelRouteCommandHandler travelRouteCommandHandler,
                [FromBody] TravelRouteUpdateRequest request,
                CancellationToken cancellationToken) =>
            {
                var response = await travelRouteCommandHandler.HandleUpdate(request, cancellationToken);

                return Results.Ok(response);
            });

        // TODO: Delete





        // TODO: Get's
    }
}