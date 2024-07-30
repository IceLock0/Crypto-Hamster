using System;
using Enums;
using Utils;

namespace Model.Computer
{
    public class ComputerModel
    {
        public ComputerModel(int startComputerType, float startQuality, float startThermalQuality)
        {
            ChangeType(startComputerType);
            ChangeQuality(startQuality);
            ChangeThermalQuality(startThermalQuality);
        }

        public ComputerType ComputerType { get; private set; }
        public float Quality { get; private set; }
        public float ThermalQuality { get; private set; }
        
        //public event Action<float> QualityChanged;
        //public event Action<float> ThermalQualityChanged;
        //Ивенты на изменение кьюалы компа для перевычисления кол-ва начисляемой валюты
        
        public event Action<ComputerType> ComputerTypeChanged;

        public void ChangeType(int typeNum)
        {
            if (!Enum.IsDefined(typeof(ComputerType), typeNum))
                throw new ArgumentOutOfRangeException();
            ComputerType = (ComputerType) typeNum;
            ComputerTypeChanged?.Invoke(ComputerType);
        }

        public void ChangeQuality(float targetQuality)
        {
            InvariantChecker.CheckPercentageInvariant(targetQuality);
            Quality = targetQuality;
        }

        public void ChangeThermalQuality(float targetThermalQuality)
        {
            InvariantChecker.CheckPercentageInvariant(targetThermalQuality);
            ThermalQuality = targetThermalQuality;
        }
        
    }
}