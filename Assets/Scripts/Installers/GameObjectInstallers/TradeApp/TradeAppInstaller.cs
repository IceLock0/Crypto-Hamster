using Model.TradeApp;
using Zenject;

namespace Installers.GameObjectInstallers.TradeApp
{
    public class TradeAppInstaller : MonoInstaller<TradeAppInstaller>
    {
        public override void InstallBindings()
        {
            BindTradeAppModel();
        }

        private void BindTradeAppModel()
        {
            Container.Bind<TradeAppModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}