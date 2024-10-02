using System;
using Model.ShopApp;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using Services.Fabric;
using UnityEngine;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class ShopView : InShopShopView
    {
        [SerializeField] private Transform _itemContainer;
        
        private ShopPresenter _presenter;

        [Inject]
        public void Initialize(ShopModel shopModel, ShopItemFactory factory)
        {
            _presenter = new ShopPresenter(shopModel, factory, _itemContainer);
        }

        private void Start()
        {
            _presenter.InitializeItems();
        }
    }
}