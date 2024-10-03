using System;
using Presenters.ComputerTriggerZone;
using UnityEngine;
using Views.ComputerServant;

namespace Views.ComputerTriggerZone
{
    public class TriggerZoneView : MonoBehaviour
    {
        private TriggerZonePresenter _presenter;
        
        private void Awake()
        {
            _presenter = new TriggerZonePresenter();
        }
        
        public event Action OnPlayerEnteredServiceZone;
        public event Action OnPlayerExitServiceZone;

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IComputerServant servant))
            {
                OnPlayerEnteredServiceZone?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IComputerServant servant))
            {
                OnPlayerExitServiceZone?.Invoke();
            }
        }
    }
}