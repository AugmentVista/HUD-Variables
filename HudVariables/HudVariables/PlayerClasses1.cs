using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    public class PlayerClasses1 : TextRPG
    {
        public int characterChoice;
        private static ConsoleKeyInfo input;
        public static Character SelectedCharacter;


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
            Random rnd = new Random();
            Character barbarian = new Character(1, 2, 3, 130, rnd.Next(1, 20), 80);
            SelectedCharacter = barbarian;
            Console.WriteLine("Barbarian Stats Set");
        }

        void SetGunSlingerStats()
        {
            Random rnd = new Random();
            Character gunslinger = new Character(2, 6, 2, 70, rnd.Next(1, 6), 70);
            SelectedCharacter = gunslinger;
            Console.WriteLine("Gunslinger Stats Set");
        }

        void SetClownStats()
        {
            Random rnd = new Random();
            Character clown = new Character(3, 3, 4, 90, rnd.Next(3, 12), 90);
            SelectedCharacter = clown;
            Console.WriteLine("Clown Stats Set");
        }


    }
}
