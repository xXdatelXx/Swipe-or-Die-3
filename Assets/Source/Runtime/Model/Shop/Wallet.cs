using SwipeOrDie.Extension;
using System;
using JetBrains.Annotations;
using SwipeOrDie.Storage;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class Wallet : IWallet
    {
        [CanBeNull] private readonly IWalletView _view;
        private readonly IStorage<int> _storage;
        public int Money { get; private set; }

        public Wallet(IStorage<int> storage, IWalletView view = null)
        {
            _storage = storage.ThrowExceptionIfNull();
            _view = view;

            if (_storage.Exists())
            {
                Money = _storage.Load();
                _view?.OnSetMoney(Money);
            }
        }

        public bool CanTake(int money)
        {
            var operation = Money >= money && money >= 0;
            if (operation == false)
                _view?.OnError();

            return operation;
        }

        public void Put(int money = 1)
        {
            Money += money.ThrowExceptionIfValueSubZero();
            CompleteOperation();
        }

        public void Take(int money)
        {
            if (!CanTake(money))
                throw new InvalidOperationException(nameof(Take));

            Money -= money.ThrowExceptionIfValueSubZero();
            CompleteOperation();
        }

        private void CompleteOperation()
        {
            _storage.Save(Money);
            _view?.OnSetMoney(Money);
        }
    }
}