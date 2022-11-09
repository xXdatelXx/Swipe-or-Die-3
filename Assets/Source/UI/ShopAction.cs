using System.Collections.Generic;
using FluentValidation;
using Source.Model.Storage;
using SwipeOrDie.Extension;

namespace Source.UI
{
    public sealed class ShopAction : IShopAction
    {
        private readonly ICollectionStorage<IGood> _boughtGoods;
        private readonly List<BuyButtonAction> _buyActions;
        private readonly List<UseButtonAction> _useActions;
        public int Count { get; }

        public ShopAction(ICollectionStorage<IGood> boughtGoods, List<BuyButtonAction> buyActions, List<UseButtonAction> useActions)
        {
            _boughtGoods = boughtGoods;
            _buyActions = buyActions;
            _useActions = useActions;
            new Validator().ValidateAndThrow(this);

            Count = _buyActions.Count;
        }

        public IShopButtonAction this[int id] =>
            _boughtGoods.Load().Has(_buyActions[id].Good) ? _buyActions[id] : _useActions[id];
        
        private class Validator : AbstractValidator<ShopAction>
        {
            public Validator()
            {
                RuleFor(action => action._boughtGoods).NotNull();
                RuleForEach(action => action._buyActions).NotNull();
                RuleForEach(action => action._useActions).NotNull();
                RuleFor(action => action._buyActions.Count).Equal(action => action._useActions.Count);
            }
        }
    }
}