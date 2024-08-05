using System;
using System.Collections.Generic;
using System.Linq;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using Utils;
using Views.ComputerCell;
using Views.UI.BuyCellButton;

namespace Presenters.ComputerCellSpawner
{
    public class ComputerCellSpawnerPresenter
    {
        private readonly List<ComputerCellView> _computerCellViews;
        private readonly BuyCellButtonView _buyCellButtonView;
        private readonly CostConfig _costConfig;
        private readonly WalletModel _walletModel;

        private ComputerCellView _disabledComputerCell;
        
        public ComputerCellSpawnerPresenter(List<ComputerCellView> computerCellViews, BuyCellButtonView buyCellButtonView, CostConfig costConfig, WalletModel walletModel)
        {
            InvariantChecker.CheckObjectInvariant(computerCellViews, buyCellButtonView, costConfig, walletModel);
            _computerCellViews = computerCellViews;
            _buyCellButtonView = buyCellButtonView;
            _costConfig = costConfig;
            _walletModel = walletModel;
        }

        public void Enable()
        {
            _buyCellButtonView.BuyCellButtonClicked += OnBuyCellButtonClicked;
        }

        public void Disable()
        {
            _buyCellButtonView.BuyCellButtonClicked -= OnBuyCellButtonClicked;
        }

        private void OnBuyCellButtonClicked()
        {
            _disabledComputerCell = _computerCellViews.FirstOrDefault(x => x.gameObject.activeSelf == false);
            TryBuySlot();
        }

        private void TryBuySlot()
        {
            if (_disabledComputerCell == null)
                throw new ArgumentNullException("Max size of cells");
            if (_costConfig.PCSlotPrice > _walletModel.Currencies[typeof(Cash)].Amount)
                throw new ArgumentOutOfRangeException("Not enough money");
            BuySlot();
        }

        private void BuySlot()
        {
            _walletModel.RemoveCurrency(typeof(Cash), _costConfig.PCSlotPrice);
            _disabledComputerCell.gameObject.SetActive(true);
        }
    }
}