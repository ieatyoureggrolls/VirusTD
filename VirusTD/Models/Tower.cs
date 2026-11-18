namespace VirusTD.Models
{
    public class Tower
    {
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
        public int MotionRange { get; set; } //this is not how it will be at the end

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

        public void IsHitby(Enemy enemy) 
        {

            Illness += enemy.attack;
            CheckInfected();
        }

        public void Quarantined() 
        {

            Illness--;


        }

    }
}
