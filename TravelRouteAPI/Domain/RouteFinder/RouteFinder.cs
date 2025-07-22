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

        var startPoint = availableRoutes.First(x => x.Origin == origin);
        var endPoint = availableRoutes.First(x => x.Destination == destination);
        var currentPoint = startPoint;

        while (currentPoint != endPoint)
        {
            TravelRoute? nextPoint = null;
            
            var possibleNextPoints = availableRoutes.Where(x => x.Origin == currentPoint.Destination).ToList();
            nextPoint = possibleNextPoints.Count > 1 ? possibleNextPoints.MinBy(x => x.Price) : possibleNextPoints.First();

            travelRoutePointsList.Add(currentPoint.Origin);
            priceSum += currentPoint.Price;
            currentPoint = nextPoint;
        }

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