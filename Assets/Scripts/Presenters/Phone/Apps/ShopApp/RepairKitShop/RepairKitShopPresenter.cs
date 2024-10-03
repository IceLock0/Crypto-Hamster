using Model.ShopApp.RepairKitShop;
using Services.Fabric;
using UnityEngine;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop
{
    public class RepairKitShopPresenter : ShopPresenter
    {
        private readonly RepairKitShopModel _repairKitShopModel;

        public RepairKitShopPresenter(RepairKitShopModel repairKitShopModel, ShopItemFactory factory, Transform container) : base(factory, container)
        {
            _repairKitShopModel = repairKitShopModel;
        }

        public override void InitializeItems()
        {
            foreach (var item in _repairKitShopModel.ShopItems)
            {
                Factory.Create(Container, item);
            }
        }
    }
}