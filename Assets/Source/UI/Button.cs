using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : MonoBehaviour, IButton
    {
        private UnityEngine.UI.Button _button;
        private IButtonAction _action;

        public void Subscribe(IButtonAction action)
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _button.onClick.AddListener(action.OnClick);
            _action = action.TryThrowNullReferenceException();
        }

        public void Enable() => 
            _button.interactable = true;

        private void OnDestroy() => 
            _button.onClick.RemoveListener(_action.OnClick);
    }
}