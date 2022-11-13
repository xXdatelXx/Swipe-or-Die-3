using System.Linq;
using Sirenix.OdinInspector;
using Source.Model.Storage;
using Source.ShopSystem;
using SwipeOrDie.Extension;
using UnityEditor;
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
        [SerializeField] private SceneAsset _gameScene;
        private IWallet _wallet;

        [Inject]
        public void Construct(IWallet wallet) => 
            _wallet = wallet.ThrowExceptionIfArgumentNull(nameof(wallet));

        private void Start() => 
            Compose();

        private void Compose()
        {
            var storage = new CollectionStorage<string>(nameof(Mesh));
            var shop = new Shop(_wallet, storage);
            var action = new ShopAction(storage,
                _goods.Select(i => new BuyButtonAction(i, shop)).ToList(),
                _goods.Select(i => new UseButtonAction(i, _gameScene)).ToList());
            
            _leftSwitchButton.Subscribe(new SwitchButtonAction(action, _buyButton, -1));
            _rightSwitchButton.Subscribe(new SwitchButtonAction(action, _buyButton, 1));
            
            _buyButton.Subscribe(action[0]);
            _view.OnSetAction(action[0]);
        }
    }
}