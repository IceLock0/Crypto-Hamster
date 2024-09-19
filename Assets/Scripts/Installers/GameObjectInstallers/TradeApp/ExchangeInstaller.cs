using Model.Exchange;
using Zenject;

namespace Installers.GameObjectInstallers.TradeApp
{

    public class ExchangeInstaller : MonoInstaller<ExchangeInstaller>
    {
        public override void InstallBindings()
        {
            BindExchangeModel();
        }

        private void BindExchangeModel()
        {
            Container.Bind<ExchangeModel>()
                .AsSingle()
                .NonLazy();
        }
    }

}