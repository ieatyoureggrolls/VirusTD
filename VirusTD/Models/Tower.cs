using VirusTD.Interfaces;

namespace VirusTD.Models
{
    public class Tower : Occupant
    {

        public int yCoord { get; set; }
        public int xCoord { get; set; }

        public Tower(int x, int y) 
        {
            yCoord = y;
            xCoord = x;
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
        public int Range { get; set; } 

        public int attackRange { get; set; }

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

        public void Quarantined() 
        {

            Illness--;


        }

        

    }
}
