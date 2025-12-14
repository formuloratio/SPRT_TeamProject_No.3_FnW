using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using Utils;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private void OnEnable()
    {
        // 씬 전환 직후 또는 TimerUI가 활성화될 때 즉시 갱신
        UpdateTimer();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameState.Playing)
        {
            UpdateTimer();
        }
    }

    // 타이머 갱신 함수
    public void UpdateTimer()
    {
        if (GameManager.Instance != null)
        {
            timerText.text = GameManager.Instance.CurrentTime.ToString("F2");
        }
    }

    // Retry나 씬 시작 직후 호출 가능
    public void Init()
    {
        if (GameManager.Instance != null)
            timerText.text = GameManager.Instance.CurrentTime.ToString("F2");
    }
}
