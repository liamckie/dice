using System;
using System.Collections.Generic;
using System.Text;

namespace dice
{
    public class DiceGame
    {
        private int Score;
        private Random random;
        private string UnkownRollGraphic = @"    +---------+
    | ?  ?  ? |
    | ?  ?  ? |
    | ?  ?  ? |
    +---------+";
        private string OneRollGraphic = @"    +---------+
    |         |
    |    o    |
    |         |
    +---------+";
        private string TwoRollGraphic = @"    +---------+
    | o       |
    |         |
    |       o |
    +---------+";
        private string ThreeRollGraphic = @"    +---------+
    | o       |
    |    o    |
    |       o |
    +---------+";
        private string FourRollGraphic = @"    +---------+
    | o     o |
    |         |
    | o     o |
    +---------+";
        private string FiveRollGraphic = @"    +---------+
    | o     o |
    |    o    |
    | o     o |
    +---------+";
        private string SixRollGraphic = @"  +---------+
    | o     o |
    | o     o |
    | o     o |
    +---------+";

        public DiceGame()
        {
            Score = 0;
            random = new Random();
        }

        public void Start()
        {
            Console.Title = "Dice Rolling Game";
            Console.WriteLine(Console.Title);
            Console.WriteLine("\nLet's play a game of chance with dice." +
                              "\nInstructions : " +
                              "\n\t=> I will roll a dice each round." +
                              "\n\t=> You will guess if it is high or low." +
                              "\n\t=> If you get it right, I'll give you a point.");
            Console.Write("\nReady to play? (yes/no) : ");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "yes" || answer == "y")
            {
                Console.WriteLine("OK, starting the game now!");
                PlayRound();
            }
            else if (answer == "no" || answer == "n")
            {
                Console.WriteLine("OK, thank you for playing!");
            }
            else
            {
                Console.WriteLine("Incorrect response, please try again!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private void PlayRound()
        {
            Console.Clear();
            Console.WriteLine("I'm about to roll..." + $"\n{UnkownRollGraphic}");
            Console.Write("Is it going to be low (1, 2, 3) or high (4, 5, 6)? : ");
            string answer = Console.ReadLine().Trim().ToLower();

            int roll = random.Next(1, 7);
            Console.WriteLine($"The roll was {roll}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (roll)
            {
                case 1:
                    Console.WriteLine(OneRollGraphic);
                    break;
                case 2:
                    Console.WriteLine(TwoRollGraphic);
                    break;
                case 3:
                    Console.WriteLine(ThreeRollGraphic);
                    break;
                case 4:
                    Console.WriteLine(FourRollGraphic);
                    break;
                case 5:
                    Console.WriteLine(FiveRollGraphic);
                    break;
                case 6:
                    Console.WriteLine(SixRollGraphic);
                    break;
                default:
                    Console.WriteLine("Incorrect Roll!");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;

            if (answer == "high")
            {
                Console.WriteLine("You guessed high!");
                if (roll <= 3)
                {
                    Lose();
                }
                else
                {
                    Win();
                }
            }
            else if (answer == "low")
            {
                Console.WriteLine("You guessed low!");
                if (roll <= 3)
                {
                    Win();
                }
                else
                {
                    Lose();
                }
            }
            else
            {
                Console.WriteLine($"You guessed {answer}. That is incorrect, please type either 'high' or 'low'!");
            }

            AskToPlayAgain();
        }

        private void Win()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Win! :)");
            Score++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score : {Score}");

        }

        private void Lose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Lost! :(");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score : {Score}");
        }

        private void AskToPlayAgain()
        {
            Console.Write("\nWould you like to play again? (yes/no) : ");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "yes" || answer == "y")
            {
                PlayRound();
            }
            else
            {
                Console.WriteLine("OK, thank you for playing!");
            }
        }
    }
}
