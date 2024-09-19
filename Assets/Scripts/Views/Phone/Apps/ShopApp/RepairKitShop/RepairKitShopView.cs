using System;
using Model.ShopApp;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using Services.Fabric;
using UnityEngine;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class RepairKitShopView : MonoBehaviour
    {
        [SerializeField] private Transform _itemContainer;
        private RepairKitShopPresenter _presenter;

        [Inject]
        public void Initialize(RepairKitShopModel kitShopModel, RepairKitItemFactory factory)
        {
            _presenter = new RepairKitShopPresenter(kitShopModel, factory, _itemContainer);
        }

        private void Start()
        {
            _presenter.InitializeItems();
        }
    }
}