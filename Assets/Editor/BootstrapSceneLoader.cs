using UnityEditor;
using UnityEditor.SceneManagement;
using Utils;

namespace Editor
{
    [InitializeOnLoad]
    public static class BootstrapSceneLoader
    {

        static BootstrapSceneLoader()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {

            if (state == PlayModeStateChange.ExitingEditMode)
            {
                EditorPrefs.SetString(SceneLoaderConstants.PreviousSceneKey, EditorSceneManager.GetActiveScene().path);
            }
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                string previousScenePath = EditorPrefs.GetString(SceneLoaderConstants.PreviousSceneKey);
                if (!string.IsNullOrEmpty(previousScenePath))
                {
                    EditorSceneManager.OpenScene(previousScenePath);
                    EditorPrefs.DeleteKey(SceneLoaderConstants.PreviousSceneKey);
                }
            }
        }
    }
}