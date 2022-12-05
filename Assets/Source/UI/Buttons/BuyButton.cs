using SwipeOrDie.Extension;
using SwipeOrDie.View;
using UnityEngine;

namespace SwipeOrDie.Ui
{
    public sealed class BuyButton : Button
    {
        [SerializeField] private IShopButtonView _view;

        private void Awake() => 
            _view.ThrowExceptionIfNull(nameof(_view));

        public void Subscribe(IShopButtonAction action)
        {
            base.Subscribe(action);
            _view.OnSetAction(action);
        }
    }
}