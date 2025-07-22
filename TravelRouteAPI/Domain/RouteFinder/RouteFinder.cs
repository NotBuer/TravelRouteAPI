using Domain.Entities;
using Domain.Enums;

namespace Domain.RouteFinder;

public class RouteFinder
{
    public static RouteFoundValueObject FindRouteByLowestPrice(
        ICollection<TravelRoute> availableRoutes, 
        TravelPoint origin, 
        TravelPoint destination)
    {
        var travelRoutePointsList = new List<TravelPoint>();
        var priceSum = 0m;
        
        

        return new RouteFoundValueObject
        {
            TravelRoutePoints = travelRoutePointsList,
            FinalPrice = priceSum
        };
    }

    // public static RouteFoundValueObject FindRouteByShortestDistance(
    //     ICollection<TravelRoute> availableRoutes,
    //     TravelPoint origin, 
    //     TravelPoint destination)
    // {
    //     
    // }
}