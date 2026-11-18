public enum CellType { Empty, Path, Enemy, Tower, Quarentine }

public class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public CellType Type { get; set; } = CellType.Empty;
}
