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
            int score = 0; int health = 0; int playerDamage = 0; int enemyHealth = level * 3;
            /* String initializations*/
            string studioName = "NameWasTakenStudios"; string playerName;
            /* Float initializations */
            float scoreMult = 1.00f; float lives = 1.00f;


            // Opening phrases to player

            Console.WriteLine("Brought to you by " + studioName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome player please enter your name");
            playerName = Console.ReadLine();
            Console.ReadLine();
            Console.WriteLine("Hello " + playerName);
            Console.ReadKey();
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
                playerDamage = 5;
            }
            else if (answer == "medium")
            {
                scoreMult = 1.5f;
                lives = 4;
                playerDamage = 7;
            }
            else if (answer == "hard")
            {
                scoreMult = 2.0f;
                lives = 3;
                playerDamage = 9;
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
        public int score; public int health; public int playerDamage;
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
                int score = 0; int health = 0; int playerDamage = 0; int enemyHealth = level * 3;
                /* String initializations*/
                string studioName = "NameWasTakenStudios"; string playerName;
                /* Float initializations */
                float scoreMult = 1.00f; float lives = 1.00f;


                Console.WriteLine("You begin your journey with a sturdy stick");
                Console.WriteLine();
                int activeWeapon = Stick;
                Console.WriteLine("before you stands your first enemy, a goblin that stole your lunch");
                Console.WriteLine("Press 'E' to Attack or press 'Q' to give them mercy");
                KeyInput();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("end of code");
                Console.ReadKey();



                // Various Methods
                void KeyInput()
                {
                    input = Console.ReadKey(true);


                    switch (input.Key)
                    {

                        case ConsoleKey.E:
                        {
                                Console.WriteLine("check check");
                               // Combat(); this gets this error || An object reference is required for the nonstatic field, method, or property || Solve this later

                        }
                            break;

                        case ConsoleKey.Q:
                        {
                            Mercy();

                            break;

                        }


                    }
                }

            void Mercy() 
            {
                Console.WriteLine("You have mercy on your enemy allowing them to escape");
            }



                /*void Talk()
                {
                    Random rnd = new Random();
                    int randomDialogue = rnd.Next(1, 20);
                    Console.WriteLine("You make a deal and recive ");

                   
                    if (1 <= randomDialogue && randomDialogue <= 5)
                    {
                    Console.WriteLine("range of 1 - 7");
                    }
                        
                    if (6 <= randomDialogue && randomDialogue <= 10)
                    {
                    Console.WriteLine("range of 8 - 15");
                    }
       
                    if (11 <= randomDialogue && randomDialogue <= 20)
                    {
                    Console.WriteLine("range of 16 - 20");
                    }

                }*/       

             }




                void ShowHud()
                {
                    Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Score Multiplier " + scoreMult);
                    Console.WriteLine("LEVEL " + level);

                }

                public bool Combat()
                {
                    if (enemyHealth <= 0)
                    {
                        ShowHud();
                        return true;
                    }
                    if (health >= 0)
                    {
                        Attack();
                        return false;  
                    }
                    Console.WriteLine("You've beaten the Enemy");
                    return true;
                }
                void Attack()
                {
                    Console.WriteLine("is this working");
                    Random rnd = new Random();


                    int playerAttack = rnd.Next(1, 20) + playerDamage + activeWeapon;
                    int enemyRemainingHealth = enemyHealth -= playerAttack;
                    int enemyAttack = rnd.Next(1, 10) + enemyDamage;
                    int remainingHealth = health -= enemyAttack;


                    Console.WriteLine("Player attacks for " + playerAttack);
                    Console.WriteLine("Enemy has: " + enemyHealth + " HP left");
                    Console.WriteLine("You have: " + remainingHealth + " HP left");
                    Console.WriteLine("Enemy has: " + enemyRemainingHealth + " HP left");

                    if (health <= 0)
                    {
                        _ = health + 100;
                        lives = lives - 1;
                    }
                    if (enemyRemainingHealth <= 0)
                    {
                        enemyRemainingHealth = 0;
                    }
                    if (lives <= 0)
                    {
                        Console.WriteLine("You Lose");
                    }
                    if (enemyHealth == 0)
                    {
                        score += 100;
                        level++;
                        Console.WriteLine("                                                             Next Level");
                        return;
                    }
                }
                
        


                // score = score + enemyValue ||  score+= enemyValue; && == and


        } 
}


       

        

        

       