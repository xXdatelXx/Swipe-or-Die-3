using SwipeOrDie.Extension;

namespace Source.UI
{
    public class BuyButtonAction : IShopButtonAction
    {
        public IGood Good { get; }
        private readonly IShop _shop;

        public BuyButtonAction(IGood good, IShop shop)
        {
            Good = good.ThrowIfArgumentNull(nameof(good));
            _shop = shop.ThrowIfArgumentNull(nameof(good));
        }

        public void OnClick() => 
            _shop.Buy(Good);
    }
}