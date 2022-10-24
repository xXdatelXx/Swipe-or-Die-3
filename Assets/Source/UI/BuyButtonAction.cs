using SwipeOrDie.Extension;

namespace Source.UI
{
    public class BuyButtonAction : IButtonAction
    {
        private readonly IGood _good;
        private readonly IShop _shop;

        public BuyButtonAction(IGood good, IShop shop)
        {
            _good = good.TryThrowArgumentNullException(nameof(good));
            _shop = shop.TryThrowArgumentNullException(nameof(good));
        }

        public void OnClick() => 
            _shop.Buy(_good);
    }
}