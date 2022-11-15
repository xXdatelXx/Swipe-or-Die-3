using SwipeOrDie.Extension;
using UnityEditor;

namespace Source.UI
{
    public sealed class UseButtonAction: IShopButtonAction
    {
        private readonly SceneAsset _exitScene;
        public IGood Good { get; }

        public UseButtonAction(IGood good, SceneAsset exitScene)
        {
            Good = good.ThrowExceptionIfArgumentNull(nameof(good));
            _exitScene = exitScene.ThrowExceptionIfArgumentNull(nameof(exitScene));
        }

        public void OnClick()
        {
            Good.Use();
            _exitScene.Load();
        }
    }
}