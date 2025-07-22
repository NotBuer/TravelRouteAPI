using Domain.Enums;

namespace Application.Response;

public record RouteFoundResponse
{
    public ICollection<TravelPoint> TravelRoutePoints { get; set; }
    public decimal FinalPrice { get; set; }
    public string Message { get; set; }
}