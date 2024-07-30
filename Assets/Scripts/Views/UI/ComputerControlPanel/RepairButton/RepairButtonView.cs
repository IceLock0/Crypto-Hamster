using System;
using Views.UI.ButtonUI;

namespace Views.UI.ComputerControlPanel.RepairButton
{
    public class RepairButtonView : ButtonView
    {
        public event Action RepairButtonClicked;
        
        protected override void ButtonClicked()
        {
            RepairButtonClicked?.Invoke();
        }
    }
}