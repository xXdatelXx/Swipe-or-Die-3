using SwipeOrDie.Extension;

public class Shop : IShop
{
    private readonly IWallet _wallet;

    public Shop(IWallet wallet)
    {
        _wallet = wallet.TryThrowNullReferenceException();
    }

    public void Buy(IGood good)
    {
        int price = good.Price;

        if (_wallet.CanTake(price))
        {
            _wallet.Take(price);
            good.Use();
        }
    }
}