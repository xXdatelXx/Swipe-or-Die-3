using System.Collections.Generic;
using System.Linq;
using Source.Model.Storage;
using SwipeOrDie.Extension;

public class Shop : IShop
{
    private readonly IWallet _wallet;
    private readonly ICollectionStorage<IGood> _boughtGoodsStorage;

    public Shop(IWallet wallet, ICollectionStorage<IGood> boughtGoods)
    {
        _wallet = wallet.TryThrowArgumentNullException();
        _boughtGoodsStorage = boughtGoods.TryThrowNullReferenceException();
    }

    public void Buy(IGood good)
    {
        good.TryThrowArgumentNullException();
        
        var boughtGoods = 
            _boughtGoodsStorage.Exists() ? _boughtGoodsStorage.Load().ToList() : new List<IGood>();
        
        if (!boughtGoods.Has(good) && _wallet.CanTake(good.Price))
        {
            _wallet.Take(good.Price);
            _boughtGoodsStorage.Add(good);
        }
        
        if (boughtGoods.Has(good))
            good.Use();


        //var boughtGoods = _boughtGoodsStorage.Exists() ? _boughtGoodsStorage.Load().ToList() : new List<IGood>();
        if (!boughtGoods.Has(good) && _wallet.CanTake(good.Price))
        {
            _wallet.Take(good.Price);
            boughtGoods.Add(good);
        }
        else if (boughtGoods.Has(good))
            good.Use();
    }

    private bool CanUse(IGood good) =>
        !_boughtGoodsStorage.Exists() || !(_wallet.CanTake(good.Price) && _boughtGoodsStorage.Load().Has(good));
}