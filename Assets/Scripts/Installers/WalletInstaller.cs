using Model.Wallet;
using UnityEngine;
using Views.Wallet;
using Zenject;

namespace Installers
{
    public class WalletInstaller : MonoInstaller
    {
        [SerializeField] private WalletCryptoUIView _walletCryptoUIView;
        
        public override void InstallBindings()
        {
            BindWalletModel();
            BindWalletCryptoUIView();
        }

        private void BindWalletModel()
        {
            Container
                .Bind<WalletModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindWalletCryptoUIView()
        {
            Container.Bind<WalletCryptoUIView>()
                .FromInstance(_walletCryptoUIView)
                .AsSingle()
                .NonLazy();
        }
    }
}