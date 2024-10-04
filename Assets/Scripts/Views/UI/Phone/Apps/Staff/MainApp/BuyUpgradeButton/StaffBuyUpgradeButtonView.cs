using System;
using Enums.Staff;
using UnityEngine;
using Views.UI.ButtonUI;

namespace Views.UI.Phone.Apps.Staff.MainApp
{
    public class StaffBuyUpgradeButtonView : ButtonView
    {
        [SerializeField] private StaffSelectionHandlerView _staffSelectionHandlerView;
        
        public event Action<StaffType> Clicked;
        
        protected override void ButtonClicked()
        {
            Clicked?.Invoke(_staffSelectionHandlerView.GetCurrentStaffType());
        }
    }
}