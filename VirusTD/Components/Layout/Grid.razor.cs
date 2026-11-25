using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using VirusTD.Interfaces;
using VirusTD.Models;
using System.Runtime.CompilerServices;

namespace VirusTD.Components.Layout
{
    public partial class Grid
    {
        //grid dimensions, if no parameters are passed when creating this grid.razor, defaults to a 10 x 10 grid
        [Parameter] public int Width { get; set; } = 10;
        [Parameter] public int Height { get; set; } = 10;

        [Parameter] public List<GridCell> GridCells {  get; set; }

        //This gets the project directory
        [Inject] private IWebHostEnvironment Env { get; set; } = default!;

        //is a property because it relies on an Inject
        private string mapDirectory => Path.Combine(Env.ContentRootPath, "Maps");
        string mapName;

         

        //Starts when blazor creates this component
        protected override void OnInitialized()
        {
            BuildGrid();
        }

        private void BuildGrid()
        {

            GridCells.Clear();
            int id = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GridCells.Add(new GridCell { Id = id++, X = x, Y = y });
                }
            }
        }

        //private void RefreshGridList()
        //{

          

        //    foreach (GridCell cell in cells) 
        //    { 
        //        if (cell.Occupant != null)     //This might not be needed but im still testing
        //        {
        //            OccupantList.Add(cell);
        //        }

        //    }

           


        //}

        private void BuildGrid(CellType[] cellTypes)
        {
            GridCells.Clear();
            int id = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GridCells.Add(new GridCell { Id = id++, X = x, Y = y, Type = cellTypes[id]});
                }
            }
        }


        //private void OnClickAddTower(GridCell cell)
        //{
        //    // Tower placement goes here later.
        //    //simple type check
        //    cell.Type = cell.Type == CellType.Buildable ? CellType.Path : CellType.Buildable;
        //    Debug.WriteLine(cell.Type);
        //    Debug.WriteLine(cell.X + "" + cell.Y);
        //}

        private void OnClickAddTower(GridCell cell)
        {

            if (cell.Type == CellType.Path)
            {
                cell.Occupant = new Zombie(cell.X, cell.Y, GridCells);
            }
            if (cell.Type == CellType.Buildable)
            {
                cell.Occupant = new Tower(cell.X, cell.Y, GridCells);
            }


        }



        private string GetMapPath(string name) 
        { 
            return Path.Combine(mapDirectory, name + ".csv");
        }
        private async Task<bool> LoadAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.WriteLine("Map name is empty");
                return false;
            }

            string path = GetMapPath(name);
            if (!File.Exists(path))
            {
                Debug.WriteLine($"No map named '{name}'");
                return false;
            }

            try
            {
                string typeList = await File.ReadAllTextAsync(path);
                var types = typeList.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => Enum.Parse<CellType>(s.Trim()))
                    .ToList();

                if (types.Count != GridCells.Count)
                {
                    Debug.WriteLine($"Map '{name}' has {types.Count} cells, grid has {GridCells.Count}");
                    return false;
                }

                for (int i = 0; i < GridCells.Count; i++)
                {
                    GridCells[i].Type = types[i];
                }
                Debug.WriteLine("Loaded");
                return true;
            }
            catch (Exception ex)
            {
                //Enum.Parse throws if the file contains a value that isn't a CellType
                Debug.WriteLine($"FAILED: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SaveAsync(string name)
        {
            
            try
            {
                string line = string.Join(",", GridCells.Select(c => c.Type));
                //Writes the lines of cell types to /Maps/name.csv
                await File.WriteAllTextAsync(Path.Combine(mapDirectory, name + ".csv"), line);
                Debug.WriteLine("Saved");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FAILED: {ex.Message}");
                return false;
            }
        }
    }
}
