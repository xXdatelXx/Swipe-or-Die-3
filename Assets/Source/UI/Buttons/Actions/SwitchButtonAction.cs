using SwipeOrDie.Data;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Ui
{
    public sealed class SwitchButtonAction : IButtonAction
    {
        private readonly IShopAction _action;
        private readonly BuyButton _buyButton;
        private readonly int _direction;

        public SwitchButtonAction(IShopAction actions, BuyButton buyButton, int direction)
        {
            _action = actions.ThrowExceptionIfArgumentNull();
            _buyButton = buyButton.ThrowExceptionIfArgumentNull();
            _direction = direction.ThrowExceptionIfArgumentNull();
        }

        public void OnClick()
        {
            var action = _action[new Range(0, _action.Count - 1).Clamp(_action.Last + _direction)];
            _buyButton.Unsubscribe();
            _buyButton.Subscribe(action);
            _buyButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => _buyButton.Subscribe(_action[_action.Last]));
        }
    }
}