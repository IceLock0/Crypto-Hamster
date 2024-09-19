using System;
using Model.Inventory;
using Model.Wallet;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class RepairKitItemView : MonoBehaviour
    {
        [SerializeField] private Button _buyButton;
        private RepairKitItemPresenter _presenter;
        
        [Inject]
        public void Initialize(WalletModel walletModel, RepairKit repairKit, InventoryModel inventoryModel)
        {
            _presenter = new RepairKitItemPresenter(repairKit, walletModel, _buyButton, inventoryModel);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}