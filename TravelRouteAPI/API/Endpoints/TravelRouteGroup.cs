using Application.CommandHandler;
using Application.QueryHandler;
using Application.Request;
using Application.Response;
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
                    [FromBody] TravelRouteAddRequest request,
                    CancellationToken cancellationToken) =>
                {
                    var response = await travelRouteCommandHandler.HandleAdd(request, cancellationToken);

                    return response == null ? Results.UnprocessableEntity() : Results.Created(BaseRoute, response);
                })
            .Accepts<TravelRouteAddRequest>("application/json")
            .Produces<TravelRouteResponse>(201)
            .WithDescription("Creates a new Travel Route");

        app.MapPut(BaseRoute,
                async (
                    ITravelRouteCommandHandler travelRouteCommandHandler,
                    [FromBody] TravelRouteUpdateRequest request,
                    CancellationToken cancellationToken) =>
                {
                    var response = await travelRouteCommandHandler.HandleUpdate(request, cancellationToken);

                    return Results.Ok(response);
                })
            .Accepts<TravelRouteUpdateRequest>("application/json")
            .Produces<TravelRouteResponse>()
            .WithDescription("Updates an existing Travel Route");

        app.MapDelete(BaseRoute,
                async (
                    ITravelRouteCommandHandler travelRouteCommandHandler,
                    [FromBody] TravelRouteDeleteRequest request,
                    CancellationToken cancellationToken) =>
                {
                    await travelRouteCommandHandler.HandleDelete(request, cancellationToken);
                    return Results.Ok();
                })
            .Accepts<TravelRouteDeleteRequest>("application/json")
            .Produces(200)
            .WithDescription("Deletes an existing Travel Route");


        app.MapGet($"{BaseRoute}/get-route-by-lowest-value",
            async (
                ITravelRouteQueryHandler travelRouteQueryHandler,
                [FromQuery] TravelPoint origin,
                [FromQuery] TravelPoint destination,
                CancellationToken cancellationToken) =>
            {
                var response = await travelRouteQueryHandler.HandleGetRouteByLowestPrice(
                    origin, destination, cancellationToken);
                
                return Results.Ok(response);
            })
            .Produces<RouteFoundResponse>()
            .WithDescription("Gets the wanted route with the lowest price");
    }
}