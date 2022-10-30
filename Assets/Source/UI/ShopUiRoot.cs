using System;
using System.Collections.Generic;
using Sirenix.Utilities;
using Source.Shope;
using SwipeOrDie.Extension;
using UnityEngine;
using Zenject;

namespace Source.UI
{
    public class ShopUiRoot : MonoBehaviour
    {
        [SerializeField] private Dictionary<SkinGood, BuyButton> _items;

        [Inject]
        public void Compose(IWallet wallet)
        {
            var shop = new Shop(wallet.TryThrowArgumentNullException("wallet == null"));

            foreach (var i in _items) 
                i.Value.Subscribe(new BuyButtonAction(i.Key, shop));
        }
    }
}