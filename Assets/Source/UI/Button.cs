using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : SerializedMonoBehaviour
    {
        private UnityEngine.UI.Button _button;
        private IButtonAction _action;

        public void Subscribe(IButtonAction action)
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _action = action.ThrowExceptionIfNull(nameof(action));
            
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(action.OnClick);
        }

        private void OnDestroy() => 
            _button.onClick.RemoveListener(_action.OnClick);
    }
}