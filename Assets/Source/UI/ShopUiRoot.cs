using System.Linq;
using Sirenix.OdinInspector;
using Source.Model.Storage;
using Source.ShopSystem;
using UnityEngine;
using Zenject;

namespace Source.UI
{
    public class ShopUiRoot : SerializedMonoBehaviour
    {
        [SerializeField] private SkinGood[] _goods;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private GoodSwitchButton _leftSwitchButton;
        [SerializeField] private GoodSwitchButton _rightSwitchButton;
        [SerializeField] private IBuyButtonView _view;

        [Inject]
        public void Compose(IWallet wallet)
        {
            var shop = new Shop(wallet, new CollectionStorage<IGood>(nameof(_goods)));
            var buyButtonActions = _goods.Select(i => new BuyButtonAction(i, shop)).ToList();

            _leftSwitchButton.Subscribe(new SwitchButtonAction(buyButtonActions, _view, _buyButton, -1));
            _rightSwitchButton.Subscribe(new SwitchButtonAction(buyButtonActions, _view, _buyButton, 1));
            _buyButton.Subscribe(buyButtonActions[0]);
        }
    }
}