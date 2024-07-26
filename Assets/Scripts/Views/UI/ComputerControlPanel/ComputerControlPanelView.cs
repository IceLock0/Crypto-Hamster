using System;
using System.Collections.Generic;
using Presenters.UI.ComputerControlPanel;
using UnityEngine;
using Views.ComputerTriggerZone;

namespace Views.UI.ComputerControlPanel
{
    public class ComputerControlPanelView : MonoBehaviour
    {
        [SerializeField] private TriggerZoneView _zoneView;
        [SerializeField] private ControlPanelPlug _controlPanelUI;

        private ComputerControlPanelPresenter _presenter;
        private void Awake()
        {
            _presenter = new ComputerControlPanelPresenter(_zoneView, _controlPanelUI);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();;
        }
    }
}