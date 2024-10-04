using UnityEngine;
using Views.UI.ButtonUI;

public class PhoneShortcutButtonView : ButtonView
{
    [SerializeField] private GameObject _phoneGO;
    
    protected override void ButtonClicked()
    {
        ChangePhoneVisibility();
    }

    private void ChangePhoneVisibility()
    {
        _phoneGO.SetActive(!_phoneGO.activeSelf);
    }
}
