using VitoshaRouter.Domain.Models;

namespace VitoshaRouter.Application.Interfaces;

public interface IEdgeEvaluator
{
    DynamicEdgeMetrics EvaluateEdge(Edge edge, WeatherData weather);
}
