using System.Collections.Generic;
using System.Linq;
using Data.ScriptableObjects;
using Features.Entities;
using UnityEngine;
using Utils;

namespace Core
{
    public class AchievementManager  : MonoBehaviour
    {
        public static AchievementManager  Instance { get; private set; }
        private DataService _dataService;
        private const string DataFilePrefix = "Achievement";
        private const string DataFileSuffix = "Data";
        private const string ResourcesPath = "ScriptableObjects/Achievements";
        private Dictionary<string, Achievement> _achievements = new Dictionary<string, Achievement>();


        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _dataService = new DataService(DataFilePrefix);
            InitializeAchievements();
            LoadProgress();
        }

        #region public methods




        public void CheckAndSetProgress(ProgressType type, AchievementType achievementType, int amount = 1)
        {
            List<Achievement> achievements = new List<Achievement>();
            foreach (var achievement in _achievements.Values)
            {
                if (achievement.AchievementData.progressType == type && achievement.AchievementData.achievementType == achievementType)
                {
                    achievements.Add(achievement);
                }
            }
            if (type == ProgressType.Add)
            {
                this.AddProgress(achievements, amount);
            }else if (type == ProgressType.Set)
            {
                this.SetProgress(achievements, amount);
            }
        }

        /// <summary>
        /// ID로 특정 업적 정보를 조회합니다.
        /// </summary>
        /// <param name="id">조회할 업적 ID</param>
        /// <returns>해당 업적 객체. 존재하지 않으면 null</returns>
        public Achievement GetAchievement(string id)
        {
            return _achievements.ContainsKey(id) ? _achievements[id] : null;
        }

        /// <summary>
        /// 등록된 모든 업적 목록을 반환합니다.
        /// </summary>
        /// <returns>전체 업적 리스트</returns>
        public List<Achievement> GetAllAchievements()
        {
            return _achievements.Values.ToList();
        }

        #endregion

        private void AddProgress(List<Achievement> achievements, int amount)
        {
            foreach (var achievement in achievements)
            {
                achievement.CurrentCount += amount;
            }
            SaveProgress();
        }

        private void SetProgress(List<Achievement> achievements, int value)
        {
            foreach (var achievement in achievements)
            {
                achievement.SetProgress(value);
            }
            SaveProgress();
        }

        private void InitializeAchievements()
        {
            AchievementData[] loadedData = Resources.LoadAll<AchievementData>(ResourcesPath);
            foreach (var data in loadedData)
            {
                if (string.IsNullOrEmpty(data.id))
                {
                    continue;
                }

                if (_achievements.ContainsKey(data.id))
                {
                    continue;
                }
                var achievement = new Achievement(data);
                _achievements[data.id] = achievement;

            }
        }

        private void SaveProgress()
        {
            var saveData = new AchievementSaveData
            {
                progressList = new List<AchievementProgress>()
            };

            foreach (var achievement in _achievements.Values)
            {
                saveData.progressList.Add(new AchievementProgress
                {
                    id = achievement.AchievementData.id,
                    currentCount = achievement.CurrentCount,
                    isUnlocked = achievement.IsUnlocked
                });
            }

            _dataService.Save(saveData, DataFileSuffix);
        }
        private void LoadProgress()
        {
            var saveData = _dataService.Load<AchievementSaveData>(DataFileSuffix);

            if (saveData?.progressList == null || saveData.progressList.Count == 0)
            {
                return;
            }

            foreach (var progress in saveData.progressList)
            {
                if (_achievements.ContainsKey(progress.id))
                {
                    _achievements[progress.id].SetProgress(progress.currentCount);

                    if (progress.isUnlocked && !_achievements[progress.id].IsUnlocked)
                    {
                        _achievements[progress.id].SetProgress(_achievements[progress.id].AchievementData.targetCount);
                    }
                }
            }
        }




        [System.Serializable]
        private class AchievementSaveData
        {
            public List<AchievementProgress> progressList;
        }

        [System.Serializable]
        private class AchievementProgress
        {
            public string id;
            public int currentCount;
            public bool isUnlocked;
        }
    }
}
