using Domain.Enums;

namespace Application.Request;

public record TravelRouteAddRequest
{
    public TravelPoint Origin { get; set; }
    public TravelPoint Destination { get; set; }
    public decimal Price { get; set; }
}