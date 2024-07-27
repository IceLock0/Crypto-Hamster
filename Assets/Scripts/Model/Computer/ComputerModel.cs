using System;
using Enums;

namespace Model.Computer
{
    public class ComputerModel
    {
        public ComputerModel()
        {
            ChangeType(0);
        }

        public ComputerType ComputerType;
        public event Action<ComputerType> ComputerTypeChanged;

        public void ChangeType(int typeNum)
        {
            if (!Enum.IsDefined(typeof(ComputerType), typeNum))
                throw new ArgumentOutOfRangeException();
            ComputerType = (ComputerType) typeNum;
            ComputerTypeChanged?.Invoke(ComputerType);
        }
    }
}