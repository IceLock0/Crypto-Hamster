using System.Collections.Generic;
using ScriptableObjects;
using Utils;

namespace Model.ShopApp
{
    public class ShopModel
    {
        public ShopModel(List<ShopItem> shopItems)
        {
            InvariantChecker.CheckObjectInvariant(shopItems);
            ShopItems = shopItems;
        }
        
        public List<ShopItem> ShopItems { get; private set; }
    }
}