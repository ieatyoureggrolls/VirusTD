using VirusTD.Interfaces;
using System.Diagnostics;

namespace VirusTD.Models
{
    public class Zombie : Occupant
    {

        public GridCell[,] TheGrid { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool explode;
        public int health = 5;
        public int ExplodeDamage;
        public int attack;

        public Zombie(int x, int y, GridCell[,] grid)
        {
            X = x;
            Y = y;
            TheGrid = grid;
        }

        //public void FindTower()
        //{
        //    foreach (GridCell cell in TheGrid)
        //    {
        //        if (cell.Occupant is Tower tower)
        //        {
        //            double distance = Math.Sqrt(
        //                Math.Pow(X - tower.X, 2) +
        //                Math.Pow(Y - tower.Y, 2)
        //            );

        //            if (distance <= 1)
        //            {

        //                AttackTower(tower);
        //            }
        //        }
        //    }
        //}

        public void IsHitBy(Tower tower) 
        {
            this.health -= tower.AttackDamage;
            if (this.health <= 0) 
            {
           //     TheGrid
            }
        }

        public void AttackTower(Tower tower)
        {
            // Attack tower here
        }
        static Random rand = new Random();
        public class BasicEnemy
        {
            //int choose = rand.Next(0, 2);
            int health = rand.Next(1, 4);
            int attack = rand.Next(0, 3);
            int speed = 3;


            //if(choose  == 0)
            //{

            //}
            //else if(choose == 1)
            //{

            //}
        }


        public class EliteEnemy()
        {
            int health = rand.Next(10, 20);
            int attack = rand.Next(1, 11);
            int speed = 2;
            //int choose = rand.Next(0, 2);

            //if (choose == 0)
            //{

            //}
            //else if (choose == 1)
            //{

            //}
        }

        public class BossEnemy()
        {
            int health = rand.Next(30, 51);
            int attack = rand.Next(12, 26);
            int speed = 1;
            //int choose = rand.Next(0, 2);

            //if (choose == 0)
            //{

            //}
            //else if (choose == 1)
            //{

            //}

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
