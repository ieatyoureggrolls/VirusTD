namespace VirusTD
{
    public class TestEnemy
    {
        public int health;

        public int attack;
        Random rand = new Random();
        public void TestEnemyStats(int health,int attack )
        {
            health = rand.Next(1, 4);
            attack = rand.Next(0, 3);
        }
    }
}
