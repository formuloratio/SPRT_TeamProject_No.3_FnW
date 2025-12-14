using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Core;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;

    //게임오버 패널 숨김
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (PopupManager.Instance != null && PopupManager.Instance.popupCanvas.activeSelf)
            PopupManager.Instance.TogglePopup(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // GameManager 상태를 GameOver로 변경 알려주고 시간은 0으로 
        GameManager.Instance.OnGameOver();
        Time.timeScale = 0f;
    }

    //버튼 클리식 호출될 함수 
    private void Start()
    {
        if (retryButton != null)
            retryButton.onClick.AddListener(RestartScene);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
    }

    private void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.sceneLoaded += OnSceneLoaded;  // 씬 로드 후 초기화
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //씬 로드 후 게임 매니저 초기화 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameManager.Instance.OnGameStarted();   // 타이머 및 상태 초기화
        SceneManager.sceneLoaded -= OnSceneLoaded;  // 이벤트 해제, 중복호출 방지
    }

    //게임 종료
    private void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif 
    }
}
