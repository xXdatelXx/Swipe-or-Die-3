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
        private int _id;

        public SwitchButtonAction(IShopAction actions, IShopButtonView view, BuyButton buyButton, int direction)
        {
            _action = actions.ThrowIfArgumentNull();
            _view = view.ThrowIfArgumentNull();
            _buyButton = buyButton.ThrowIfArgumentNull();
            _direction = direction.ThrowIfArgumentNull();
        }

        public void OnClick()
        {
            _id = new Range(0, _action.Count).Clamp(_id + _direction);
            var action = _action[_id];
            
            _buyButton.Subscribe(action);
            _view.OnSetGood(action);
        }
    }
}