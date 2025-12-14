using System.Collections.Generic;
using Core;
using Features.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementScene : MonoBehaviour
{

    [SerializeField] private Transform achievementPanelTransform;

    private AchievementManager _achievementManager;
    private SceneTransitionManager _sceneTransitionManager;

    private List<Achievement> _achievements;
    private List<GameObject> _achievementSlot;
    private string _titleSceneName= "TitleScene";

    void Awake()
    {
        if (AchievementManager.Instance == null)
        {
            return;
        }
        if (SceneTransitionManager.Instance == null)
        {
            return;
        }
        _achievementManager = AchievementManager.Instance;
        _sceneTransitionManager = SceneTransitionManager.Instance;

        _achievements = _achievementManager.GetAllAchievements();
        _achievementSlot = new List<GameObject>();

    }

    void Start()
    {
        DrawAchievementSlot();
    }

    void DrawAchievementSlot()
    {
        foreach (Transform childSlot in achievementPanelTransform)
        {
            if (childSlot.CompareTag("AchievementSlot"))
            {
                _achievementSlot.Add(childSlot.gameObject);
            }
        }

        int loopCount = Mathf.Min(_achievements.Count, _achievementSlot.Count);

        for (int i = 0; i < loopCount; i++)
        {
            GameObject slotObject = _achievementSlot[i];
            Achievement achievement = _achievements[i];
            TextMeshProUGUI titleText = slotObject.transform.Find("AchieveTitle").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI descriptionText = slotObject.transform.Find("AchieveDescription").GetComponent<TextMeshProUGUI>();
        
            Image slotBackground = slotObject.GetComponent<Image>();

            string achievementName = achievement.AchievementData.displayName;
            string achievementDescription = achievement.AchievementData.description;
            bool achievementUnlocked = achievement.IsUnlocked;
        
            titleText.text = achievementName;
            descriptionText.text = achievementDescription;
            if (achievementUnlocked)
            {
                slotBackground.color = Color.green;
            }

        }
        for (int i = loopCount; i < _achievementSlot.Count; i++)
        {
            _achievementSlot[i].SetActive(false);
        }
    }

    public void OnClickedBackToTitleButton()
    {
        _sceneTransitionManager.LoadScene(_titleSceneName);
    }

}
