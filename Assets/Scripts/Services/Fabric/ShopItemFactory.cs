using ScriptableObjects;
using UnityEngine;
using Views.Phone.Apps.ShopApp.RepairKitShop;
using Zenject;

namespace Services.Fabric
{
    public class ShopItemFactory
    {
        private const string RepairKitItem = "Shop/RepairKitItem";
        private const string MusicItem = "Shop/MusicItem";

        private readonly DiContainer _container;

        private Object _repairKitItem;
        private Object _musicItem;

        public ShopItemFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _repairKitItem = Resources.Load(RepairKitItem);
            _musicItem = Resources.Load(MusicItem);
        }

        public void Create<T>(Transform parent, T shopItem) where T: ShopItem
        {
            if(typeof(T) == typeof(RepairKit))
                _container.InstantiatePrefabForComponent<RepairKitItemView>(_repairKitItem, parent).GiveItem(shopItem as RepairKit);
            else if(typeof(T) == typeof(MusicItem))
                _container.InstantiatePrefabForComponent<MusicItemView>(_musicItem, parent).GiveItem(shopItem as MusicItem);
        }
    }   
}