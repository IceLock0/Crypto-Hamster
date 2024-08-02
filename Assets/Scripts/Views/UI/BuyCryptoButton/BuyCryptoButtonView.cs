using System;
using Views.UI.ButtonUI;

namespace Views.UI.BuyCryptoButton
{
    public class BuyCryptoButtonView : ButtonView
    {
        public event Action BuyButtonClicked;
        protected override void ButtonClicked()
        {
            BuyButtonClicked?.Invoke();
        }
    }
}