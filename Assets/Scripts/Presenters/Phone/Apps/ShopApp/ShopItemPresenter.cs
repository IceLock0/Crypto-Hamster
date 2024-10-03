using System;
using Model.Inventory;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using TMPro;
using UnityEngine.UI;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop
{
    public class ShopItemPresenter<T> where T: ShopItem
    {
        private readonly Button _buyButton;
        private readonly WalletModel _walletModel;
        private readonly InventoryModel _inventoryModel;
        private readonly Image _itemImage;
        private readonly TMP_Text _itemName;
        
        private T _shopItem;

        public ShopItemPresenter(WalletModel walletModel, Button buyButton, 
            Image itemImage, TMP_Text itemName, InventoryModel inventoryModel)
        {
            InvariantChecker.CheckObjectInvariant( buyButton, walletModel, itemImage, itemName,
                inventoryModel);

            _buyButton = buyButton;
            _walletModel = walletModel;
            _inventoryModel = inventoryModel;
            _itemImage = itemImage;
            _itemName = itemName;
        }

        public void Enable()
        {
            _walletModel.AmountChanged += OnWalletAmountChanged;
            _buyButton.onClick.AddListener(BuyButtonClicked);
        }

        public void Disable()
        {
            _walletModel.AmountChanged -= OnWalletAmountChanged;
            _buyButton.onClick.RemoveListener(BuyButtonClicked);
        }

        private void UpdateVisual()
        {
            _itemImage.sprite = _shopItem.Image;
            _itemName.text = _shopItem.ItemName;
        }

        private void OnWalletAmountChanged(Type currencyType)
        {
            if (currencyType != typeof(Cash))
                return;
            TryChangeBuyButtonState();
        }

        private void TryChangeBuyButtonState()
        {
            _buyButton.interactable = IsEnoughGoldToBuy();
        }

        private void BuyButtonClicked()
        {
            if (IsEnoughGoldToBuy() == false)
                return;
            _walletModel.RemoveCurrency(typeof(Cash), _shopItem.Cost);
            _inventoryModel.AddItem(_shopItem);
        }

        private bool IsEnoughGoldToBuy()
        {
            return _walletModel.Currencies[typeof(Cash)].Amount > _shopItem.Cost;
        }

        public void GiveItem(T shopItem)
        {
            _shopItem = shopItem;
            UpdateVisual();
        }
    }
}