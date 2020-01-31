using System;

namespace NumberGuesser
{
    class Chamadas
    {
        public static void GetAppName()
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Vinicius Moralis";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{appName}: Version {appVersion} Created by {appAuthor}");
            Console.ResetColor();
        }

        public static void PrintColorAndMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class Program //classe principal
    {
        static void Main(string[] args) //método de entrada
        {
            Chamadas.GetAppName();

            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();

            Console.WriteLine($"Hello {userName}, let's play a game!");

            while (true)
            {
                Random random = new Random();
                int correctNumber = random.Next(1, 10);

                Console.WriteLine("Guess a number between 1 and 10");
                int guess = 0;

                while (guess != correctNumber)
                {
                    string number = Console.ReadLine();
                    if (!int.TryParse(number, out guess))
                    {
                        Chamadas.PrintColorAndMessage(ConsoleColor.Red, "Please enter a number");
                        continue;
                    }

                    guess = Int32.Parse(number);
                    if (guess != correctNumber)
                    {
                        Chamadas.PrintColorAndMessage(ConsoleColor.Red, "Wrong Number, try again!");
                    }
                }

                Chamadas.PrintColorAndMessage(ConsoleColor.Yellow, "You are correct!!!");

                Chamadas.PrintColorAndMessage(ConsoleColor.Green, "Play again? Y/N");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
