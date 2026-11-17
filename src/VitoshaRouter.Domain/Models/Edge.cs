namespace VitoshaRouter.Domain.Models;

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
