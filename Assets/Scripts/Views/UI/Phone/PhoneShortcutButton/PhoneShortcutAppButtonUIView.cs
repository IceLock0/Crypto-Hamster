using UnityEngine;
using Views.UI.ButtonUI;

namespace Views.UI.Phone.Apps.Staff.Shortcut
{
    public class PhoneShortcutAppButtonUIView : ButtonView
    {
        [SerializeField] private GameObject _appGO;
    
        protected override void ButtonClicked()
        {
            ChangeStaffPanelVisibility();
        }
    
        private void ChangeStaffPanelVisibility()
        {
            _appGO.SetActive(!_appGO.activeSelf);
        }
    
    }
}
