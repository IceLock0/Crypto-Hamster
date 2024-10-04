using Model.ShopApp.RepairKitShop;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using Services.Fabric;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class RepairKitShopView : ShopView
    {
        [Inject]
        public void Initialize(RepairKitShopModel repairKitShopModel,ShopItemFactory factory)
        {
            Presenter = new RepairKitShopPresenter(repairKitShopModel, factory, ItemContainer);
        }
    }
}