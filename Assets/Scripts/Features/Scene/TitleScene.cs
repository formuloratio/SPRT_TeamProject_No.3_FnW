using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Scene
{
    public class TitleScene : MonoBehaviour
    {
        private GameManager _gameManager;
        private SceneTransitionManager _sceneTransitionManager;
        [SerializeField] private string nextSceneName = "GamePlayScene";
        private string achievementsSceneName = "AchievementScene";
        private AudioManager _audioManager;

        void Awake()
        {
            _gameManager = GameManager.Instance;
            _sceneTransitionManager = SceneTransitionManager.Instance;
            _audioManager = AudioManager.Instance;
        }

        void Start()
        {
            _audioManager.PlayBgm(_audioManager.titleBgm);
        }


        public void OnStartClicked()
        {
            _gameManager.OnGameStarted();
            _sceneTransitionManager.FadeAndLoadScene(nextSceneName);
            _gameManager.ResetCurrentStage();
        }

        public void OnAchievementsLoaded()
        {
            _sceneTransitionManager.LoadScene(achievementsSceneName);
        }

        public void OnQuitClicked()
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}