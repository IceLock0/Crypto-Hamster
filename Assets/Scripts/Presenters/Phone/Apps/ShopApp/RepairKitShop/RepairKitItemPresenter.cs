using System;
using Model.Inventory;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using UnityEngine.UI;
using Utils;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop
{
    public class RepairKitItemPresenter
    {
        private readonly RepairKit _repairKit;
        private readonly Button _buyButton;
        private readonly WalletModel _walletModel;
        private readonly InventoryModel _inventoryModel;
        
        public RepairKitItemPresenter(RepairKit repairKit, WalletModel walletModel, Button buyButton, InventoryModel inventoryModel)
        {
            InvariantChecker.CheckObjectInvariant(repairKit,buyButton , walletModel, inventoryModel);

            _buyButton = buyButton;
            _repairKit = repairKit;
            _walletModel = walletModel;
            _inventoryModel = inventoryModel;
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
            _walletModel.RemoveCurrency(typeof(Cash), _repairKit.Cost);
            _inventoryModel.AddItem(_repairKit);
        }

        private bool IsEnoughGoldToBuy()
        {
            return _walletModel.Currencies[typeof(Cash)].Amount > _repairKit.Cost;
        }
    }
}