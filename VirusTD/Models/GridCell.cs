using VirusTD.Interfaces;

namespace VirusTD
{
    public enum CellType { Buildable, Path }
    public class GridCell
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CellType Type { get; set; } = CellType.Buildable;
        //If there is a tower or enemy
        public Occupant? Occupant { get; set; }

    }
}
