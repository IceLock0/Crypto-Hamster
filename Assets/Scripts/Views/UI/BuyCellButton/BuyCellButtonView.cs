using Model.ComputerCells;
using Views.UI.ButtonUI;
using Zenject;

namespace Views.UI.BuyCellButton
{
    public class BuyCellButtonView : ButtonView
    {
        private ComputerCellsModel _computerCellModel;

        [Inject]
        public void Initialize(ComputerCellsModel computerCellsModel)
        {
            _computerCellModel = computerCellsModel;
        }

        protected override void ButtonClicked()
        {
            _computerCellModel.TryBuyCell();
        }
    }
}