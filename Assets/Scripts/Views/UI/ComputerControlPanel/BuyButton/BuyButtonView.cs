using System;
using Presenters.UI.ComputerControlPanel.BuyButton;
using Views.UI.ButtonUI;
using Zenject;

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