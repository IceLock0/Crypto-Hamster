using System.Collections.Generic;
using Enums;
using Model.Computer;
using Model.Electricity;
using ScriptableObjects;
using Utils;

namespace Presenters.ComputerElectricityConsumation
{
    public class ComputerElectricityConsumationPresenter
    {
        private ElectricityModel _electricityModel;
        private ComputerModel _computerModel;
        private List<ComputerConfig> _computerConfigs;
        public ComputerElectricityConsumationPresenter(ElectricityModel electricityModel, ComputerModel computerModel)
        {
            InvariantChecker.CheckObjectInvariant(electricityModel);

            _electricityModel = electricityModel;
            _computerModel = computerModel;
        }

        public void Enable()
        {
            _computerModel.ComputerTypeChanged += OnComputerTypeChanged;
        }

        public void Disable()
        {
            _computerModel.ComputerTypeChanged -= OnComputerTypeChanged;
        }

        private void OnComputerTypeChanged(ComputerType newComputerType)
        {
            
        }
    }
}