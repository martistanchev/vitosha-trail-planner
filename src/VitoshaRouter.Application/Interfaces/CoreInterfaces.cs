using VitoshaRouter.Domain.Models;

namespace VitoshaRouter.Application.Interfaces;

public interface IGraphRepository
{
    IReadOnlyDictionary<int, Node> GetNodes();
    IReadOnlyDictionary<int, List<Edge>> GetAdjacencyList();
    IReadOnlyList<PointOfInterest> GetPointsOfInterest();
}

public interface IWeatherService
{
    Task<WeatherData> GetCurrentWeatherAsync(double latitude, double longitude, double elevationMeters, CancellationToken ct = default);
}

public interface IEdgeEvaluator
{
    DynamicEdgeMetrics EvaluateEdge(Edge edge, WeatherData weather);
}

public interface IRoutePlanner
{
    RouteResult PlanRoute(RouteRequest request, WeatherData weather);
}