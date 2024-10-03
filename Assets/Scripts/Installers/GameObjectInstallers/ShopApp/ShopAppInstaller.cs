using Services.Fabric;
using Zenject;

namespace Installers.GameObjectInstallers.ShopApp
{
    public class ShopAppInstaller : MonoInstaller<ShopAppInstaller>
    {
        public override void InstallBindings()
        {
            BindRepairKitItemFactory();
            BindPCSlotShopItemFactory();
        }

        private void BindPCSlotShopItemFactory()
        {
            Container.Bind<PCSLotShopItemFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindRepairKitItemFactory()
        {
            Container.Bind<ShopItemFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}