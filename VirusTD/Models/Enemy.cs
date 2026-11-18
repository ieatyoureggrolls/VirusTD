namespace VirusTD.Models
{
    public class Enemy
    {
        public bool explode;
        public int health;

        public int ExplodeDamage;
        public int attack;
        Random rand = new Random();
        public void BasicEnemyStats(int health,int attack )
        {
            health = rand.Next(1, 4);
            attack = rand.Next(0, 3);
        }

        
        public void EliteEnemyStats(int health, int attack)
        {
            health = rand.Next(10, 20);
            attack = rand.Next(1, 11);
        }

        public void BossEnemyStats(int health, int attack)
        {
            health = rand.Next(30, 51);
            attack = rand.Next(12, 26);

            //int ChanceToExplode = rand.Next(1, 101);

            //if(ChanceToExplode > 80)
            //{
            //    explode = true;
            //}

            //if(explode == true)
            //{
            //    ExplodeDamage = rand.Next(20, 51);
            //}
        }
    }
}
