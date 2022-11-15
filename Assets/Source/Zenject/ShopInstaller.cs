using Sirenix.Utilities;
using Source;
using Source.Model.Storage;
using Source.ShopSystem;
using Source.View;
using UnityEngine;
using Zenject;

public sealed class ShopInstaller : MonoInstaller
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private SkinGood[] _skinGoods;

    public override void InstallBindings()
    {
        var skinStorage = new MeshStorage(nameof(CharacterSkin));
        
        // я не знаю как делать inject в SO
        _skinGoods.ForEach(i => i.Init(skinStorage));
        Container.BindInstance((IWallet)new Wallet(new BinaryStorage<int>(nameof(Wallet)), _walletView));
    }
}
