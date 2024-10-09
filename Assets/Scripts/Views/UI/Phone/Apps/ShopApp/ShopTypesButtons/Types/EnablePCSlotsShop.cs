using Views.Phone.Apps.ShopApp.RepairKitShop.PCSlotShop;

namespace Views.UI.Phone.Apps.ShopApp.ShopTypesButtons.Types
{
    public class EnablePCSlotsShop : EnableShopButtonView
    {
        protected override void EnableScreen()
        {
            Presenter.EnableScreen(typeof(PCSlotShopView));
        }
    }
}