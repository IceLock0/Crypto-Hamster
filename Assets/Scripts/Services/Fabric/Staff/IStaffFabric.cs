using Enums.Staff;
using UnityEngine;

namespace Services.Fabric.Staff
{
    public interface IStaffFabric : IFabric
    {
        public GameObject Create(StaffType staffType, Vector3 position, Quaternion rotation, Transform parent);
    }
}