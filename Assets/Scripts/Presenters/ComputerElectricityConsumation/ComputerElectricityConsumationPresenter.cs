using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Model.Computer;
using Model.Electricity;
using ScriptableObjects;
using Utils;

namespace Presenters.ComputerElectricityConsumation
{

    public class ComputerElectricityConsumationPresenter
    {
        private readonly ElectricityModel _electricityModel;
        private readonly ComputerModel _computerModel;
        private readonly List<ComputerConfig> _computerConfigs;

        private ComputerConfig _currentComputerConfig;
        private ComputerConfig _newComputerConfig;
        
        public ComputerElectricityConsumationPresenter(ElectricityModel electricityModel, ComputerModel computerModel, List<ComputerConfig> computerConfigs)
        {
            InvariantChecker.CheckObjectInvariant(electricityModel, computerConfigs, computerModel);

            _electricityModel = electricityModel;
            _computerModel = computerModel;
            _computerConfigs = computerConfigs;
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
            _newComputerConfig = _computerConfigs.FirstOrDefault(x => x.ComputerType == newComputerType);
            if (_newComputerConfig == null)
                throw new ArgumentOutOfRangeException();
            IncreaseElectricityConsumation();
            _currentComputerConfig = _newComputerConfig;
        }

        private void IncreaseElectricityConsumation()
        {
            if (_newComputerConfig.ComputerType == ComputerType.Common)
                _electricityModel.IncreaseDecreaseValue(_newComputerConfig.ElectricityConsumation);
            else
                _electricityModel.IncreaseDecreaseValue(_newComputerConfig.ElectricityConsumation - _currentComputerConfig.ElectricityConsumation);
        }
    }

}