using Model.ShopApp;
using UnityEngine.UI;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop.BackButton
{
    public class BackButtonPresenter
    {
        private readonly ShopAppsModel _shopAppsModel;
        private readonly Button _button;

        public BackButtonPresenter(ShopAppsModel shopAppsModel, Button button)
        {
            InvariantChecker.CheckObjectInvariant(shopAppsModel,button);
            _shopAppsModel = shopAppsModel;
            _button = button;
        }

        public void Enable()
        {
            _shopAppsModel.ScreenEnabled += OnScreenEnabled;
            _button.gameObject.SetActive(false);
        }

        public void DisableActiveScreen()
        {
            _shopAppsModel.DisableScreen();
            _button.gameObject.SetActive(false);
        }

        public void Disable()
        {
            _shopAppsModel.ScreenEnabled -= OnScreenEnabled;
        }

        private void OnScreenEnabled()
        {
            _button.gameObject.SetActive(true);
        }
    }
}