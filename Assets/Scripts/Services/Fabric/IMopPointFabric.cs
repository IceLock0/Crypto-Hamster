using UnityEngine;

namespace Services.Fabric
{
    public interface IMopPointFabric
    {
        public GameObject Create(Vector3 at, Quaternion rotation, Transform parent = null);
    }
}