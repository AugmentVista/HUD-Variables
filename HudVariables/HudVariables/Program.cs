using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudVariables
{
    internal class Program
    {
        class Questions
        {
            /* Int declarations */
            public int score; public int health; public int damage; public int enenmyHealth; public static int selectedDifficulty;
            /* String declarations */
            public string question; public string correctAnswer; public string userAnswer; public string studioName; public string finalAnswer;
            public string playerName;
            /* Float declarations */
            float scoreMult; float lives;


            /* Requests a difficulty answer from the user and only accepts easy, medium or hard
               if it doesn't get one of these it resets */
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
            public bool VerifyAnswer(string aUserAnswer)
            {
                return aUserAnswer == correctAnswer;
            }

            static void Main(string[] args)
            {
                /* Int initializations */
                int score = 0; int health = 0; int damage = 0; int enenmyHealth = 0;
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
                }
                else if (answer == "medium")
                {
                    scoreMult = 1.5f;
                    lives = 4;
                }
                else if (answer == "hard")
                {
                    scoreMult = 2.0f;
                    lives = 3;
                }
                ShowHud();
                Console.ReadKey();







                void ShowHud()
                {
                    Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Score Multiplier " + scoreMult);
                   

                }
            }
            // score = score + enemyValue ||  score+= enemyValue;


        }



    }
}
       

        

        

       