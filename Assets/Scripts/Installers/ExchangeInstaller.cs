using Model.Exchange;
using Presenters.UI.ExchangeButton;
using UnityEngine;
using Views.UI.ExchangeButton;
using Views.UI.Wallet;
using Zenject;

namespace Installers
{

    public class ExchangeInstaller : MonoInstaller
    {
        [SerializeField] private ExchangeButtonView _exchangeButtonView;
        [SerializeField] private CryptoDropDownHandler _cryptoDropDownHandler;
        public override void InstallBindings()
        {
            BindExchangeModel();
            BindCryptoDropdownHandler();
            BindExchangeButtonView();
            BindExchangeButtonPresenter();
        }

        private void BindCryptoDropdownHandler()
        {
            Container.Bind<CryptoDropDownHandler>()
                .FromInstance(_cryptoDropDownHandler)
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