using Views.Phone.Apps.ShopApp.RepairKitShop;

namespace Views.UI.Phone.Apps.ShopApp.ShopTypesButtons.Types
{
    public class EnableMusicShopButtonView: EnableShopButtonView
    {
        protected override void EnableScreen()
        {
            Presenter.EnableScreen(typeof(MusicShopView));
        }
    }
}