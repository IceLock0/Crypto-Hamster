using Model.ShopApp;
using Services.Fabric;
using UnityEngine;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop
{
    public class RepairKitShopPresenter
    {
        private readonly RepairKitShopModel _kitShopModel;
        private readonly RepairKitItemFactory _factory;
        private readonly Transform _container;
        
        public RepairKitShopPresenter(RepairKitShopModel kitShopModel, RepairKitItemFactory factory, Transform container)
        {
            InvariantChecker.CheckObjectInvariant(kitShopModel, factory, container);
            
            _kitShopModel = kitShopModel;
            _factory = factory;
            _container = container;
        }

        public void InitializeItems()
        {
            foreach (var kit in _kitShopModel.RepairKits)
            {
                _factory.Create(_container, kit);
            }
        }
    }
}