using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class StageInitializer : MonoBehaviour
{
    [SerializeField] private float stageTimeLimit = 60f;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            // 튜토리얼 씬인지 감지
            bool isTutorialScene = FindObjectOfType<TutorialPopup>() != null;

            GameManager.Instance.InitStageTimer(stageTimeLimit, isTutorialScene);

            // TimerUI 초기화
            TimerUI timerUI = FindObjectOfType<TimerUI>();
            if (timerUI != null)
                timerUI.Init();
        }
    }
}
