using UnityEngine;
using Utils;
using Views.ComputerTriggerZone;
using Views.UI.ComputerControlPanel;

namespace Presenters.UI.ComputerControlPanel
{
    public class ComputerControlPanelPresenter
    {
        private TriggerZoneView _zoneView;
        private ControlPanelPlug _controlPanelUI;

        public ComputerControlPanelPresenter(TriggerZoneView zoneView, ControlPanelPlug controlPanelUI)
        {
            InvariantChecker.CheckObjectInvariant(zoneView, controlPanelUI);

            _zoneView = zoneView;
            _controlPanelUI = controlPanelUI;
        }

        public void Enable()
        {
            _zoneView.OnPlayerEnteredServiceZone += PlayerEnteredServiceZone;
            _zoneView.OnPlayerExitServiceZone += PlayerExitServiceZone;
        }

        public void Disable()
        {
            _zoneView.OnPlayerEnteredServiceZone -= PlayerEnteredServiceZone;
            _zoneView.OnPlayerExitServiceZone -= PlayerExitServiceZone;
        }


        private void PlayerEnteredServiceZone()
        {
            Show();
        }
        private void PlayerExitServiceZone()
        {
            Hide();
        }

        private void Show()
        {
            _controlPanelUI.gameObject.SetActive(true);
        }

        private void Hide()
        {
            _controlPanelUI.gameObject.SetActive(false);
        }
    }
}