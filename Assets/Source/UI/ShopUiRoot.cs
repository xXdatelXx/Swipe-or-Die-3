using System.Collections.Generic;
using System.Linq;
using Source;
using Source.Model.Storage;
using Source.ShopSystem;
using Source.UI;
using Source.View;
using SwipeOrDie.Data;
using UnityEditor;
using UnityEngine;

namespace SwipeOrDie.Roots
{
    public sealed class ShopUiRoot : CompositeRoot
    {
        [SerializeField] private ISkinGoodList _goods;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private GoodSwitchButton _leftSwitchButton;
        [SerializeField] private GoodSwitchButton _rightSwitchButton;
        [SerializeField] private SceneAsset _exitScene;
        [SerializeField] private IWalletView _walletView;
        
        public override void Compose()
        {
            var wallet = new Wallet(new BinaryStorage<int>(nameof(Wallet)), _walletView);
            var storage = new CollectionStorage<string>(nameof(Mesh));
            var shop = new Shop(wallet, storage);
            var action = new ShopAction(storage,
                _goods.Goods.Select(i => new BuyButtonAction(i, shop)).ToList(),
                _goods.Goods.Select(i => new UseButtonAction(i, _exitScene)).ToList());
            
            _goods.Init(new MeshStorage(nameof(CharacterSkin)));
            
            _leftSwitchButton.Subscribe(new SwitchButtonAction(action, _buyButton, -1));
            _rightSwitchButton.Subscribe(new SwitchButtonAction(action, _buyButton, 1));
            
            _buyButton.Subscribe(new UseButtonAction(_goods.Goods[0], _exitScene));
        }
    }
}