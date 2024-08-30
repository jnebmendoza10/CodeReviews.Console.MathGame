using MathGame.Enums;

namespace MathGame.Extensions
{
    public static class MenuExtensions
    {
        public static Menu ParseMenuChoice(this string menuChoice)
        {
            if (string.IsNullOrWhiteSpace(menuChoice))
            {
                throw new ArgumentNullException(nameof(menuChoice));
            }

            switch (menuChoice)
            {
                case "1":
                    return Menu.Play;
                case "2":
                    return Menu.History;
                case "3":
                    return Menu.Quit;
                default:
                    throw new Exception("Invalid choice.");
            }
        }
    }
}
