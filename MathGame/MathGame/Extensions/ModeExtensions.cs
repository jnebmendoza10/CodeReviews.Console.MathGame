using MathGame.Enums;

namespace MathGame.Extensions
{
    public static class ModeExtensions
    {
        public static Mode ParseModeChoice(this string modeChoice)
        {
            if (string.IsNullOrWhiteSpace(modeChoice))
            {
                throw new ArgumentNullException(nameof(modeChoice));
            }

            switch (modeChoice)
            {
                case "1":
                    return Mode.Addition;
                case "2":
                    return Mode.Subtraction;
                case "3":
                    return Mode.Multiplication;
                case "4":
                    return Mode.Division;
                case "5":
                    return Mode.Random;
                default:
                    throw new Exception("Invalid choice.");
            }
        }

        public static string ParseModeChoiceToString(this Mode modeChoice)
        {
            switch (modeChoice)
            {
                case Mode.Addition:
                    return "Addition";
                case Mode.Subtraction:
                    return "Substraction";
                case Mode.Multiplication:
                    return "Multiplication";
                case Mode.Division:
                    return "Division";
                case Mode.Random:
                    return "Random";
                default:
                    throw new Exception("Invalid argument");
            }
        }
    }
}
