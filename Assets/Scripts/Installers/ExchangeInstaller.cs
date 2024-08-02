using Model.Exchange;
using Presenters.UI.ExchangeButton;
using UnityEngine;
using Views.UI.ExchangeButton;
using Views.Wallet;
using Zenject;

namespace Installers
{

    public class ExchangeInstaller : MonoInstaller
    {
        [SerializeField] private ExchangeButtonView _exchangeButtonView;
        [SerializeField] private WalletCryptoUIView _walletCryptoUIView;
        public override void InstallBindings()
        {
            BindExchangeModel();
            BindWalletCryptoUIView();
            BindExchangeButtonView();
            BindExchangeButtonPresenter();
        }

        private void BindWalletCryptoUIView()
        {
            Container.Bind<WalletCryptoUIView>()
                .FromInstance(_walletCryptoUIView)
                .AsSingle()
                .NonLazy();
        }

        private void BindExchangeButtonPresenter()
        {
            Container.Bind<ExchangeButtonPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindExchangeButtonView()
        {
            Container.Bind<ExchangeButtonView>()
                .FromInstance(_exchangeButtonView)
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