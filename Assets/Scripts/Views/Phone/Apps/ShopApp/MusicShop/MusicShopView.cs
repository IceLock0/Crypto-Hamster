using Model.ShopApp.RepairKitShop;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using Presenters.Phone.Apps.ShopApp.RepairKitShop.MusicShop;
using Services.Fabric;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class MusicShopView : ShopView
    {
        [Inject]
        public void Initialize(MusicShopModel musicShopModel,ShopItemFactory factory)
        {
            Presenter = new MusicShopPresenter(musicShopModel, factory, ItemContainer);
        }
    }
}