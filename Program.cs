using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsLab
{
    enum Roshambo
    {
        Rock = 1,
        Paper,
        Scissors
    }

    //Stores name an Roshambo value
    abstract class Player
    {
        public Roshambo Weapon { get; set; }
        public Roshambo _Weapon { get; set; }
        public string Name { get; set; }

        public static Random rand = new Random();

        public virtual Roshambo GenerateRoshambo()
        {
            int Weapon = rand.Next(1, 3);
            Roshambo RPS = (Roshambo)Weapon;
            _Weapon = RPS;
            return RPS;
        }
    }

    class User : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Console.WriteLine($"Rock, Paper, or Scissors? (R/P/S or a number 1-3)");
            string userInput = Console.ReadLine();

            if (userInput == "R" || userInput == "r" || userInput == "1")
            {
                Weapon = Roshambo.Rock;
                return Roshambo.Rock;
            }
            else if (userInput == "P" || userInput == "p" || userInput == "2")
            {
                Weapon = Roshambo.Paper;
                return Roshambo.Paper;
            }
            else if (userInput == "S" || userInput == "s" || userInput == "3")
            {
                Weapon = Roshambo.Scissors;
                return Roshambo.Scissors;
            }
            else
                Console.WriteLine("Invalid input. Please enter R/P/S or a number 1-3.");
            return GenerateRoshambo();
        }
    }

    class RockPlayer : Player
    {
        //Set constructor
        public RockPlayer()
        {
            Name = "TheJets";
        }
        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.Rock;
        }
    }

    class RandomPlayer : Player
    {
        //Set Constructor
        public RandomPlayer()
        {
            Name = "TheSharks";
        }
        public override Roshambo GenerateRoshambo()
        {
            int Weapon = rand.Next(1, 3);
            Roshambo RPS = (Roshambo)Weapon;
            _Weapon = RPS;
            return RPS;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            bool Continue = true;
            string opponent = null;
            string playAgain;

            Player user = new User();
            Player Opponent = new RandomPlayer();

            Console.WriteLine("Welcome to Rock Paper Scissors!");
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            {
                Console.WriteLine($"Welcome {userName}! Would you like to play against TheJets or TheSharks? (j/s)");
                opponent = Console.ReadLine().ToLower();

                if (opponent == "j")
                {
                    Opponent = new RockPlayer();
                }
                else if (opponent == "s")
                {
                    Opponent = new RandomPlayer();
                }
                else
                {
                    Console.WriteLine($"{opponent} is not valid. Please enter j or s.");
                }
            }

            while (!done)
            {
                user.GenerateRoshambo();
                Opponent.GenerateRoshambo();

                Console.WriteLine($"{userName}: {user.Weapon}");
                Console.WriteLine($"{Opponent.Name}: {Opponent._Weapon}");

                if (user.Weapon == Roshambo.Rock && Opponent._Weapon == Roshambo.Rock)
                {
                    Console.WriteLine("Draw!");
                }
                if (user.Weapon == Roshambo.Rock && Opponent._Weapon == Roshambo.Paper)
                {
                    Console.WriteLine($"{Opponent.Name} wins!");
                }
                if (user.Weapon == Roshambo.Rock && Opponent._Weapon == Roshambo.Scissors)
                {
                    Console.WriteLine($"{userName} wins!");
                }
                if (user.Weapon == Roshambo.Paper && Opponent._Weapon == Roshambo.Paper)
                {
                    Console.WriteLine("Draw!");
                }
                if (user.Weapon == Roshambo.Paper && Opponent._Weapon == Roshambo.Rock)
                {
                    Console.WriteLine($"{userName} wins!");
                }
                if (user.Weapon == Roshambo.Paper && Opponent._Weapon == Roshambo.Scissors)
                {
                    Console.WriteLine($"{Opponent.Name} wins!");
                }
                if (user.Weapon == Roshambo.Scissors && Opponent._Weapon == Roshambo.Scissors)
                {
                    Console.WriteLine("Draw!");
                }
                if (user.Weapon == Roshambo.Scissors && Opponent._Weapon == Roshambo.Rock)
                {
                    Console.WriteLine($"{Opponent.Name} wins!");
                }
                if (user.Weapon == Roshambo.Scissors && Opponent._Weapon == Roshambo.Paper)
                {
                    Console.WriteLine($"{userName} wins");
                }

            }
            while (Continue)
            {
                Console.WriteLine("Play again? (y/n)");
                playAgain = Console.ReadLine();

                if (playAgain == "n" || playAgain == "N")
                {
                    Continue = false;
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
                else if (playAgain == "y" || playAgain == "Y")
                {
                    Continue = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter y/n.");
                }
            }
        }
    }
}
