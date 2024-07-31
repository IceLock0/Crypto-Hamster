using System;
using UnityEngine;
using Enums;
using Utils;

namespace Model.Computer
{
    public class ComputerModel
    {
        public ComputerModel(int startComputerType, float startQuality, float startThermalQuality, Vector3 computerPosition)
        {
            ChangeType(startComputerType);
            ChangeQuality(startQuality);
            ChangeThermalQuality(startThermalQuality);

            ComputerPosition = computerPosition;
        }

        public ComputerType ComputerType { get; private set; }
        public float Quality { get; private set; }
        public float ThermalQuality { get; private set; }

        public Vector3 ComputerPosition { get; private set; }

        public event Action<ComputerType> ComputerTypeChanged;

        public event Action<ComputerModel> QualityChanged;

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

            QualityChanged?.Invoke(this);
        }

        public void ChangeThermalQuality(float targetThermalQuality)
        {
            InvariantChecker.CheckPercentageInvariant(targetThermalQuality);
            ThermalQuality = targetThermalQuality;
        }
        
    }
}