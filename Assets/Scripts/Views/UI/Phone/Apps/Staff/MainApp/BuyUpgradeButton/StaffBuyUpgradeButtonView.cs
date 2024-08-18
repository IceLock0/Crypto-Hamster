using System;
using Enums.Staff;
using UnityEngine;
using Views.UI.ButtonUI;

namespace Views.UI.Phone.Apps.Staff.MainApp
{
    public class StaffBuyUpgradeButtonView : ButtonView
    {
        [SerializeField] private StaffSelectionHandlerView _staffSelectionHandlerView;
        
        public event Action<StaffType> BuyClicked;
        public event Action UpgradeClicked;

        private StaffState _staffState;
        
        protected override void ButtonClicked()
        {
            _staffState = _staffSelectionHandlerView.GetCurrentStaffState();

            if (_staffState == StaffState.NotBought)
                BuyClicked?.Invoke(_staffSelectionHandlerView.GetCurrentStaffType());
            else
                UpgradeClicked?.Invoke();
        }
    }
}