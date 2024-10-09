using System;
using Model.ShopApp;
using Presenters.Phone.Apps.ShopApp.RepairKitShop.EnableShopButton;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.UI.Phone.Apps.ShopApp.ShopTypesButtons
{
    public abstract class EnableShopButtonView : MonoBehaviour
    {
        private Button _button;
        
        protected EnableShopButtonPresenter Presenter;


        [Inject]
        public void Initialize(ShopAppsModel model)
        {
            Presenter = new(model);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(EnableScreen);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(EnableScreen);
        }

        protected abstract void EnableScreen();
    }
}