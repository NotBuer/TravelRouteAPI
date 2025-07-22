using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SeedData;

internal class TravelRouteSeedData
{
    public void Seeding(DbContext context)
    {
        context.Set<TravelRoute>().AddRange(
            new TravelRoute { Origin = TravelPoint.GRU, Destination = TravelPoint.BRC, Price = 10.00m },
            new TravelRoute { Origin = TravelPoint.BRC, Destination = TravelPoint.SCL, Price = 5.00m },
            new TravelRoute { Origin = TravelPoint.GRU, Destination = TravelPoint.CDG, Price = 75.00m },
            new TravelRoute { Origin = TravelPoint.GRU, Destination = TravelPoint.SCL, Price = 20.00m },
            new TravelRoute { Origin = TravelPoint.GRU, Destination = TravelPoint.ORL, Price = 56.00m },
            new TravelRoute { Origin = TravelPoint.ORL, Destination = TravelPoint.CDG, Price = 5.00m },
            new TravelRoute { Origin = TravelPoint.SCL, Destination = TravelPoint.ORL, Price = 20.00m }
        );
    }
}