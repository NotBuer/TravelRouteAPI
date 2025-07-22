using Domain.Entities;
using Domain.Enums;

namespace Tests;

internal static class DataUtils
{
    // Exatamente na mesma ordem do que foi pedido no requisito.
    internal static readonly List<TravelRoute> AvailableRoutes =
    [
        new() { Origin = TravelPoint.GRU, Destination = TravelPoint.BRC, Price = 10.00m },
        new() { Origin = TravelPoint.BRC, Destination = TravelPoint.SCL, Price = 5.00m },
        new() { Origin = TravelPoint.GRU, Destination = TravelPoint.CDG, Price = 75.00m },
        new() { Origin = TravelPoint.GRU, Destination = TravelPoint.SCL, Price = 20.00m },
        new() { Origin = TravelPoint.GRU, Destination = TravelPoint.ORL, Price = 56.00m },
        new() { Origin = TravelPoint.ORL, Destination = TravelPoint.CDG, Price = 5.00m },
        new() { Origin = TravelPoint.SCL, Destination = TravelPoint.ORL, Price = 20.00m }
    ];
}