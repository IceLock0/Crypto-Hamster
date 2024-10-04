using Enums;
using UnityEngine;

namespace Services.Fabric
{
<<<<<<<< HEAD:Assets/Scripts/Services/Fabric/IComputerFactory.cs
    public interface IComputerFactory
========
    public interface IComputerFabric : IFabric
>>>>>>>> origin/BillsPhoneApp:Assets/Scripts/Services/Fabric/Computer/IComputerFabric.cs
    {
        public Object Create(ComputerType type, Vector3 at, Transform parent = null);
    }
}