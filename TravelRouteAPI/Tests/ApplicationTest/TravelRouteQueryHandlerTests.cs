using Application.QueryHandler;
using Domain.Enums;

namespace Tests.ApplicationTest;

public class TravelRouteQueryHandlerTests
{
    [Fact]
    internal async Task HandleGetRouteByLowestPrice_ShouldReturnCorrectRouteAndMessage_Price40()
    {
        var context = DbContextUtils.CreateAndSeedDatabase();

        var queryHandler = new TravelRouteQueryHandler(context);
        
        const TravelPoint origin = TravelPoint.GRU;
        const TravelPoint destination = TravelPoint.CDG;
        
        var expectedRoutes = new List<TravelPoint>
        {
            TravelPoint.GRU,
            TravelPoint.BRC,
            TravelPoint.SCL,
            TravelPoint.ORL,
            TravelPoint.CDG
        };

        const decimal expectedPrice = 40.00m;
        const string expectedMessage = "GRU-BRC-SCL-ORL-CDG at costs of $40,00";

        var result = await queryHandler.HandleGetRouteByLowestPrice(origin, destination, CancellationToken.None);
        
        Assert.NotNull(result);
        Assert.Equal(expectedRoutes, result.TravelRoutePoints);
        Assert.Equal(expectedPrice, result.FinalPrice);
        Assert.Equal(expectedMessage, result.Message);
    }
    
    [Fact]
    internal async Task HandleGetRouteByLowestPrice_ShouldReturnCorrectRouteAndMessage_Price5()
    {
        var context = DbContextUtils.CreateAndSeedDatabase();

        var queryHandler = new TravelRouteQueryHandler(context);
        
        const TravelPoint origin = TravelPoint.BRC;
        const TravelPoint destination = TravelPoint.SCL;
        
        const decimal expectedPrice = 5.00m;
        const string expectedMessage = "BRC-SCL at costs of $5,00";
        
        var expectedRoutes = new List<TravelPoint>
        {
            TravelPoint.BRC,
            TravelPoint.SCL
        };

        var result = await queryHandler.HandleGetRouteByLowestPrice(origin, destination, CancellationToken.None);
        
        Assert.NotNull(result);
        Assert.Equal(expectedRoutes, result.TravelRoutePoints);
        Assert.Equal(expectedPrice, result.FinalPrice);
        Assert.Equal(expectedMessage, result.Message);
    }
}