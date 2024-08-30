using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame.Enums;

namespace MathGame.Extensions
{
    public static class DifficultyExtensions
    {
        public static Difficulty ParseDifficultyChoice(this string difficultyChoice)
        {
            if (string.IsNullOrWhiteSpace(difficultyChoice))
            {
                throw new ArgumentNullException(nameof(difficultyChoice));
            }

            switch (difficultyChoice)
            {
                case "1":
                    return Difficulty.Easy;
                case "2":
                    return Difficulty.Medium;
                case "3":
                    return Difficulty.Hard;
                default:
                    throw new Exception("Invalid choice.");
            }
        }

        public static string ParseDifficultyToString(this Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return "Easy";
                case Difficulty.Medium:
                    return "Medium";
                case Difficulty.Hard:
                    return "Hard";
                default:
                    throw new Exception("Invalid argument");
            }
        }
    }
}
