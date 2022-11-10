using SwipeOrDie.Data;
using SwipeOrDie.Extension;

namespace Source.UI
{
    public class SwitchButtonAction : IButtonAction
    {
        private readonly IShopAction _action;
        private readonly IShopButtonView _view;
        private readonly BuyButton _buyButton;
        private readonly int _direction;

        public SwitchButtonAction(IShopAction actions, IShopButtonView view, BuyButton buyButton, int direction)
        {
            _action = actions.ThrowExceptionIfArgumentNull();
            _view = view.ThrowExceptionIfArgumentNull();
            _buyButton = buyButton.ThrowExceptionIfArgumentNull();
            _direction = direction.ThrowExceptionIfArgumentNull();
        }

        public void OnClick()
        {
            var action = _action[new Range(0, _action.Count - 1).Clamp(_action.Last + _direction)];
            
            _buyButton.Subscribe(action);
            _view.OnSetGood(action);
        }
    }
}