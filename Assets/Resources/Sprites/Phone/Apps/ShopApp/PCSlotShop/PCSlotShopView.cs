using System;
using Model.ComputerCells;
using Presenters.Phone.Apps.PCSlotShop;
using Services.Fabric;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop.PCSlotShop
{
    public class PCSlotShopView : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private Transform _container;
        
        private PCSlotShopPresenter _presenter;

        [Inject]
        public void Initialize(ComputerCellsModel computerCellsModel, PCSLotShopItemFactory itemFactory)
        {
            _presenter = new(computerCellsModel,_container, itemFactory);
        }

        private void Start()
        {
            _presenter.InitializeItems();
        }

        private void OnEnable()
        {
            _presenter.Enable();
            _homeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }

        private void OnDisable()
        {
            _presenter.Disable();
            _homeButton.onClick.RemoveListener(() => gameObject.SetActive(false));
        }
    }
}