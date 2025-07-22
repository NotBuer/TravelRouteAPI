using Application.CommandHandler;
using Application.QueryHandler;
using Application.Request;
using Domain.Enums;
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
                ITravelRouteCommandHandler travelRouteCommandHandler,
                [FromBody] TravelRouteDeleteRequest request,
                CancellationToken cancellationToken) =>
            {
                await travelRouteCommandHandler.HandleDelete(request, cancellationToken);
                return Results.Ok();
            });


        app.MapGet($"{BaseRoute}/get-route-by-lowest-value",
            async (
                ITravelRouteQueryHandler travelRouteQueryHandler,
                [FromQuery] TravelPoint origin,
                [FromQuery] TravelPoint destination,
                CancellationToken cancellationToken) =>
            {
                await travelRouteQueryHandler.HandleGetRouteByLowestPrice(origin, destination, cancellationToken);
            });
        
        // app.MapGet($"{BaseRoute}/get-route-by-shortest-distance",
        //     async (
        //         ITravelRouteQueryHandler travelRouteQueryHandler,
        //         [FromQuery] TravelPoint origin,
        //         [FromQuery] TravelPoint destination,
        //         CancellationToken cancellationToken) =>
        //     {
        //         throw new NotImplementedException();
        //     });
    }
}