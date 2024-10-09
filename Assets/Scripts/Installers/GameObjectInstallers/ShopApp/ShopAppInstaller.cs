
using System.Collections.Generic;
using CareBoo.Serially;
using Model.ShopApp;
using Services.Fabric;
using UnityEngine;
using Utils.SerializableKeyValuePair;
using Views.Phone.Apps.ShopApp.RepairKitShop;
using Zenject;

namespace Installers.GameObjectInstallers.ShopApp
{
    public class ShopAppInstaller : MonoInstaller<ShopAppInstaller>
    {
        [SerializeField] private List<SerializableKeyValuePair<SerializableType, ShopView>> _shopViews;
        public override void InstallBindings()
        {
            BindShopAppsModel();
            BindRepairKitItemFactory();
            BindPCSlotShopItemFactory();
        }

        private void BindShopAppsModel()
        {
            Container.Bind<ShopAppsModel>()
                .FromInstance(new ShopAppsModel(_shopViews))
                .AsSingle()
                .NonLazy();
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