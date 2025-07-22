using Domain.Enums;

namespace Application.Response;

public record TravelRouteResponse
{
    public TravelPoint Origin { get; set; }
    public TravelPoint Destination { get; set; }
    public decimal Price { get; set; }
}