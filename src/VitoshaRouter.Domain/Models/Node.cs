namespace VitoshaRouter.Domain.Models;

public class Node
{
    public int Id { get; set; }
    public long OsmId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double ElevationMeters { get; set; }
}
