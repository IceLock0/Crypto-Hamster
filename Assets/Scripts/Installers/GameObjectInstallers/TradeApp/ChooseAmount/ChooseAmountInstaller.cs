using Model.ChooseAmount;
using Zenject;

namespace Installers.GameObjectInstallers.TradeApp.ChooseAmount
{
    public class ChooseAmountInstaller : MonoInstaller<ChooseAmountInstaller>
    {
        public override void InstallBindings()
        {
            BindChooseAmountModel();
        }
        
        private void BindChooseAmountModel()
        {
            Container.Bind<ChooseAmountModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}