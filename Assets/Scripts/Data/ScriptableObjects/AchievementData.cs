using UnityEngine;
using Utils;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjects/Achievement")]
    public class AchievementData : ScriptableObject
    {
        public string id;
        public string displayName;
        public string description;
        // public Sprite icon;
        public int targetCount;
        public AchievementClearType clearType;
        public AchievementType achievementType;
        public ProgressType progressType;

    }
}