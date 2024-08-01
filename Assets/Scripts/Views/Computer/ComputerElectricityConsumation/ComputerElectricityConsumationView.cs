using Presenters.ComputerElectricityConsumation;
using UnityEngine;
using Utils;
using Zenject;

namespace Views.Computer.ComputerElectricityConsumation
{

    public class ComputerElectricityConsumationView : MonoBehaviour
    {
        private ComputerElectricityConsumationPresenter _presenter;
        
        [Inject]
        public void Initialize(ComputerElectricityConsumationPresenter presenter)
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