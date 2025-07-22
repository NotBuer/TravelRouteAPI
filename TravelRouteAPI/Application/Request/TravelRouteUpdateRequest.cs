using Domain.Enums;

namespace Application.Request;

public record TravelRouteUpdateRequest
{
    public int Id { get; set; }
    public TravelPoint Origin { get; set; }
    public TravelPoint Destination { get; set; }
    public decimal Price { get; set; }
}