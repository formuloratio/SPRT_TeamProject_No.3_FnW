using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string nextSceneName = "GamePlayScene";

        public static string SceneToLoadOverride;

        void Start()
        {
            if (!string.IsNullOrEmpty(SceneToLoadOverride))
            {
                string sceneToLoad = SceneToLoadOverride;
                SceneToLoadOverride = null;
                SceneManager.LoadScene(sceneToLoad);
                return;
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
}