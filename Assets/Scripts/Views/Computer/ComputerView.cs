using Presenters.Computer;
using Presenters.ComputerCryptoChanger;
using Presenters.ComputerElectricityConsumation;
using Presenters.ComputerMiner;
using Presenters.ComputerQualityChange;
using Presenters.ComputerRepair;
using UnityEngine;
using Zenject;

namespace Views.Computer
{
    public class ComputerView : MonoBehaviour
    {
        private ComputerPresenter _computerPresenter;
        private ComputerQualityChangePresenter _computerQualityChangePresenter;
        private ComputerRepairPresenter _computerRepairPresenter;
        private ComputerMinerPresenter _computerMinerPresenter;
        private ComputerCryptoChangePresenter _computerCryptoChangePresenter;
        private ComputerElectricityConsumationPresenter _computerElectricityConsumationPresenter;

        [Inject]
        public void Initialize(ComputerPresenter computerPresenter, ComputerRepairPresenter computerRepairPresenter, ComputerQualityChangePresenter computerQualityChangePresenter, ComputerMinerPresenter computerMinerPresenter, ComputerCryptoChangePresenter computerCryptoChangePresenter, ComputerElectricityConsumationPresenter computerElectricityConsumationPresenter)
        {
            _computerPresenter = computerPresenter;
            _computerRepairPresenter = computerRepairPresenter;
            _computerQualityChangePresenter = computerQualityChangePresenter;
            _computerMinerPresenter = computerMinerPresenter;
            _computerCryptoChangePresenter = computerCryptoChangePresenter;
            _computerElectricityConsumationPresenter = computerElectricityConsumationPresenter;
        }

        private void OnEnable()
        {
            _computerPresenter.Enable();
            _computerQualityChangePresenter.Enable();
            _computerRepairPresenter.Enable();
            _computerMinerPresenter.Enable();
            _computerCryptoChangePresenter.Enable();
            _computerElectricityConsumationPresenter.Enable();
        }

        private void OnDisable()
        {
            _computerPresenter.Disable();
            _computerQualityChangePresenter.Disable();
            _computerRepairPresenter.Disable();
            _computerMinerPresenter.Disable();
            _computerCryptoChangePresenter.Disable();
            _computerElectricityConsumationPresenter.Disable();
        }

        public ComputerPresenter GetPresenter() => _computerPresenter;
    }
}