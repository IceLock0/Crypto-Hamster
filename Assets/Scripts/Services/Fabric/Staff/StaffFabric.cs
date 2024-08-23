using System;
using Enums.Staff;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Services.Fabric.Staff
{
    public class StaffFabric : IStaffFabric
    {
        private const string StaffPath = "Staff/";
        private const string AdminPath = StaffPath + "Admin";
        private const string SysAdminPath = StaffPath + "SysAdmin";
        private const string CleanerPath = StaffPath + "Cleaner";

        private readonly DiContainer _container;

        private Object _admin, _sysAdmin, _cleaner;

        public StaffFabric(DiContainer container)
        {
            _container = container;

            Load();
        }

        public void Load()
        {
            _admin = Resources.Load(AdminPath);
            _sysAdmin = Resources.Load(SysAdminPath);
            _cleaner = Resources.Load(CleanerPath);
        }
        
        public GameObject Create(StaffType staffType, Vector3 position, Quaternion rotation, Transform parent)
        {
            switch (staffType)
            {
                case StaffType.Admin:
                    return _container.InstantiatePrefab(_admin, position, Quaternion.identity, parent);
                case StaffType.SysAdmin:
                    return _container.InstantiatePrefab(_sysAdmin, position, Quaternion.identity, parent);
                case StaffType.Cleaner:
                    return _container.InstantiatePrefab(_cleaner, position, Quaternion.identity, parent);
                default:
                    throw new ArgumentException();
            }
        }
    }
}