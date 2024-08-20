namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void displayMenuHeader()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Welcome to the Math Game");
            Console.WriteLine("****************************");
        }

        static void displayUserChoices()
        {
            Console.WriteLine("Enter a number to select your choice:");
            Console.WriteLine("1. Play Now");
            Console.WriteLine("2. View Game History");
            Console.WriteLine("3. Exit");
        }


        static void displayDifficulty()
        {
            Console.WriteLine("Enter a number to select difficulty:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
        }

        static void displayOperations()
        {
            Console.WriteLine("Enter a number to select an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
        }

        static void displayGameHistory(List<string> userHistory)
        {
            if (userHistory == null || userHistory.Count == 0) 
            {
                Console.WriteLine("There are no previous records.");

                return;
            }

            foreach (string item in userHistory)
            {
                Console.WriteLine(item);
            }
        }

        static void displayMenuFooter()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("****************************");
        }
    }
}
