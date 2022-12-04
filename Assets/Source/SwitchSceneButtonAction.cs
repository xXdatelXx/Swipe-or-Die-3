using Source.UI;
using SwipeOrDie.Extension;
using UnityEditor;
using UnityEngine;

namespace SwipeOrDie.Ui
{
    public sealed class SwitchSceneButtonAction : IButtonAction
    {
        [SerializeField] private SceneAsset _scene;

        public SwitchSceneButtonAction(SceneAsset scene) => 
            _scene = scene.ThrowExceptionIfArgumentNull(nameof(scene));

        public void OnClick() => _scene.Load();
    }
}