using Sirenix.OdinInspector;
using Source.UI.Components;
using UnityEngine;
using SwipeOrDie.Extension;

namespace Source.View
{
    [RequireComponent(typeof(IText), typeof(Animator))]
    public class WalletView : SerializedMonoBehaviour, IWalletView
    {
        private IText _text;
        private Animator _animator;
        private string _buyAnimation => "Buy";
        private string _errorAnimation => "Error";

        private void Awake()
        {
            _text = GetComponent<IText>();
            _animator = GetComponent<Animator>();
        }

        public void OnSetMoney(int value)
        {
            _text.Set(value);
            _animator.SetTrigger(_buyAnimation);
        }

        public void OnError() => 
            _animator.SetTrigger(_errorAnimation);
    }
}