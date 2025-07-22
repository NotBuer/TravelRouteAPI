using Domain.Enums;

namespace Application.Request;

public record TravelRouteRequest
{
    public TravelPoint Origin { get; set; }
    public TravelPoint Destination { get; set; }
    public decimal Price { get; set; }
}