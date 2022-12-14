using SwipeOrDie.Extension;
using SwipeOrDie.Model;

namespace SwipeOrDie.Ui
{
    public sealed class BuyButtonAction : IShopButtonAction
    {
        public IGood Good { get; }
        private readonly IShop _shop;

        public BuyButtonAction(IGood good, IShop shop)
        {
            Good = good.ThrowExceptionIfArgumentNull(nameof(good));
            _shop = shop.ThrowExceptionIfArgumentNull(nameof(good));
        }

        public void OnClick() => 
            _shop.Buy(Good);
    }
}