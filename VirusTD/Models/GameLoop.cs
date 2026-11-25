namespace VirusTD.Models
{
    public static class GameLoop
    {
        

        public static void gameloop(List<GridCell> GridCells) 
        {

            foreach (GridCell cell in GridCells) 
            {
                if (cell.Occupant is Tower tower)
                {
                    tower.FindZombie();
                    
                }                   
            }
            
        }

        public static void PreparationLoop() 
        {
        
        }

        public static void RoundLoop() 
        {
            


        }

    }
}
