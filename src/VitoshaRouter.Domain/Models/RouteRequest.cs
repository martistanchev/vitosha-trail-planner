namespace VitoshaRouter.Domain.Models;

public record RouteRequest(
    int StartNodeId,
    int EndNodeId,
    List<int> MandatoryNodeIds,
    double MaxTimeMinutes,
    double MaxDifficultyIndex,
    OptimizationMode Mode);
