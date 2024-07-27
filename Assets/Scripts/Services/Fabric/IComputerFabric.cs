using Enums;
using UnityEngine;

namespace Services.Fabric
{
    public interface IComputerFabric
    {
        public void Load();
        public Object Create(ComputerType type, Vector3 at, Transform parent = null);
    }
}