using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Ui
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : SerializedMonoBehaviour, IButton
    {
        private UnityEngine.UI.Button _button;
        
        [Inject]
        private void Construct() => _button = GetComponent<UnityEngine.UI.Button>();

        public void Subscribe(IButtonAction action)
        {
            action.ThrowExceptionIfArgumentNull(nameof(action));
            _button.onClick.AddListener(action.OnClick);
        }

        public void Unsubscribe() => _button.onClick.RemoveAllListeners();

        public void Enable() => _button.interactable = true;

        public void Disable() => _button.interactable = false;
    }
}