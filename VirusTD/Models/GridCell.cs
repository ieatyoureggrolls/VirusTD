namespace VirusTD.Models;
public enum CellType { Buildable, Path }
public class GridCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public CellType Type { get; set; } = CellType.Buildable;
}
