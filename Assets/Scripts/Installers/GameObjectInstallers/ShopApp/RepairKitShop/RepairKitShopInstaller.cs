﻿using System.Collections.Generic;
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
        [SerializeField] private List<RepairKit> _repairKits;
        
        public override void InstallBindings()
        {
            BindRepairKitShopModel();
            BindRepairKitItemFactory();
        }

        private void BindRepairKitShopModel()
        {
            Container.Bind<RepairKitShopModel>()
                .FromInstance(new RepairKitShopModel(_repairKits))
                .AsSingle()
                .NonLazy();
        }

        private void BindRepairKitItemFactory()
        {
            Container.Bind<RepairKitItemFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}