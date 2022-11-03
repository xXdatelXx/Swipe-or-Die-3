using Source.Model.Storage;
using SwipeOrDie.Extension;

public class Shop : IShop
{
    private readonly IWallet _wallet;
    private readonly ICollectionStorage<IGood> _boughtGoods;

    public Shop(IWallet wallet, ICollectionStorage<IGood> boughtGoods)
    {
        _wallet = wallet.TryThrowArgumentNullException();
        _boughtGoods = boughtGoods.TryThrowNullReferenceException();
    }

    public void Buy(IGood good)
    {
        if (CanUse(good))
            return;
        
        _boughtGoods.Add(good);
        good.Use();
    }

    private bool CanUse(IGood good) => 
        !_boughtGoods.Exists() || !(_wallet.CanTake(good.Price) && _boughtGoods.Load().Has(good));
}