using ScriptableObjects;
using UnityEngine;
using Views.Phone.Apps.ShopApp.RepairKitShop;
using Zenject;

namespace Services.Fabric
{
    public class RepairKitItemFactory
    {
        private const string RepairKitItemView = "RepairKit/RepairKitItem";

        private readonly DiContainer _container;

        private Object _repairKitItemView;

        public RepairKitItemFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _repairKitItemView = Resources.Load(RepairKitItemView);
        }

        public object Create(Transform parent, RepairKit repairKit)
        {
            return _container.InstantiatePrefabForComponent<RepairKitItemView>(_repairKitItemView, parent,new object[] {repairKit});
        }
    }   
}