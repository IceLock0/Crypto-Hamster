using System;

namespace Presenters.UI.ComputerControlPanel.BuyButton
{
    public class BuyButtonPresenter
    {
        public event Action OnBuyButtonClicked;
        
        public void BuyButtonClicked()
        {
            OnBuyButtonClicked?.Invoke();
        }
    }
}