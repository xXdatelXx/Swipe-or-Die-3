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
        [SerializeField] private IShopButtonView _view;

        [Inject]
        public void Compose(IWallet wallet)
        {
            var storage = new CollectionStorage<IGood>(nameof(Shop));
            var shop = new Shop(wallet, storage);
            var action = new ShopAction(storage,
                _goods.Select(i => new BuyButtonAction(i, shop)).ToList(),
                _goods.Select(i => new UseButtonAction(i)).ToList());
            
            _leftSwitchButton.Subscribe(new SwitchButtonAction(action, _view, _buyButton, -1));
            _rightSwitchButton.Subscribe(new SwitchButtonAction(action, _view, _buyButton, 1));
            _buyButton.Subscribe(action[0]);
        }
    }
}