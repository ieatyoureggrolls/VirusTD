using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using VirusTD.Interfaces;
using VirusTD.Models;

namespace VirusTD.Components.Layout
{
    public partial class Grid : FileIO
    {
        //grid dimensions, if no parameters are passed when creating this grid.razor, defaults to a 10 x 10 grid
        [Parameter] public int Width { get; set; } = 10;
        [Parameter] public int Height { get; set; } = 10;

        private List<GridCell> cells = new();

        //Starts when blazor creates this component
        protected override void OnInitialized()
        {
            BuildGrid();
        }

        private void BuildGrid()
        {
            //Clears cel array
            cells.Clear();
            //Setd id to 0, this will be used to keep track of a cell
            int id = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    //Initializes and adds a GridCell class to the cells array
                    cells.Add(new GridCell { Id = id++, X = x, Y = y });
                }
            }
        }

        private void HandleCellClicked(GridCell cell)
        {
            // Tower placement goes here later.
            //simple type check
            cell.Type = cell.Type == CellType.Buildable ? CellType.Path : CellType.Buildable;
            Debug.WriteLine(cell.Type);
            Debug.WriteLine(cell.X + "" + cell.Y);
        }

        private void OnClickAddTower(GridCell cell)
        {

            // cell.Occupant = new Tower(cell.X, cell.Y); WORK IN PROGRESS
            if (cell.Type == CellType.Path)
            {
                cell.Occupant = new Zombie();
            }
            if (cell.Type == CellType.Buildable)
            {
                cell.Occupant = new Tower(cell.X, cell.Y);
            }


        }
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
