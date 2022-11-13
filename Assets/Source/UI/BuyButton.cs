using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    public class BuyButton : Button
    {
        [SerializeField] private IShopButtonView _view;
        private UseButtonAction _useAction;

        private void Awake() => 
            _view.ThrowExceptionIfNull(nameof(_view));

        /*public void Subscribe(IShopButtonAction action)
        {
            base.Subscribe(action);
//            base.Subscribe(_useAction);
            _view.OnSetAction(_useAction);
        }*/
    }
}