using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : SerializedMonoBehaviour
    {
        private UnityEngine.UI.Button _button;

        private void OnEnable() => 
            _button = GetComponent<UnityEngine.UI.Button>();

        public void Subscribe(IButtonAction action)
        {
            action.ThrowExceptionIfArgumentNull(nameof(action));
            _button.onClick.AddListener(action.OnClick);
        }

        public void Unsubscribe() => 
            _button.onClick.RemoveAllListeners();
    }
}