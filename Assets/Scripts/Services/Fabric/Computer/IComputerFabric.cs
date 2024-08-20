using Enums;
using UnityEngine;

namespace Services.Fabric
{
    public interface IComputerFabric : IFabric
    {
        public Object Create(ComputerType type, Vector3 at, Transform parent = null);
    }
}