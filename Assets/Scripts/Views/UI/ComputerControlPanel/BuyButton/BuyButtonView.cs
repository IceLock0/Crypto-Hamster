using System;
using Views.UI.ButtonUI;

namespace Views.UI.ComputerControlPanel.BuyButton
{
    public class BuyButtonView : ButtonView
    {
        public event Action BuyComputerButtonClicked;

        protected override void ButtonClicked()
        {
            BuyComputerButtonClicked?.Invoke();
        }
    }
}