using System;
using Views.UI.ButtonUI;

namespace Views.UI.BuyCellButton
{
    public class BuyCellButtonView : ButtonView
    {
        public event Action BuyCellButtonClicked;

        protected override void ButtonClicked()
        {
            BuyCellButtonClicked?.Invoke();
        }
    }
}