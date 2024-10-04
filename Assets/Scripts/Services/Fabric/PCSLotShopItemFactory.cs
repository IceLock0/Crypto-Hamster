using Enums.Slot;
using UnityEngine;
using Zenject;

namespace Services.Fabric
{
    public class PCSLotShopItemFactory
    {
        private const string Available = "Shop/PCSlot/Available";
        private const string Unavailable = "Shop/PCSlot/Unavailable";

        private readonly DiContainer _container;

        private Object _available;
        private Object _unavailable;

        public PCSLotShopItemFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _available = Resources.Load(Available);
            _unavailable = Resources.Load(Unavailable);
        }

        public GameObject Create(Transform parent, PCSlotType type)
        {
            switch (type)
            {
                case PCSlotType.Available:
                    return _container.InstantiatePrefab(_available, parent);
                case PCSlotType.Unavailable:
                    return _container.InstantiatePrefab(_unavailable, parent);
            }

            return null;
        }
    }
}