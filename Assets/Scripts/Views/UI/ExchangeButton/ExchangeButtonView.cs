using System;
using Views.UI.ButtonUI;

namespace Views.UI.ExchangeButton
{
    public class ExchangeButtonView : ButtonView
    {
        public event Action ExchangeButtonClicked;
        protected override void ButtonClicked()
        {
            ExchangeButtonClicked?.Invoke();
        }
    }
}