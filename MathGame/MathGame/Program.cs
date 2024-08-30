using System.Diagnostics;
using MathGame.Entities;
using MathGame.Extensions;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            displayMenuHeader();

            List<Game> history = new List<Game>();

            while (true)
            {
                try
                {
                    displayUserChoices();
                    var menuChoice = Console.ReadLine().ParseMenuChoice();

                    if (menuChoice == Enums.Menu.Play)
                    {
                        displayDifficulty();
                        var difficultyChoice = Console.ReadLine().ParseDifficultyChoice();

                        displayOperations();
                        var operationChoice = Console.ReadLine().ParseModeChoice();

                        GameManager manager = new GameManager();

                        Game game = new Game();
                        game.Difficulty = difficultyChoice;
                        game.Mode = operationChoice;
                        game.DatePlayed = DateTime.Now;

                        history.Add(game);

                        var questions = manager.GenerateMathQuestions(
                            operationChoice,
                            difficultyChoice);

                        int correctAnswers = 0;
                        int wrongAnswers = 0;

                        Stopwatch stopwatch = new Stopwatch();

                        stopwatch.Start();

                        foreach (var question in questions)
                        {
                            Console.Write(question.Question);
                            int.TryParse(Console.ReadLine(), out int userAnswer);

                            if (question.Answer.Equals(userAnswer))
                            {
                                correctAnswers++;
                            }
                            else
                            {
                                wrongAnswers++;
                            }
                        }
                        
                        stopwatch.Stop();

                        var timeElapsed = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);

                        Console.WriteLine($"You have {correctAnswers} correct answers and {wrongAnswers} wrong answers");
                        Console.WriteLine($"You have finished the game in { timeElapsed } seconds");
                    }
                    else if (menuChoice == Enums.Menu.History)
                    {
                        displayGameHistory(history);
                    }
                    else if ( menuChoice == Enums.Menu.Quit)
                    {
                        displayMenuFooter();
                        return;
                    }

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void displayMenuHeader()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Welcome to the Math Game");
            Console.WriteLine("****************************");
        }

        private static void displayUserChoices()
        {
            Console.WriteLine("1. Play Now");
            Console.WriteLine("2. View Game History");
            Console.WriteLine("3. Exit");
            Console.Write("Enter a number to select your choice: ");
        }


        private static void displayDifficulty()
        {
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Enter a number to select difficulty: ");
        }

        private static void displayOperations()
        {
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
            Console.Write("Enter a number to select an operation: ");
        }

        private static void displayGameHistory(List<Game> userHistory)
        {
            if (userHistory == null || userHistory.Count == 0) 
            {
                Console.WriteLine("There are no previous records.");

                return;
            }

            foreach (var item in userHistory)
            {
                Console.WriteLine($"{ item.DatePlayed }: You have played { item.Mode.ParseModeChoiceToString() } with difficulty of {item.Difficulty.ParseDifficultyToString()}");
            }
        }

        private static void displayMenuFooter()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("****************************");
        }
    }
}
