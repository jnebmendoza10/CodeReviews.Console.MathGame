using System;
using MathGame.Constants;
using MathGame.Enums;
using MathGame.Extensions;

namespace MathGame
{
    public class GameManager
    {
        private const int NUMBER_OF_QUESTIONS = 5;

        private const int EASY_MIN_RANGE = 0;
        private const int EASY_MAX_RANGE = 9;

        private const int MEDIUM_MIN_RANGE = 10;
        private const int MEDIUM_MAX_RANGE = 99;

        private const int HARD_MIN_RANGE = 100;
        private const int HARD_MAX_RANGE = 999;

        public List<(string Question, int Answer)> GenerateMathQuestions(
            Mode gameMode,
            Difficulty gameDifficulty)
        {
            List<(string, int)> questionsAndAnswers = new List<(string, int)> ();

            for (int i = 0; i < NUMBER_OF_QUESTIONS; i++)
            {
                var numbers = generateNumbers(gameDifficulty, gameMode);
                string operation = generateOperation(gameMode);
                string question = ($"{numbers.FirstNumber} {operation} {numbers.SecondNumber} : ");
                
                questionsAndAnswers.Add(
                    (question,
                    operation.ComputeAnswer(numbers.FirstNumber, numbers.SecondNumber)));
            }

            return questionsAndAnswers;
        }

        private (int FirstNumber, int SecondNumber) generateNumbers(Difficulty gameDifficulty, Mode gameMode)
        {
            Random random = new Random();
            int firstNumber = 0;
            int secondNumber = 0;

            switch (gameDifficulty)
            {
                case Difficulty.Easy:

                    if (gameMode == Mode.Division)
                    {
                        return generateNumbersForDivision(
                            ref firstNumber,
                            ref secondNumber,
                            EASY_MIN_RANGE,
                            EASY_MAX_RANGE);
                    }
                    firstNumber = random.Next(EASY_MIN_RANGE, EASY_MAX_RANGE);
                    secondNumber = random.Next(EASY_MIN_RANGE, EASY_MAX_RANGE);

                    return (firstNumber, secondNumber);

                case Difficulty.Medium:

                    if (gameMode == Mode.Division)
                    {
                        return generateNumbersForDivision(
                            ref firstNumber,
                            ref secondNumber,
                            MEDIUM_MIN_RANGE,
                            MEDIUM_MAX_RANGE);
                    }

                    firstNumber = random.Next(MEDIUM_MIN_RANGE, MEDIUM_MAX_RANGE);
                    secondNumber = random.Next(MEDIUM_MIN_RANGE, MEDIUM_MAX_RANGE);

                    return (firstNumber, secondNumber);

                case Difficulty.Hard:
                    if (gameMode == Mode.Division)
                    {
                        return generateNumbersForDivision(
                            ref firstNumber,
                            ref secondNumber,
                            HARD_MIN_RANGE,
                            HARD_MAX_RANGE);
                    }

                    firstNumber = random.Next(HARD_MIN_RANGE, HARD_MAX_RANGE);
                    secondNumber = random.Next(HARD_MIN_RANGE, HARD_MAX_RANGE);

                    return (firstNumber, secondNumber);
                default:
                    throw new Exception("Invalid difficulty");
            }
        }

        private (int FirstNumber, int SecondNumber) generateNumbersForDivision(
            ref int firstNumber, 
            ref int secondNumber,
            int minRange,
            int maxRange)
        {
            Random random = new Random();

            do
            {
                //add one to avoid dividing by zero
                firstNumber = random.Next(minRange + 1, maxRange);
                secondNumber = random.Next(minRange + 1, maxRange);

            } while ((firstNumber % secondNumber != 0));

            return (firstNumber, secondNumber);
        }

        private string generateOperation(Mode mode)
        {
            var modeToOperator = new Dictionary<Mode, string>()
            {
                { Mode.Addition, Operations.Addition },
                { Mode.Subtraction, Operations.Subtraction },
                { Mode.Multiplication, Operations.Multiplication },
                { Mode.Division, Operations.Division }
            };

            if (mode == Mode.Random)
            {
                Random random = new Random();
                int i = random.Next(0, modeToOperator.Count - 1);

                return modeToOperator.ElementAt(i).Value;
            }
            else
            {
                if (modeToOperator.TryGetValue(mode, out string? operationName))
                {
                    return operationName;
                }
                else
                {
                    throw new ArgumentException("Operation not found.", nameof(operationName));
                }
            }
        }
    }
}
