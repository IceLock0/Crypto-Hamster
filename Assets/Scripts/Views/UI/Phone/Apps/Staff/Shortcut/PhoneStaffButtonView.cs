using UnityEngine;
using Views.UI.ButtonUI;

namespace Views.UI.Phone.Apps.Staff.Shortcut
{
    public class PhoneStaffButtonView : ButtonView
    {
        [SerializeField] private GameObject _staffPanelGO;
    
        protected override void ButtonClicked()
        {
            ChangeStaffPanelVisibility();
        }
    
        private void ChangeStaffPanelVisibility()
        {
            _staffPanelGO.SetActive(!_staffPanelGO.activeSelf);
        }
    
    }
}
