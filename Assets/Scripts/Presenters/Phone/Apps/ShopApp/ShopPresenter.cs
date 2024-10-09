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
            InvariantChecker.CheckObjectInvariant(container);
            
            Factory = factory;
            Container = container;
        }

        public abstract void Enable();
        public abstract void Disable();

        public abstract void InitializeItems();
    }
}