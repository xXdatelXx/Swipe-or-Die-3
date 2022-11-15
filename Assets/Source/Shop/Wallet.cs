using SwipeOrDie.Extension;
using System;
using Source.Model.Storage;
using Source.View;

public sealed class Wallet : IWallet
{
    private readonly IWalletView _view;
    private readonly IStorage<int> _storage;
    private int _money;

    public Wallet(IStorage<int> storage, IWalletView view = null)
    {
        _storage = storage.ThrowExceptionIfNull();
        _view = view;

        if (_storage.Exists())
        {
            _money = _storage.Load();
            _view.OnSetMoney(_money);
        }
    }

    public bool CanTake(int money)
    {
        var operation = _money >= money && money >= 0;
        if (operation == false)
            _view.OnError();

        return operation;
    }

    public void Put(int money = 1)
    {
        _money += money.ThrowExceptionIfValueSubZero();
        CompleteOperation();
    }

    public void Take(int money)
    {
        if (!CanTake(money))
            throw new InvalidOperationException(nameof(Take));

        _money -= money.ThrowExceptionIfValueSubZero();
        CompleteOperation();
    }

    private void CompleteOperation()
    {
        _storage.Save(_money);
        _view.OnSetMoney(_money);
    }
}