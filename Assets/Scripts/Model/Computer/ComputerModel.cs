using System;
using Enums;
using Utils;

namespace Model.Computer
{
    public class ComputerModel
    {
        public ComputerModel(int startComputerType, float startQuality)
        {
            ChangeType(startComputerType);
            ChangeQuality(startQuality);
        }

        public ComputerType ComputerType { get; private set; }
        public float Quality { get; private set; }

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
    }
}