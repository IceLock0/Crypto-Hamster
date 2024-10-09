using System;
using Views.UI.ButtonUI;

namespace Views.UI.Phone.Apps.HomeButton
{
    public class HomeButtonView : ButtonView
    {
        public event Action HomeButtonClicked;
        protected override void ButtonClicked()
        {
            HomeButtonClicked?.Invoke();
        }
    }
}