using Model.Exchange;
using Presenters.UI.BuyCryptoButton;
using Presenters.UI.SellCryptoButton;
using UnityEngine;
using Views.UI.BuyCryptoButton;
using Views.UI.SellButton;
using Views.Wallet;
using Zenject;

namespace Installers
{

    public class ExchangeInstaller : MonoInstaller
    {
        [SerializeField] private SellCryptoButtonView _sellCryptoButtonView;
        [SerializeField] private BuyCryptoButtonView _buyCryptoButtonView;
        [SerializeField] private WalletCryptoUIView _walletCryptoUIView;
        public override void InstallBindings()
        {
            BindExchangeModel();
            BindWalletCryptoUIView();
            BindSellCryptoButtonView();
            BindBuyCryptoButtonView();
            BindSellCryptoButtonPresenter();
            BindBuyCryptoButtonPresenter();
        }

        private void BindBuyCryptoButtonPresenter()
        {
            Container.Bind<BuyCryptoButtonPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBuyCryptoButtonView()
        {
            Container.Bind<BuyCryptoButtonView>()
                .FromInstance(_buyCryptoButtonView)
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

        private void BindSellCryptoButtonPresenter()
        {
            Container.Bind<SellCryptoButtonPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSellCryptoButtonView()
        {
            Container.Bind<SellCryptoButtonView>()
                .FromInstance(_sellCryptoButtonView)
                .AsSingle()
                .NonLazy();
        }

        private void BindExchangeModel()
        {
            Container.Bind<ExchangeModel>()
                .AsSingle()
                .NonLazy();
        }
    }

}