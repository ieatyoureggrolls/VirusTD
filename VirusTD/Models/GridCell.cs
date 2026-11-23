using VirusTD.Interfaces;

namespace VirusTD
{
    //Type of cell
    public enum CellType { Buildable, Path }
    public class GridCell : FileIO
    {
        public int Id { get; set; }
        //x position
        public int X { get; set; }
        //y position
        public int Y { get; set; }
        public CellType Type { get; set; } = CellType.Buildable;
        //If there is a tower or enemy, this could change. It's meant to be a way to check if a tower or an enemy is on a cell
        public Occupant? Occupant { get; set; }

        public int Load(object objectToLoad)
        {
            throw new NotImplementedException();
        }

        public int Save(string[] fieldsToSave)
        {
            throw new NotImplementedException();
        }
    }
}
