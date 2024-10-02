using System;
using Model.Inventory;
using Model.Wallet;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop
{
    public class ShopItemView : MonoBehaviour
    {
        private ShopItemPresenter _presenter;
        
        [Inject]
        public void Initialize(WalletModel walletModel, Button buyButton, Image itemImage, TMP_Text itemName, InventoryModel inventoryModel)
        {
            _presenter = new ShopItemPresenter(walletModel, buyButton, itemImage, itemName, inventoryModel);
        }

        public void GiveItem(ShopItem shopItem)
        {
            _presenter.GiveItem(shopItem);
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