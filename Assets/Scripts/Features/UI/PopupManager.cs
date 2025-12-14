using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;
    [Header("Popup UI")]
    public GameObject popupCanvas; // PopupCanvas 연결
    private void Awake()
    {
        // 싱글톤 처리
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 팝업 숨기기
        if (popupCanvas != null)
            popupCanvas.SetActive(false);
    }

    void Update()
    {
        // ESC 키로 팝업 열기 / 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePopup();
        }
    }

    //팝업 켜기 끄기
    public void TogglePopup(bool? forceShow = null)
    {
        if (popupCanvas == null) return;

        bool show = forceShow ?? !popupCanvas.activeSelf; //forceShow가 null값이 아니면 상ㅇ
        popupCanvas.SetActive(show);

        CanvasGroup cg = popupCanvas.GetComponent<CanvasGroup>(); // 팝업 ui클릭 가능, 불가
        if (cg == null)
            cg = popupCanvas.AddComponent<CanvasGroup>();

        // 팝업 활성화 상태에 맞춰 버튼 클릭 가능하도록 설정 버튼 활성화 비 활성화
        cg.interactable = show;
        cg.blocksRaycasts = show;

        if (show)
            GameManager.Instance.PauseGame();
        else
            GameManager.Instance.ResumeGame();
    }

    //게임 새로 재시작 
    public void OnRestartButton()
    {
        TogglePopup(false); // 팝업 닫기
        Time.timeScale = 1f;

        string currentSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.OnGameStarted();
        SceneTransitionManager.Instance.FadeAndLoadScene(currentSceneName);

    }
    //게임 이어서 시작 
    public void OnResumeButton()
    {
        if (popupCanvas != null)
            popupCanvas.SetActive(false); // 팝업 사라지게

        TogglePopup(false); // 팝업 닫기
        GameManager.Instance.ResumeGame();
    }

    //타이틀로 이동
    public void OnTitleButton()
    {
        TogglePopup(false); // 팝업 닫기
        Time.timeScale = 1f;
        GameManager.Instance.OnGamePaused();
        SceneTransitionManager.Instance.FadeAndLoadScene("TitleScene");
    }

    //게임 종료
    public void OnQuitButton()
    {
        TogglePopup(false); // 팝업 닫기
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}



