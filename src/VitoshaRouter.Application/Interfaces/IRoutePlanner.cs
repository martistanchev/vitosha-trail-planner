using VitoshaRouter.Domain.Models;

namespace VitoshaRouter.Application.Interfaces;

public interface IRoutePlanner
{
    RouteResult PlanRoute(RouteRequest request, WeatherData weather);
}
