using MathGame.Enums;

namespace MathGame.Entities
{
    public class Game
    {
        public Difficulty Difficulty { get; set; }

        public Mode Mode { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}
