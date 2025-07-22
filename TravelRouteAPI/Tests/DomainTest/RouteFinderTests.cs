using Domain.Enums;
using Domain.RouteFinder;

namespace Tests.DomainTest;

public class RouteFinderTests
{
    [Fact]
    internal void FindRoute_ShouldReturnCheapestRoute_Price40()
    {
        const TravelPoint origin = TravelPoint.GRU;
        const TravelPoint destination = TravelPoint.CDG;
        
        const decimal expectedPrice = 40.00m;

        var expectedRoutes = new List<TravelPoint>
        {
            TravelPoint.GRU,
            TravelPoint.BRC,
            TravelPoint.SCL,
            TravelPoint.ORL,
            TravelPoint.CDG
        };
        
        var result = RouteFinder.FindRouteByLowestPrice(DataUtils.AvailableRoutes, origin, destination);
        
        Assert.Equal(expectedPrice, result.FinalPrice);
        Assert.Equal(expectedRoutes, result.TravelRoutePoints);
    }

    [Fact]
    internal void FindRoute_ShouldReturnCheapestRoute_Price5()
    {
        const TravelPoint origin = TravelPoint.BRC;
        const TravelPoint destination = TravelPoint.SCL;

        const decimal expectedPrice = 5.00m;
        
        var expectedRoutes = new List<TravelPoint>
        {
            TravelPoint.BRC,
            TravelPoint.SCL
        };
        
        var result = RouteFinder.FindRouteByLowestPrice(DataUtils.AvailableRoutes, origin, destination);
        
        Assert.Equal(expectedPrice, result.FinalPrice);
        Assert.Equal(expectedRoutes, result.TravelRoutePoints);
    }
}