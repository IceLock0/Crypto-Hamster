using System;
using Presenters.ComputerRepair;
using UnityEngine;
using Utils;
using Zenject;

namespace Views.Computer.ComputerRepair
{

    public class ComputerRepairView : MonoBehaviour
    {
        private ComputerRepairPresenter _presenter;
        
        [Inject]
        public void Initialize(ComputerRepairPresenter presenter)
        {
            InvariantChecker.CheckObjectInvariant(presenter);
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }

}