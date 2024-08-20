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

        public event Action StateChanged;
        
        private StaffState _staffState;

        public void ChangeStaffState(StaffState staffState)
        {
            _staffState = staffState;
            
            _staffSelectionHandlerView.SetStaffState(_staffSelectionHandlerView.GetCurrentStaffType(), staffState);
        }
        
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