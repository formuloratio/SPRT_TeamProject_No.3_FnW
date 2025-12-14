using UnityEngine;

namespace Utils
{
        public enum ElementType
        {
            Fire,Water

        }

        public enum GameState
        {
            Title, Playing, Paused, GameOver, GameClear
        }

        public enum AchievementType
        {
            StageClear, DeathCount, GetRank
        }

        public enum AchievementClearType
        {
            Equals, Under, Over
        }

        public enum ProgressType
        {
            Add, Set
        }
}
