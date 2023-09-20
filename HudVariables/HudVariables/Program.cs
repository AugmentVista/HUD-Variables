using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    internal class Program
    {
        class Questions
        {
            /* Int declarations */
            public int score; public int health; public int playerDamage; public int enenmyHealth; 
            public static int selectedDifficulty; public static int enemyDamage; public static int level = 1;
            public static int activeWeapon; public static int Stick = 2; 
            /* String declarations */
            public string question; public string correctAnswer; public string userAnswer; public string studioName; 
            public string finalAnswer; public string playerName;
            /* Float declarations */
           static float scoreMult; static float lives;
            /* Bool declarations */
            public static ConsoleKeyInfo input;
            private static Random randomResult;

            public Questions(string aQuestion, string aCorrectAnswer)
            {
                question = aQuestion;
                correctAnswer = aCorrectAnswer;
            }

            // Checks if the answer is either easy medium or hard
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
                int score = 0; int health = 0; int playerDamage = 0; int enenmyHealth = 0;
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
                // string hard after difficulty string is needed to provide an arguement that corresponds to aCorrectAnswer
                Questions firstQuestion = new Questions("Please select your difficulty", "hard");
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
                Console.Clear();
                ShowHud();
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("                                                         LEVEL 1");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("You begin your journey with a sturdy stick and a smile on your face.");
                Console.WriteLine();
                int activeWeapon = Stick;
                Console.WriteLine("before you stands your first enemy, a goblin that stole your lunch");
                Console.WriteLine("Press 'E' to Attack");
                KeyInput();
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
                            Attack();

                            }
                            break;

                        case ConsoleKey.Q:
                            //Talk();

                            break;


                    }
                }
                void Attack()
                {
                    Console.WriteLine("is this working");
                    Random rnd = new Random();

                    
                    int playerAttack = rnd.Next(1, 20) + playerDamage + activeWeapon;
                    Console.WriteLine(playerAttack);

                    int enemyAttack = rnd.Next(1, 10) + enemyDamage;
                 
                    



                }
                    void ShowHud()
                {
                    Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Score Multiplier " + scoreMult);
                    Console.WriteLine(                                                        "LEVEL " + level );

                }
            }
            // score = score + enemyValue ||  score+= enemyValue;


        }



    }
}
       

        

        

       