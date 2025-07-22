using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests;

internal static class DbContextUtils
{
    internal static AppDbContext CreateAndSeedDatabase()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        var context = new AppDbContext(options);
        context.Set<TravelRoute>();
        context.AddRange(MockDataUtils.AvailableRoutes);
        context.SaveChanges();
        
        return context;
    }
}