using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{

    public class Character
    {
        public int CharacterChoice { get; }
        public int PlayerAttacks { get; }
        public int Lives { get; }
        public int Health { get; }
        public int Damage { get; }
        public int Shield { get; }

        public Character(int choice, int attacks, int lives, int health, int damage, int shield)
        {
            CharacterChoice = choice;
            PlayerAttacks = attacks;
            Lives = lives;
            Health = health;
            Damage = damage;
            Shield = shield;
        }
    }
}

