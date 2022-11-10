using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    //TODO refactor this
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;
        private IButtonAction _action;

        public void Subscribe(IButtonAction action)
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _action = action.ThrowExceptionIfNull();
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(action.OnClick);
        }

        public void Enable() => 
            _button.interactable = true;
        
        private void OnDestroy() => 
            _button.onClick.RemoveListener(_action.OnClick);
    }
}