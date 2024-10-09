using Views.Phone.Apps.ShopApp.RepairKitShop;

namespace Views.UI.Phone.Apps.ShopApp.ShopTypesButtons.Types
{
    public class EnableRepairKitShopButtonView : EnableShopButtonView
    {
        protected override void EnableScreen()
        {
            Presenter.EnableScreen(typeof(RepairKitShopView));
        }
    }
}