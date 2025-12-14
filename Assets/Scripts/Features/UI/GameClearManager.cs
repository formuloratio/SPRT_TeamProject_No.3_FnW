using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Core;
using TMPro;

public class GameClearManager : MonoBehaviour
{
    public static GameClearManager Instance { get; private set; }

    [SerializeField] private GameObject clearPanel;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button titleButton;
    [SerializeField] private Button nextStageButton;
    [SerializeField] private TMP_Text rankText;

    //불,물 캐릭터가 문에 닿았는지 판정.
    public bool FireOnLeftDoor { get; set; } = false;
    public bool WaterOnRightDoor { get; set; } = false;

    //게임 패널을 숨기고 시작.
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (clearPanel != null)
            clearPanel.SetActive(false);

    }

    //버튼 클릭시에 호출될 함수들
    private void Start()
    {
        retryButton.onClick.AddListener(RestartStage);
        titleButton.onClick.AddListener(GoToTitle);
        nextStageButton.onClick.AddListener(GoToNextStage);
    }

    //성공 처리 패널
    public void ShowClearPanel()
    {
        if (PopupManager.Instance != null && PopupManager.Instance.popupCanvas.activeSelf)
            PopupManager.Instance.TogglePopup(false);

        clearPanel.SetActive(true);

        float timeTaken = GameManager.Instance.levelTimeLimit - GameManager.Instance.CurrentTime;

        string rank;
        string colorCode;
        if (timeTaken <= 20f)
        {
            rank = "S";
            colorCode = "#FFD700";
        }
        else if (timeTaken <= 40f)
        {
            rank = "A";
            colorCode = "#A020F0";
        }
        else // 40~59초
        {
            rank = "B";
            colorCode = "#1E90FF";
        }

        GameManager.Instance.OnGameClear(timeTaken);
        Time.timeScale = 0f;
        if (!GameManager.Instance.IsNextStageExist())
        {
            nextStageButton.gameObject.SetActive(false);
        }
        // 남은 시간으로 랭크 계산

        if (rankText != null)
            rankText.text = $"<color={colorCode}>Rank: {rank}</color>";

    }

    //현재씬 다시 로드
    private void RestartStage()
    {
        Time.timeScale = 1f;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //씬 로드 완료 후 게임 매니저 초기화 호출. 이벤트 제거 (-= OnSceneLoaded)로 중복 호출 방지.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameManager.Instance.OnGameStarted();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //타이틀 이동
    private void GoToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    //넥스트 스테이지는 안 만드어서 구현 안함 아직.
    private void GoToNextStage()
    {
        Debug.Log("Going to the next stage");
        GameManager.Instance.GoNextStage();
    }
}
