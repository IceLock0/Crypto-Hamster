using Presenters.Computer;
using Presenters.ComputerCryptoChanger;
using Presenters.ComputerElectricityConsumation;
using Presenters.ComputerMiner;
using Presenters.ComputerQualityChange;
using Presenters.ComputerRepair;
using UnityEngine;
using Zenject;

namespace Views.Computer.ComputerBuilder
{
    public class ComputerBuilderView : MonoBehaviour
    {
        private ComputerBuilderPresenter _presenter;

        [Inject]
        public void Initialize(ComputerBuilderPresenter presenter)
        {
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

        public ComputerBuilderPresenter GetPresenter() => _presenter;
    }
}