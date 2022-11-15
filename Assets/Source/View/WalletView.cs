using Sirenix.OdinInspector;
using Source.UI.Components;
using UnityEngine;
using SwipeOrDie.Extension;

namespace Source.View
{
    public sealed class WalletView : SerializedMonoBehaviour, IWalletView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private IText _text;
        private string _buyAnimation => "Buy";
        private string _errorAnimation => "Error";

        public void OnSetMoney(int value)
        {
            _text.Set(value);
            _animator.SetTrigger(_buyAnimation);
        }

        public void OnError() => 
            _animator.SetTrigger(_errorAnimation);
    }
}