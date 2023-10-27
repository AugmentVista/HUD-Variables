using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;


namespace HudVariables
{
    public class TextRPG
    {
        #region Declarations

        
        public static int lives = 3; // having these as static means that other scripts can change them
        public static int level = 1;
        public int score = 0;
        public static int health = 100;
        public static int Damage = 0;
        public static int enemyDamage;
        public static int enemyHealth = 50;
        public int enemyRemainingHealth;
        public static int shield = 100;
        public int leftOverDamage;
        public static int scoreMult = 1 * level;
        public string playername;
        Enemies Enemy = new Enemies();
        PlayerClasses1 player = new PlayerClasses1();
        #endregion

        static void Main(string[] args)
        {
            PlayerClasses1 player = new PlayerClasses1();
            string studioName = "NameWasTakenStudios";
            string playerName;
            Console.WriteLine("Brought to you by " + studioName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome player please enter your name");
            playerName = Console.ReadLine();
            Console.WriteLine("Hello " + playerName);
            Console.WriteLine("Begin!");
            player.KeyInput();
            Begin();
        }

        void ResetGame()
        {
        Console.WriteLine("Your progress has been reset");
        scoreMult = 1;
        lives = 3;
        level = 1;
        score = 0;
        health = 100;
        Damage = 0;
        enemyDamage = 0;
        enemyHealth = 50;
        enemyRemainingHealth = 0;
        shield = 100;
        leftOverDamage = 0;
        ShowHUD();
        }


        public static void Begin()
        {
            TextRPG game = new TextRPG();
            game.Start(); 
        }
        
        public void Start()
        {
            
            ShowHUD();
            Enemy.SpawnEnemy(1);
            Enemy.ShowEnemyHUD();
            Enemy.SpawnEnemy(2);
            Enemy.ShowEnemyHUD();
            TakeDamage(5);
            ShowHUD();
            DealDamage(25);
            ShowHUD();
            TakeDamage(-5);
            ShowHUD();
            DealDamage(25);
            ShowHUD();
            TakeDamage(150);
            ShowHUD();
            Heal(50);
            ShowHUD();
            Heal(-10);
            ShowHUD();
            Heal(200);
            ShowHUD();
            RegenerateShield(50);
            ShowHUD();
            RegenerateShield(-10);
            ShowHUD();
            TakeDamage(200);
            Revive();
            TakeDamage(200);
            ShowHUD();
            Revive();
            TakeDamage(200);
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            Revive();
            LivesCheck();
            ResetGame();
        }

        void RegenerateShield(int Shield)
        {
            if (Shield <= -1)
            {
                Console.WriteLine("Player tried to gain " + Shield + " shields");
                Console.WriteLine("You cannot gain a negative amount of shield");
                return;
            }
            if (shield <= 100)
            {
                Console.WriteLine("You have gained " + Shield + " shields");
                shield = shield + Shield;
            }
            else if (shield >= 100)
            {
                shield = 100;
                Console.WriteLine("You cannot have greater than 100 shield");
            }

        }
        public void Heal(int Health)
        {
            if (Health <= -1)
            {
                Console.WriteLine("Player tried to gain " + Health + " health");
                Console.WriteLine("You cannot gain a negative amount of health");
                return;
            }
            if (health <= 100)
            {
                Console.WriteLine("You have gained " + Health + " health");
            if (Health >= 100)
            { 
                Console.WriteLine("You cannot have more than 100 health"); 
            }
                health = health + Health;
                if (health >= 100)
                {
                    health = 100;
                }
            }
            else if (health >= 100)
            {
                health = 100;
                Console.WriteLine("You cannot have greater than 100 health");
            }
        }

        void LivesCheck()
        {
            if (lives <= 0)
            {
                health = 0;
                shield = 0;
                Console.WriteLine(playername + " HAS DIED ");
            }
        }

        void Revive()
        {
            Console.WriteLine("You've lost a life, your health and shields have been restored");
            lives--;
            health = 100;
            shield = 100;
        }

        void DealDamage(int damage)
        {
            Console.WriteLine("You have Dealt " + damage + " damage");
            enemyHealth -= (damage + Damage); // () needed for order of operations
            if (enemyHealth <= 0)
            {
                score += 100;
                level++;
                Console.WriteLine("You have slain an enemy");
            }
        }

        void TakeDamage(int damage)

        {
            if (damage <= -1)
            {
                Console.WriteLine("Player tried to take " + damage + " damage");
                Console.WriteLine("You cannot take a negative amount of damage");
                return;
            }


            Console.WriteLine("You have taken " + damage +" damage");
            shield = shield - damage;
            if (shield <= 0)
            {
                health = health + shield;
                if (health <= 0)
                {
                    health = 0;
                    //Revive();
                }
                LivesCheck();
                shield = 0;
            }
        }
        public void ShowHUD()
        {
            Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Shield " + shield + " Bonus Damage " + Damage);
            Console.WriteLine("LEVEL " + level);
            Console.ReadKey();

        }
        

    }
}