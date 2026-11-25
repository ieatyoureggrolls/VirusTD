using VirusTD.Interfaces;
using System.Diagnostics;

namespace VirusTD.Models
{
    public class Tower : Occupant
    {

        public List<GridCell> TheGrid { get; set; }

        public int Y { get; set; }
        public int X { get; set; }

        public Tower(int x, int y, List<GridCell> grid)
        {
            Y = y;
            X = x;
            TheGrid = grid;
        }

       
        public int Immunity { get; set
            {
                if (value < 0) { value = 0; }
            }
        } = 10;
        public int Illness { get; set 
            {
                if (value < 0) { value = 0;}
            }
        } = 0;
        public bool IsInfected { get; set; } = false;
        public int AttackDamage { get; set 
            {
                if (value < 0) { value = 1; }
            }
        } = 4;
        public int Cost { get; set; } = 10;
        public int Radius { get; set; } = 2;

        public int LowXRange => X - Radius < 0 ? 0 : X - Radius;
        public int HighXRange => X + Radius;
        public int LowYRange => Y - Radius < 0 ? 0 : Y - Radius;
        public int HighYRange => Y + Radius;


        public void FindZombie()
        {
            foreach (GridCell cell in TheGrid)
            {
                if (cell.Occupant is Zombie zombie)
                {
                    double distance = Math.Sqrt(
                        Math.Pow(X - zombie.X, 2) +
                        Math.Pow(Y - zombie.Y, 2)
                    );

                    if (distance <= Radius)
                    {
                        
                        HitZombie(zombie);
                    }
                }
            }
        }

        public void HitZombie(Zombie zombie) 
        {

            zombie.IsHitBy(this);
            Debug.WriteLine(zombie.health);
            
            Debug.WriteLine(zombie.health);
        }

        public void CheckInfected() 
        {
            if (Illness > Immunity)
            {
                IsInfected = true;
            }
            else if (Illness < Immunity) 
            {
                IsInfected = false;
            }
        }

        public void IsHitby(Zombie enemy) 
        {

           // Illness += enemy.attack;
          //  CheckInfected();
          
        }

        public void HitZombie() 
        {
            
        }
        public void Quarantined() 
        {

            Illness--;


        }

        

    }
}
