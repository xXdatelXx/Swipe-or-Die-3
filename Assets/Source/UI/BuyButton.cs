using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
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