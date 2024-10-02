using System.Collections.Generic;
using Model.ShopApp;
using ScriptableObjects;
using Services.Fabric;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers.ShopApp.RepairKitShop
{
    public class RepairKitShopInstaller : MonoInstaller<RepairKitShopInstaller>
    {
        [Header("Repair kit shop items")]
        [SerializeField] private List<ScriptableObjects.ShopItem> _repairKits;
        
        public override void InstallBindings()
        {
            BindRepairKitShopModel();
            BindRepairKitItemFactory();
        }

        private void BindRepairKitShopModel()
        {
            Container.Bind<ShopModel>()
                .FromInstance(new ShopModel(_repairKits))
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