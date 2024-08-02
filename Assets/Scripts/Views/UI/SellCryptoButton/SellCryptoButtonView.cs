using System;
using Views.UI.ButtonUI;

namespace Views.UI.SellButton
{
    public class SellCryptoButtonView : ButtonView
    {
        public event Action SellCryptoButtonClicked;
        protected override void ButtonClicked()
        {
            SellCryptoButtonClicked?.Invoke();
        }
    }
}