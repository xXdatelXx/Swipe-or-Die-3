using System.Collections.Generic;
using FluentValidation;
using ModestTree;
using Source.Model.Storage;
using SwipeOrDie.Extension;

namespace Source.UI
{
    public sealed class ShopAction : IShopAction
    {
        private readonly ICollectionStorage<string> _inventory;
        private readonly List<BuyButtonAction> _buyActions;
        private readonly List<UseButtonAction> _useActions;
        public int Count { get; }
        public int Last { get; private set; }

        public ShopAction(ICollectionStorage<string> inventory, List<BuyButtonAction> buyActions, List<UseButtonAction> useActions)
        {
            _inventory = inventory;
            _buyActions = buyActions;
            _useActions = useActions;
            new Validator().ValidateAndThrow(this);

            Count = _buyActions.Count;
        }

        public IShopButtonAction this[int id]
        {
            get
            {
                Last = id;
                return _inventory.Exists()
                    ? _inventory.Load().Has(_buyActions[id].Good.Id) ? _useActions[id] : _buyActions[id]
                    : _buyActions[id];
            }
        }

        private class Validator : AbstractValidator<ShopAction>
        {
            public Validator()
            {
                RuleFor(action => action._inventory).NotNull();
                RuleForEach(action => action._buyActions).NotNull();
                RuleForEach(action => action._useActions).NotNull();
                RuleFor(action => action._buyActions.Count).Equal(action => action._useActions.Count);
            }
        }
    }
}