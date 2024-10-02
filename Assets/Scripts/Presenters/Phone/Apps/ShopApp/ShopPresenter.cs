using Model.ShopApp;
using Services.Fabric;
using UnityEngine;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop
{
    public class ShopPresenter
    {
        private readonly ShopModel _shopModel;
        private readonly ShopItemFactory _factory;
        private readonly Transform _container;
        
        public ShopPresenter(ShopModel shopModel, ShopItemFactory factory, Transform container)
        {
            InvariantChecker.CheckObjectInvariant(shopModel, factory, container);
            
            _shopModel = shopModel;
            _factory = factory;
            _container = container;
        }

        public void InitializeItems()
        {
            foreach (var item in _shopModel.ShopItems)
            {
                _factory.Create(_container, item);
            }
        }
    }
}