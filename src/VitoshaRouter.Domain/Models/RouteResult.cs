namespace VitoshaRouter.Domain.Models;

public record RouteResult(
    bool IsSuccess,
    string? ErrorCode,
    string? DiagnosticMessage,
    double TotalTimeMinutes,
    double TotalEffortWeight,
    double MaxEdgeDifficulty,
    double? MinPossibleTimeMinutes,
    double? MinRequiredDifficultyThreshold,
    List<Node> PathNodes,
    WeatherData AppliedWeather);
