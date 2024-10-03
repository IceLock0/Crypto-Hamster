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
    public abstract class ShopItemView<T> : MonoBehaviour where T: ShopItem
    {
        private ShopItemPresenter<T> _presenter;
        
        [Inject]
        public void Initialize(WalletModel walletModel, Button buyButton, Image itemImage, TMP_Text itemName, InventoryModel inventoryModel)
        {
            _presenter = new ShopItemPresenter<T>(walletModel, buyButton, itemImage, itemName, inventoryModel);
        }

        public void GiveItem(T shopItem)
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