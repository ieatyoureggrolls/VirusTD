namespace VirusTD.Models
{
    public class Enemy
    {
        public int health;

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
    }
}
