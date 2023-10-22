﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace HudVariables
{
    public class TextRPG
    {
        #region Declarations

        static int lives = 3;
        public static int level = 1;
        public int score = 0;
        public int health = 100;
        public int Damage = 0;
        public static int enemyDamage;
        public int enemyHealth = 50;
        public int enemyRemainingHealth;
        public int shield = 100;
        public int leftOverDamage;
        public static int scoreMult = 1 * level;
        public string playername;
        #endregion

        public static void Main(string[] args)
        {
            UnitTestHealthSystem();
            /*string studioName = "NameWasTakenStudios";
            string playerName;
            Console.WriteLine("Brought to you by " + studioName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome player please enter your name");
            playerName = Console.ReadLine();
            Console.ReadLine();
            Console.WriteLine("Hello " + playerName);
            Console.WriteLine("Begin!");*/
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
        void Heal(int Health)
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
            enemyHealth -= damage;
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
        void ShowHUD()
        {
            Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Shield " + shield + " Score Multiplier " + scoreMult);
            Console.WriteLine("LEVEL " + level);
            Console.ReadKey();

        }
        static void UnitTestHealthSystem()
        {
	        Debug.WriteLine("Unit testing Health System started...");

	        // TakeDamage()

	        // TakeDamage() - only shield
	        shield = 100;
	        health = 100;
	        lives = 3;
	        TakeDamage(10);
	        Debug.Assert(shield == 90);
	        Debug.Assert(health == 100);
	        Debug.Assert(lives == 3);

	        // TakeDamage() - shield and health
	        shield = 10;
	        health = 100;
	        lives = 3;
	        TakeDamage(50);
	        Debug.Assert(shield == 0);
	        Debug.Assert(health == 60);
	        Debug.Assert(lives == 3);

	        // TakeDamage() - only health
	        shield = 0;
	        health = 50;
	        lives = 3;
	        TakeDamage(10);
	        Debug.Assert(shield == 0);
	        Debug.Assert(health == 40);
	        Debug.Assert(lives == 3);

	        // TakeDamage() - health and lives
	        shield = 0;
	        health = 10;
	        lives = 3;
	        TakeDamage(25);
	        Debug.Assert(shield == 0);
	        Debug.Assert(health == 0);
	        Debug.Assert(lives == 3);

	        // TakeDamage() - shield, health, and lives
	        shield = 5;
	        health = 100;
	        lives = 3;
	        TakeDamage(110);
	        Debug.Assert(shield == 0);
	        Debug.Assert(health == 0);
	        Debug.Assert(lives == 3);

	        // TakeDamage() - negative input
	        shield = 50;
	        health = 50;
	        lives = 3;
	        TakeDamage(-10);
	        Debug.Assert(shield == 50);
	        Debug.Assert(health == 50);
	        Debug.Assert(lives == 3);

	        // Heal()
	
	        // Heal() - normal
	        shield = 0;
	        health = 90;
	        lives = 3;
	        Heal(5);
	        Debug.Assert(shield == 0);
	        Debug.Assert(health == 95);
	        Debug.Assert(lives == 3);

	        // Heal() - already max health
	        shield = 90;
	        health = 100;
	        lives = 3;
	        Heal(5);
	        Debug.Assert(shield == 90);
	        Debug.Assert(health == 100);
	        Debug.Assert(lives == 3);
	
	        // Heal() - negative input
	        shield = 50;
	        health = 50;
	        lives = 3;
	        Heal(-10);
	        Debug.Assert(shield == 50);
	        Debug.Assert(health == 50);
	        Debug.Assert(lives == 3);

	        // RegenerateShield()

	        // RegenerateShield() - normal
	        shield = 50;
	        health = 100;
	        lives = 3;
	        RegenerateShield(10);
	        Debug.Assert(shield == 60);
	        Debug.Assert(health == 100);
	        Debug.Assert(lives == 3);

	        // RegenerateShield() - already max shield
	        shield = 100;
	        health = 100;
	        lives = 3;
	        RegenerateShield(10);
	        Debug.Assert(shield == 100);
	        Debug.Assert(health == 100);
	        Debug.Assert(lives == 3);

	        // RegenerateShield() - negative input
	        shield = 50;
	        health = 50;
	        lives = 3;
	        RegenerateShield(-10);
	        Debug.Assert(shield == 50);
	        Debug.Assert(health == 50);
	        Debug.Assert(lives == 3);

	        // Revive()

	        // Revive()
	        shield = 0;
	        health = 0;
	        lives = 2;
	        Revive();
	        Debug.Assert(shield == 100);
	        Debug.Assert(health == 100);
	        Debug.Assert(lives == 1);

	        Debug.WriteLine("Unit testing Health System completed.");
	        Console.Clear();
        }


    }
}