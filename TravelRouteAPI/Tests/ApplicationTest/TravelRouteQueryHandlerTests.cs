using Application.QueryHandler;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests.ApplicationTest;

public class TravelRouteQueryHandlerTests
{
    private AppDbContext _context;
    private DbSet<TravelRoute> _dbSet;

    internal void SeedDatabase()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        _context = new AppDbContext(options);
        _dbSet = _context.Set<TravelRoute>();
        _context.AddRange(DataUtils.AvailableRoutes);
        _context.SaveChanges();
    }

    [Fact]
    internal async Task HandleGetRouteByLowestPrice_ShouldReturnCorrectRouteAndMessage_Price40()
    {
        SeedDatabase();

        var queryHandler = new TravelRouteQueryHandler(_context);
        
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
}