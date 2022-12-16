using SwipeOrDie.Extension;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwipeOrDie.Ui
{
    public sealed class SwitchSceneButtonAction : IButtonAction
    {
        [SerializeField] private string _scene;

        public SwitchSceneButtonAction(string scene) => 
            _scene = scene.ThrowExceptionIfArgumentNull(nameof(scene));

        public void OnClick() => SceneManager.LoadScene(_scene);
    }
}