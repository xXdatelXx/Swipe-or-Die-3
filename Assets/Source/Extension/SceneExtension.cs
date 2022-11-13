using UnityEditor;
using UnityEngine.SceneManagement;

namespace SwipeOrDie.Extension
{
    public static class SceneExtension
    {
        public static void Load(this SceneAsset scene) => 
            SceneManager.LoadScene(scene.name);
    }
}