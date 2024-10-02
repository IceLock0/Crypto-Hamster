using ScriptableObjects;
using UnityEngine;
using Views.Phone.Apps.ShopApp.RepairKitShop;
using Zenject;

namespace Services.Fabric
{
    public class ShopItemFactory
    {
        private const string ShopItemView = "Shop/ItemView";

        private readonly DiContainer _container;

        private Object _shopItemView;

        public ShopItemFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _shopItemView = Resources.Load(ShopItemView);
        }

        public void Create(Transform parent, ShopItem shopItem)
        { 
            _container.InstantiatePrefabForComponent<ShopItemView>(_shopItemView, parent).GiveItem(shopItem);
        }
    }   
}