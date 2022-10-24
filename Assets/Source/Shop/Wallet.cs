using SwipeOrDie.Extension;
using System;
using Source.Model.Storage;
using Source.View;

public class Wallet : IWallet
{
    private readonly IWalletView _view;
    private readonly IStorage _storage;
    private int _money;

    public Wallet(IStorage storage, IWalletView view = null)
    {
        _storage = storage.TryThrowNullReferenceException();
        _view = view;

        _money = _storage.Load<int>(nameof(Wallet));
    }

    public bool CanTake(int money)
    {
        var operation = _money >= money && money >= 0;
        if(operation == false)
            _view.OnError();
        
        return operation;
    }

    public void Put(int money)
    {   
        _money += money.TryThrowSubZeroException();
        CompleteOperation();
    }

    public void Take(int money)
    {
        if (!CanTake(money))
            throw new InvalidOperationException(nameof(Take));

        _money -= money.TryThrowSubZeroException();
        CompleteOperation();
    }

    private void CompleteOperation()
    {
        _storage.Save(nameof(Wallet), _money);
        _view.OnSetMoney(_money);
    }
}