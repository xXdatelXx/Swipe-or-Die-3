using SwipeOrDie.Extension;
using SwipeOrDie.Model;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace SwipeOrDie.Ui
{
    public sealed class UseButtonAction: IShopButtonAction
    {
        private readonly string _exitScene;
        public IGood Good { get; }

        public UseButtonAction(IGood good, string exitScene)
        {
            Good = good.ThrowExceptionIfArgumentNull(nameof(good));
            _exitScene = exitScene.ThrowExceptionIfArgumentNull(nameof(exitScene));
        }

        public void OnClick()
        {
            Good.Use();
            SceneManager.LoadScene(_exitScene);
        }
    }
}