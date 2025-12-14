using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public static class RuntimeInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitializeBeforeSceneLoad()
        {
            #if UNITY_EDITOR
            if (SceneManager.GetActiveScene().path != SceneLoaderConstants.BootstrapscenePath)
            {
                string previousScene = EditorPrefs.GetString(SceneLoaderConstants.PreviousSceneKey);
                if (!string.IsNullOrEmpty(previousScene))
                {
                    SceneLoader.SceneToLoadOverride = previousScene;
                    EditorPrefs.DeleteKey(SceneLoaderConstants.BootstrapscenePath);
                }

                SceneManager.LoadScene(SceneLoaderConstants.BootstrapscenePath);
            }
            #endif
        }
    }
}