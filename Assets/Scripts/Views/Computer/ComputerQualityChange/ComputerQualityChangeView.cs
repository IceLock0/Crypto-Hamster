using Presenters.Computer.ComputerQualityChange;
using Presenters.ComputerRepair;
using UnityEngine;
using Utils;
using Zenject;

namespace Views.Computer.ComputerQualityChange
{

    public class ComputerQualityChangeView : MonoBehaviour
    {
        private ComputerQualityChangePresenter _presenter;
        
        [Inject]
        public void Initialize(ComputerQualityChangePresenter presenter)
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