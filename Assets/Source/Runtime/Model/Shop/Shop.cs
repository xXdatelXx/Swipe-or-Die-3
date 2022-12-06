using SwipeOrDie.Storage;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Model
{
    public sealed class Shop : IShop
    {
        private readonly IWallet _wallet;
        private readonly ICollectionStorage<string> _inventory;

        public Shop(IWallet wallet, ICollectionStorage<string> inventory)
        {
            _wallet = wallet.ThrowExceptionIfArgumentNull(nameof(wallet));
            _inventory = inventory.ThrowExceptionIfArgumentNull(nameof(inventory));
        }

        public void Buy(IGood good)
        {
            if (_wallet.CanTake(good.Price))
            {
                _wallet.Take(good.Price);
                _inventory.Add(good.Id);
            }
        }
    }
}