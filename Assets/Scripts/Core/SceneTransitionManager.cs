using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class SceneTransitionManager : MonoBehaviour
    {
        public static SceneTransitionManager Instance { get; private set; }

        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private CanvasGroup canvasGroup;
        private bool _isTransitioning = false;
        public string CurrentSceneName => SceneManager.GetActiveScene().name;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            if(_isTransitioning) return;
            StartCoroutine(LoadSceneRoutine(sceneName));
        }

        public void FadeAndLoadScene(string sceneName)
        {
            if (_isTransitioning) return;
            StartCoroutine(FadeAndLoadSceneRoutine(sceneName));
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            _isTransitioning = true;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            yield return asyncLoad;
            _isTransitioning = false;
        }

        private IEnumerator FadeAndLoadSceneRoutine(string sceneName)
        {
            _isTransitioning = true;
            yield return StartCoroutine(FadeRoutine(1f));
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            yield return asyncLoad;
            yield return StartCoroutine(FadeRoutine(0f));


            _isTransitioning = false;
        }

        private IEnumerator FadeRoutine(float targetAlpha)
        {
            if (canvasGroup == null) yield break;

            float startAlpha = canvasGroup.alpha;
            canvasGroup.blocksRaycasts = targetAlpha > 0.5f;

            float elapsed = 0f;
            while (elapsed < fadeDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
                yield return null;
            }

            canvasGroup.alpha = targetAlpha;
        }
        public void FadeAndLoadSceneByIndex(int buildIndex)
        {
            if (buildIndex < 0 || buildIndex >= SceneManager.sceneCountInBuildSettings)
            {
                return;
            }
            string scenePath = SceneUtility.GetScenePathByBuildIndex(buildIndex);
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            FadeAndLoadScene(sceneName);
        }
    }
}