using SwipeOrDie.Extension;

namespace Source.UI
{
    public class BuyButtonAction : IButtonAction
    {
        private readonly IShop _shop;
        public readonly IGood Good;

        public BuyButtonAction(IGood good, IShop shop)
        {
            Good = good.TryThrowArgumentNullException(nameof(good));
            _shop = shop.TryThrowArgumentNullException(nameof(good));
        }

        public void OnClick() => 
            _shop.Buy(Good);
    }
}