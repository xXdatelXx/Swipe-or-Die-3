using Source.Model.Storage;
using Source.View;
using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private WalletView _walletView;

    public override void InstallBindings() => 
        Container.BindInstance((IWallet)new Wallet(new BinaryStorage<int>(nameof(Wallet)), _walletView));
}
