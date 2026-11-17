using VitoshaRouter.Domain.Models;

namespace VitoshaRouter.Application.Interfaces;

public interface IGraphRepository
{
    IReadOnlyDictionary<int, Node> GetNodes();
    IReadOnlyDictionary<int, List<Edge>> GetAdjacencyList();
    IReadOnlyList<PointOfInterest> GetPointsOfInterest();
}
