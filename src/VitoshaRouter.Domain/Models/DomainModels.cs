namespace VitoshaRouter.Domain.Models;

public enum OptimizationMode
{
    ModeA_MinTime = 0,
    ModeB_MinEffort = 1
}

public enum TrailClass
{
    TrackOrPaved = 0,          // k_ter = 1.00, d_base = 1.5
    ForestPathBelow1800m = 1,  // k_ter = 1.15, d_base = 3.0
    RockyOrRidgeAbove1800m = 2,// k_ter = 1.35, d_base = 4.5
    DemandingAlpine = 3        // k_ter = 1.60, d_base = 6.0
}

public class Node
{
    public int Id { get; set; }
    public long OsmId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double ElevationMeters { get; set; }
}

public class Edge
{
    public int Id { get; set; }
    public int FromNodeId { get; set; }
    public int ToNodeId { get; set; }
    public double LengthMeters { get; set; }
    public double ElevationDeltaMeters { get; set; }
    public double Slope { get; set; }
    public TrailClass TrailClass { get; set; }
    public bool IsExposedRidge { get; set; }
}

public class PointOfInterest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // Hut, Peak, Water, Viewpoint
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double ElevationMeters { get; set; }
    public int NearestNodeId { get; set; }
}

public record WeatherData(
    double PrecipitationMmPerHour,
    double WindSpeedMetersPerSec,
    double TemperatureCelsius,
    bool IsFromFallbackCache,
    string SourceWarning = "");

public record DynamicEdgeMetrics(
    double TimeMinutes,
    double DifficultyIndex,
    double EffortWeight);

public record RouteRequest(
    int StartNodeId,
    int EndNodeId,
    List<int> MandatoryNodeIds,
    double MaxTimeMinutes,
    double MaxDifficultyIndex,
    OptimizationMode Mode);

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