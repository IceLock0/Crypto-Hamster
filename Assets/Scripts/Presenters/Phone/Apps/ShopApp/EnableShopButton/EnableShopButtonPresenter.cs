using System;
using Model.ShopApp;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop.EnableShopButton
{
    public class EnableShopButtonPresenter
    {
        private readonly ShopAppsModel _model;

        public EnableShopButtonPresenter(ShopAppsModel model)
        {
            InvariantChecker.CheckObjectInvariant(model);

            _model = model;
        }

        public void EnableScreen(Type screenType)
        {
            _model.EnableScreen(screenType);
        }
    }
}