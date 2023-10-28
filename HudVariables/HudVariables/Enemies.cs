using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    public class Enemies : TextRPG
    {
        public static int NumberOfEnemyAttacks;


        public void SpawnEnemy(int EnemyLevel)
        {
            if (EnemyLevel == 1)
            {
                NumberOfEnemyAttacks = 2;
                enemyHealth = 50;
                enemyDamage = 5;
            }
            else if (EnemyLevel == 2)
            {
                NumberOfEnemyAttacks = 2;
                enemyHealth = 100;
                enemyDamage = 15;
            }
            else if (EnemyLevel == 3)
            {
                NumberOfEnemyAttacks = 3;
                enemyHealth = 200;
                enemyDamage = 25;
            }
            else if (EnemyLevel == 4)
            {
                NumberOfEnemyAttacks = 3;
                enemyHealth = 300;
                enemyDamage = 40;
            }
            else if (EnemyLevel == 5)
            {
                NumberOfEnemyAttacks = 4;
                enemyHealth = 400;
                enemyDamage = 50;
            }

        }

        public void ShowEnemyHUD()
        {
            {
                Console.WriteLine(" Enemy Health: " + enemyHealth + " Enemy Damage " + enemyDamage);
            }
        }
    }
}
