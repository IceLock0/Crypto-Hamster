using System;
using Model.ComputerCells;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using Utils;
using Views.ComputerCell;

namespace Presenters.ComputerCellSpawner
{
    public class ComputerCellSpawnerPresenter
    {
        private readonly CostConfig _costConfig;
        private readonly WalletModel _walletModel;
        private readonly ComputerCellsModel _computerCellsModel;

        private ComputerCellView _disabledComputerCell;

        public ComputerCellSpawnerPresenter(ComputerCellsModel computerCellsModel, CostConfig costConfig, WalletModel walletModel)
        {
            InvariantChecker.CheckObjectInvariant(computerCellsModel, costConfig, walletModel);
            _computerCellsModel = computerCellsModel;
            _costConfig = costConfig;
            _walletModel = walletModel;
        }

        public void Enable()
        {
            _computerCellsModel.ActivateCellButtonPressed += OnActivateCellButtonPressed;
        }

        public void Disable()
        {
            _computerCellsModel.ActivateCellButtonPressed -= OnActivateCellButtonPressed;
        }

        private void OnActivateCellButtonPressed()
        {
            _disabledComputerCell = _computerCellsModel.GetFirstActive();
            TryBuySlot();
        }

        private void TryBuySlot()
        {
            if (_disabledComputerCell == null)
                throw new ArgumentNullException($"Max size of cells");
            if (_costConfig.PCSlotPrice > _walletModel.Currencies[typeof(Cash)].Amount)
                return;
            BuySlot();
        }

        private void BuySlot()
        {
            _walletModel.RemoveCurrency(typeof(Cash), _costConfig.PCSlotPrice);
            _computerCellsModel.BuyCell();
        }
    }
}