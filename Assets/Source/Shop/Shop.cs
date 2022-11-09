using Source.Model.Storage;
using SwipeOrDie.Extension;

namespace Source.ShopSystem
{
    public sealed class Shop : IShop
    {
        private readonly IWallet _wallet;
        private readonly ICollectionStorage<IGood> _boughtGoods;

        public Shop(IWallet wallet, ICollectionStorage<IGood> boughtGoods)
        {
            _wallet = wallet.ThrowIfArgumentNull(nameof(wallet));
            _boughtGoods = boughtGoods.ThrowIfArgumentNull(nameof(boughtGoods));
        }

        public void Buy(IGood good)
        {
            if (_wallet.CanTake(good.Price))
            {
                _wallet.Take(good.Price);
                _boughtGoods.Add(good);
            }
        }
    }
}