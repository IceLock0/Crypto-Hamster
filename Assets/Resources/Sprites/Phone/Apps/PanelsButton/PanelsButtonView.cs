using UnityEngine;
using Views.UI.ButtonUI;

namespace Views.Phone.Apps.PanelsButton
{
    public class PanelsButtonView : ButtonView
    {
        [SerializeField] private GameObject _panelToOpen;
        
        protected override void ButtonClicked()
        {
            _panelToOpen.SetActive(true);
        }
    }
}