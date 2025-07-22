using Domain.Enums;

namespace Domain.Entities;

public class TravelRoute
{
    public int Id { get; set; }
    public TravelPoint Origin { get; set; }
    public TravelPoint Destination { get; set; }
    public decimal Price { get; set; }
}