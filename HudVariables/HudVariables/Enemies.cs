using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    public class Enemies : TextRPG
    {
        // what do enemies need? 
        //
        // they need a health variable, they need a damage variable, they need the ability to attack, they need the ability to die



        public void SpawnEnemy(int EnemyLevel)
        {
            if (EnemyLevel == 1)
            {
                enemyHealth = 50;
                enemyDamage = 50;
            }
            else if (EnemyLevel == 2)
            {
                enemyHealth = 100;
                enemyDamage = 100;
            }
            else if (EnemyLevel == 3)
            {
                enemyHealth = 200;
                enemyDamage = 200;
            }
            else if (EnemyLevel == 4)
            {
                enemyHealth =300;
                enemyDamage = 300;
            }
            else if (EnemyLevel == 5)
            {
                enemyHealth = 400;
                enemyDamage = 400;
            }

        }


        public void ShowEnemyHUD()
        {
            Console.WriteLine("Value " + enemyHealth + enemyDamage + " Enemy Health: " + enemyHealth + " Enemy Damage" + enemyDamage);

        }

    } 
}
