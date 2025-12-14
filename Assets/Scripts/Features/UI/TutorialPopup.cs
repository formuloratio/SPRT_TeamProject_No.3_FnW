using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core; // GameManager 네임스페이스 필요(시간조절)

public class TutorialPopup : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    private int currentIndex = 0;
    //씬이 다시 로드돼도 유지되는 변수
    private static bool hasShown = false;

    private void Awake()
    {
        //게임로드 즉시 정지
        Time.timeScale = 0f;

        //GameManager있을 때 상태 잠시 Pause로
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PauseGame();
        }
    }

    private void Start()
    {
        //이미 튜토리얼 본 적이 있다면 바로 종료
        if (hasShown)
        {
            //게임이 멈추지 않도록 보정
            if (GameManager.Instance != null)
                GameManager.Instance.ResumeGame();
            else
                Time.timeScale = 1f;

            gameObject.SetActive(false);
            return;
        }

        //튜토리얼 처음 실행
        hasShown = true;

        //처음에는 키세팅패널만
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == 0);
        }

    }

    public void NextPanel()
    {
        //현재 패널 끄기
        panels[currentIndex].SetActive(false);

        //다음 패널로 이동
        currentIndex++;
        if (currentIndex < panels.Length)
        {
            panels[currentIndex].SetActive(true);
        }
        else
        {
            EndTutorial();
        }
    }

    public void PreviousPanel()
    {
        //현재 패널 끄기
        panels[currentIndex].SetActive(false);

        //이전 인덱스로 이동
        currentIndex = Mathf.Max(0, currentIndex - 1);
        panels[currentIndex].SetActive(true);
    }

    public void EndTutorial()
    {
        //모든 패널 비활성화
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        Debug.Log("튜토리얼 종료");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResumeGame();
            Debug.Log("게임 재개 호출");
        }
        else
        {
            //튜토리얼 스킵시 게임 재개
            Time.timeScale = 1f;
        }
            //게임 재개
            gameObject.SetActive(false);
    }
}
