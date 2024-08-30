using MathGame.Constants;
using MathGame.Enums;

namespace MathGame.Extensions
{
    public static class OperationsExtensions
    {
        public static int ComputeAnswer(
            this string operation, 
            int firstNumber, 
            int secondNumber)
        {
            if (string.IsNullOrWhiteSpace(operation))
            {
                throw new ArgumentNullException(nameof(operation));
            }

            switch (operation)
            {
                case Operations.Addition:
                    return firstNumber + secondNumber;
                case Operations.Subtraction:
                    return firstNumber - secondNumber;
                case Operations.Multiplication:
                    return firstNumber * secondNumber;
                case Operations.Division:
                    return firstNumber / secondNumber;
                default:
                    throw new Exception("Invalid operation");
            }
        }
    }
}
