using Model.ShopApp;
using Services.Fabric;
using UnityEngine;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop
{
    public abstract class ShopPresenter
    {
        protected readonly ShopItemFactory Factory;
        protected readonly Transform Container;
        
        public ShopPresenter(ShopItemFactory factory, Transform container)
        {
            InvariantChecker.CheckObjectInvariant(factory, container);
            
            Factory = factory;
            Container = container;
        }

        public abstract void InitializeItems();
    }
}