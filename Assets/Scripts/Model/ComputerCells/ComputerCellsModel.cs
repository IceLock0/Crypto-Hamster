using System;
using System.Collections.Generic;
using System.Linq;
using Views.ComputerCell;

namespace Model.ComputerCells
{
    public class ComputerCellsModel
    {
        public ComputerCellsModel(List<ComputerCellView> computerCellViews)
        {
            ComputerCellViews = computerCellViews;
        }

        
        public List<ComputerCellView> ComputerCellViews { get; private set; }
        
        public event Action ActivateCellButtonPressed;
        public event Action CellBuyied;

        public ComputerCellView GetFirstActive()
        {
           return ComputerCellViews.FirstOrDefault(x => x.gameObject.activeSelf == false);
        }

        public void TryBuyCell()
        {
            ActivateCellButtonPressed?.Invoke();
        }

        public void BuyCell()
        {
            ComputerCellViews.FirstOrDefault(x => x.gameObject.activeSelf == false)?.gameObject.SetActive(true);
            CellBuyied?.Invoke();
        }
    }
}