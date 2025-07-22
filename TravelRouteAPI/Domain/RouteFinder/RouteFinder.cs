using Domain.Entities;
using Domain.Enums;

namespace Domain.RouteFinder;

public static class RouteFinder
{
    public static RouteFoundValueObject FindRouteByLowestPrice(
        ICollection<TravelRoute> availableRoutes, 
        TravelPoint origin, 
        TravelPoint destination)
    {
        var travelRoutePointsList = new List<TravelPoint>();
        var priceSum = 0m;

        var startPoint = availableRoutes.First(x => x.Origin == origin);
        var currentPoint = startPoint;

        while (currentPoint.Destination != destination)
        {
            TravelRoute? nextPoint = null;
            
            // Obtém todas as rotas possíveis para o destino.
            var possibleNextPoints = availableRoutes.Where(x => x.Origin == currentPoint.Destination).ToList();
            
            // Caso tenha mais de uma rota possível para o destino, obtém a de menor preço, caso contrário pega a unica.
            nextPoint = possibleNextPoints.Count > 1 ? 
                possibleNextPoints.MinBy(x => x.Price) : 
                possibleNextPoints.First();

            // Apenas adiciona somente o ponto de destino na lista quando ela já contêm o ponto de origem (evitar duplicidade). 
            if (travelRoutePointsList.Contains(currentPoint.Origin))
            {
                travelRoutePointsList.Add(currentPoint.Destination);
            }
            // Caso contrário, adiciona os dois pontos de origem e destino.
            else
            {
                travelRoutePointsList.AddRange([currentPoint.Origin, currentPoint.Destination]);
            }
            
            priceSum += currentPoint.Price;
            currentPoint = nextPoint;
        }

        // Sempre tratar a condição de regra de exceção que não atende a execução do loop, e.g:
        // - Quando o ponto objetivo final for igual ao ponto de destino do "currentPoint.Destination".
        // - Quando no mesmo objeto "TravelRoute" ele contém tanto a origem como tambem o destino (viagem curta).
        if (currentPoint.Destination == destination)
        {
            if (travelRoutePointsList.Count == 0)
            {
                travelRoutePointsList.AddRange([currentPoint.Origin, currentPoint.Destination]);
            }
            else
            {
                travelRoutePointsList.Add(destination);
            }
            
            priceSum += currentPoint.Price;
        }

        return new RouteFoundValueObject
        {
            TravelRoutePoints = travelRoutePointsList,
            FinalPrice = priceSum
        };
    }
}