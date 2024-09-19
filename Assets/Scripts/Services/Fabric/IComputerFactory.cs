using Enums;
using UnityEngine;

namespace Services.Fabric
{
    public interface IComputerFactory
    {
        public void Load();
        public Object Create(ComputerType type, Vector3 at, Transform parent = null);
    }
}