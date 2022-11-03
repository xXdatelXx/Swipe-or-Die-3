using System.Collections.Generic;
using SwipeOrDie.Extension;

namespace Source.UI
{
    public class SwitchButtonAction : IButtonAction
    {
        private readonly List<BuyButtonAction> _actions;
        private readonly IBuyButtonView _view;
        private readonly BuyButton _buyButton;
        private readonly int _direction;
        private int _id;

        public SwitchButtonAction(List<BuyButtonAction> actions, IBuyButtonView view, BuyButton buyButton, int direction)
        {
            _actions = actions.TryThrowArgumentNullException();
            _view = view.TryThrowArgumentNullException();
            _buyButton = buyButton.TryThrowArgumentNullException();
            _direction = direction.TryThrowArgumentNullException();
        }

        public void OnClick()
        {
            _id = _actions.ClampId(_id + _direction);
            
            _buyButton.Subscribe(_actions[_id]);
            _view.OnSetGood(_actions[_id].Good);
        }
    }
}