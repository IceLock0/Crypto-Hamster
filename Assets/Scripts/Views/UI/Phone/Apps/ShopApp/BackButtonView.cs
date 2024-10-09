using Model.ShopApp;
using Presenters.Phone.Apps.ShopApp.RepairKitShop.BackButton;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.UI.Phone.Apps.ShopApp
{
    public class BackButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private BackButtonPresenter _presenter;
        
        [Inject]
        public void Initialize(ShopAppsModel shopAppsModel)
        {
            _presenter = new(shopAppsModel, _button);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
            _presenter.Enable();
        }

        private void OnButtonClicked()
        {
            _presenter.DisableActiveScreen();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
            _presenter.Disable();
        }
    }
}