using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using Views.ComputerCell;
using Views.UI.BuyCellButton;

namespace Presenters.ComputerCellSpawner
{
    public class ComputerCellSpawnerPresenter
    {
        private readonly List<ComputerCellView> _computerCellViews;
        private readonly BuyCellButtonView _buyCellButtonView;
        
        public ComputerCellSpawnerPresenter(List<ComputerCellView> computerCellViews, BuyCellButtonView buyCellButtonView)
        {
            InvariantChecker.CheckObjectInvariant(computerCellViews,buyCellButtonView);
            _computerCellViews = computerCellViews;
            _buyCellButtonView = buyCellButtonView;
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
            var disabledComputerCell = _computerCellViews.FirstOrDefault(x => x.gameObject.activeSelf == false);
            if (disabledComputerCell == null)
                throw new ArgumentNullException("Max size of cells");
            disabledComputerCell.gameObject.SetActive(true);
        }
    }
}