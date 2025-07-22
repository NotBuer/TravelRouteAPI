using Domain.Enums;

namespace Domain.RouteFinder;

public record RouteFoundValueObject
{
    public ICollection<TravelPoint> TravelRoutePoints { get; set; }
    public decimal FinalPrice { get; set; }
}