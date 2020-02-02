using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace NumberGuesser
{
    //public partial class Program : Form
    public class Program
    {

        //public Program()
        //{
        //InitializeComponent();
        //}

        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Program());

            Chamadas.GetAppName();

            int score = 0;

            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();

            Console.WriteLine($"Hello {userName}, let's play a game!");

            while (true)
            {
                Random random = new Random();
                int correctNumber = random.Next(1, 10);

                Console.WriteLine("You have 3 tries to guess a number between 1 and 10");
                int guess = 0;
                int chances = 3;

                while (guess != correctNumber && chances > 0)
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
                        chances = chances - 1;
                    }
                    if (chances == 0)
                    {
                        Chamadas.PrintColorAndMessage(ConsoleColor.Red, "You are of chances!!!");
                    }
                }

                if(guess == correctNumber)
                {
                    Chamadas.PrintColorAndMessage(ConsoleColor.Yellow, "You are correct!!!");
                    if(chances == 3)
                    {
                        score = score + 20;
                        Console.WriteLine($"Your new score is {score}");
                    }
                    if (chances == 2)
                    {
                        score = score + 10;
                        Console.WriteLine($"Your new score is {score}");
                    }
                    if(chances == 1)
                    {
                        score = score + 5;
                        Console.WriteLine($"Your new score is {score}");
                    }
                }

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

        public class Chamadas
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
    }
}
