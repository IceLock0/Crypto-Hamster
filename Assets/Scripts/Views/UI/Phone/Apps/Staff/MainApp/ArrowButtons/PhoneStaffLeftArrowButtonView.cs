using System;
using Views.UI.ButtonUI;

namespace Views.UI.Phone.Apps.Staff.MainApp.ArrowButtons
{
    public class PhoneStaffLeftArrowButtonView : ButtonView
    {
        public event Action Clicked;
        
        protected override void ButtonClicked()
        {
            Clicked?.Invoke();
        }
    }
}