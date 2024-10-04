using Enums;
using UnityEngine;

namespace Services.Fabric
{ 
    public interface IComputerFactory : IFactory
    {
        public Object Create(ComputerType type, Vector3 at, Transform parent = null);
    }
}