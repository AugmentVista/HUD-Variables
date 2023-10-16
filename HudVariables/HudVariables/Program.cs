using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    class Questions
    {
        #region Declarations
        /* Int declarations */
        public static int level = 0;
        /* String declarations */
        public string question;
        public string correctAnswer;
        public string userAnswer;
        public string studioName;
        public string finalAnswer;
        public string playerName;
        /* Float declarations */
        static float scoreMult; static float lives;
        /* Bool declarations */
        public static ConsoleKeyInfo input;
        #endregion

        public Questions(string aQuestion, string aCorrectAnswer)
        {
            question = aQuestion;
            correctAnswer = aCorrectAnswer;
        }


        public bool ValidateAnswer(string aUserAnswer)
        {
            if (aUserAnswer == "easy" || aUserAnswer == "medium" || aUserAnswer == "hard")
            {
                return true;
            }
            Console.WriteLine("Invalid answer.");
            Console.WriteLine("Please choose between \"easy\", \"medium\" or \"hard\".");
            return false;
        }

        //checks that the answer given by the user is acceptable
        public bool VerifyAnswer(string aUserAnswer)
        {
            return aUserAnswer == correctAnswer;
        }

        static void Main(string[] args)
        {
            /* Int initializations */
            int Damage = 0;
            /* String initializations*/
            string studioName = "NameWasTakenStudios"; string playerName;
            /* Float initializations */
            float scoreMult = 1.00f; int lives = 3;


            // Opening phrases to player

            Console.WriteLine("Brought to you by " + studioName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome player please enter your name");
            playerName = Console.ReadLine();
            Console.ReadLine();
            Console.WriteLine("Hello " + playerName);
            Console.WriteLine("Begin!");
            Console.ReadKey();
            Questions firstQuestion = new Questions("Please select your difficulty", "hard");  // string hard after difficulty string is needed to provide an arguement that corresponds to aCorrectAnswer
            Console.WriteLine(firstQuestion.question);
            Console.WriteLine("----");
            Console.WriteLine("easy");
            Console.WriteLine("medium");
            Console.WriteLine("hard");
            Console.Write("Your answer is: ");

            string answer = Console.ReadLine().ToLower();
            while (!firstQuestion.ValidateAnswer(answer))
            {
                answer = Console.ReadLine().ToLower();
                string finalAnswer = Console.ReadLine();

            }
            Console.ReadLine();
            // End of difficulty question

            Console.WriteLine("You have selected " + answer);
            Console.ReadKey();
            if (answer == "easy")
            {
                scoreMult = 1.00f;
                lives = 5;
                Damage = 2;
            }
            else if (answer == "medium")
            {
                scoreMult = 1.5f;
                lives = 4;
                Damage = 7;
            }
            else if (answer == "hard")
            {
                scoreMult = 2.0f;
                lives = 3;
                Damage = 5;
            }
            Program.Notmain();
        }
    }

    // Class Divide 
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Class Divide
    class Program
    {

        #region Declarations
        /* Int declarations */
        public int score; public int health; public int Damage;
        public static int selectedDifficulty; public static int enemyDamage; public static int level = 1;
        public static int activeWeapon; public static int Stick = 2; public int enemyHealth;
        public int enemyRemainingHealth;
        /* String declarations */

        /* Float declarations */
        static float scoreMult; static float lives;
        /* Bool declarations */
        public static ConsoleKeyInfo input;
        private static Random randomResult;
        #endregion


        public static void Notmain()
        {
            /* Int initializations */
            int score = 0; int health = 100; int Damage = 0; int enemyHealth = level * 10; int damage; int shield = 100;
            int test = 66;
            /* String initializations*/
            string studioName = "NameWasTakenStudios"; string playerName;
            /* Float initializations */
            float scoreMult = 1.00f; float lives = 3.00f;


            Console.WriteLine("You begin your journey with a sturdy stick");
            Console.WriteLine();
            int activeWeapon = Stick;
            Console.WriteLine("before you stands your first enemy, a goblin that stole your lunch");
            KeyInput();
            Console.ReadKey();
            //Console.Clear();
            KeyInput();
            Console.WriteLine("end of code");
            Console.ReadKey();

            void Heal(int Health)
            {
                if (health <= 100)
                {
                    health = health + Health;
                }
                else
                    Console.WriteLine("You cannot have greater than 100 health");
            }
            void LivesCheck()
            {
                if (lives <= 0)
                {
                    health = 0;
                    shield = 0;
                    Console.WriteLine("You Lose");
                    Console.WriteLine("You Lose");
                    Console.WriteLine("You Lose");
                }
            }
            void LifeReset()
            {
                lives--;
                health = health + 100;
                shield = shield + 100;
            }
            void DealDamage(int damage)
            {
                enemyHealth -= damage * Damage;
                if (enemyHealth <= 0)
                {
                    score += 100;
                    level++;
                    Console.WriteLine("                                                             Next Level");
                }
            }
            void TakeDamage(int damage)
            {
                shield -= damage;
                if (shield <= 0)
                {
                    health -= damage;
                    shield = 0;
                    if (health < 0)
                    {
                        health = 0;
                        LifeReset();

                    }
                    LivesCheck();
                }
            }
            void ShowHud()
            {
                Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Shield " + shield + " Score Multiplier " + scoreMult);
                Console.WriteLine("LEVEL " + level);

            }

            void Combat()
            { 
               DealDamage(2);
               TakeDamage(5);
               ShowHud();
               Console.ReadKey();
            }


            // Various Methods
            void KeyInput()
            {
                Console.WriteLine("Press 'Q' to attack or 'E' to heal");
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.E:
                        {
                            Heal(40);
                            ShowHud();
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.Q:
                        {
                            if (enemyHealth >= 0)
                            {
                                Combat();
                            }
                            else 
                            {
                                return;
                            }
                            break;
                        }
                }
            }
        }
    }
}

            
    










                /*void Attack()
                {
                    Console.WriteLine("is this working");
                    Random rnd = new Random();


                    int playerAttack = rnd.Next(1, 20) + Damage + activeWeapon;
                    int enemyRemainingHealth = enemyHealth -= playerAttack;
                    int enemyAttack = rnd.Next(1, 10) + enemyDamage;
                    int remainingHealth = health -= enemyAttack;


                    Console.WriteLine("Player attacks for " + playerAttack);
                    Console.WriteLine("Enemy has: " + enemyHealth + " HP left");
                    Console.WriteLine("You have: " + remainingHealth + " HP left");
                    Console.WriteLine("Enemy has: " + enemyRemainingHealth + " HP left");

                    if (health <= 0)
                    {
                        lives = lives - 1;
                        _ = health + 100;
                    }
                    if (enemyRemainingHealth <= 0)
                    {
                        enemyRemainingHealth = 0;
                    }
                    
                    if (enemyHealth == 0)
                    {
                        
                        return;
                    }
                }
                */
        



       

        

        

       