using Model.Exchange;
using Presenters.UI.BuyCryptoButton;
using Presenters.UI.SellCryptoButton;
using UnityEngine;
using Views.UI.BuyCryptoButton;
using Views.UI.SellButton;
using Views.Wallet;
using Zenject;

namespace Installers.GameObjectInstallers.TradeApp
{

    public class ExchangeInstaller : MonoInstaller<ExchangeInstaller>
    {
        [SerializeField] private SellCryptoButtonView _sellCryptoButtonView;
        [SerializeField] private BuyCryptoButtonView _buyCryptoButtonView;

        public override void InstallBindings()
        {
            BindExchangeModel();
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