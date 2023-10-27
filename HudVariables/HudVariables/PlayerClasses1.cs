using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    public class PlayerClasses1 : TextRPG
    {
        private static ConsoleKeyInfo input;


        public void KeyInput()
        {
            Console.WriteLine("Press '1' for Barbarian or '2' for Gunslinger or '3' for Clown"); // turn this into a character class select like 1. for Barbarian 2. for Gunslinger 3. for Clown etc
            input = Console.ReadKey(true); // true means that it will not display on the console 
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    {
                        SetBarbarianStats();
                    }
                break;

                case ConsoleKey.D2:
                    {
                        SetGunSlingerStats();
                    }
                break;
                case ConsoleKey.D3:
                    {
                       SetClownStats();
                    }
                break;
            }
        }

        void SetBarbarianStats()
        {
            lives = 3;
            health = 130;
            Damage = 4;
            shield = 80;
            Console.WriteLine("Barbarian Stats Set");
        }

        void SetGunSlingerStats()
        {
            lives = 2;
            health = 70;
            Damage = 3;
            shield = 70;
            Console.WriteLine("Gunslinger Stats Set");
        }

        void SetClownStats()
        {
            lives = 4;
            health = 90;
            Damage = 2;
            shield = 90;
            Console.WriteLine("Clown Stats Set");
        }


    }
}
