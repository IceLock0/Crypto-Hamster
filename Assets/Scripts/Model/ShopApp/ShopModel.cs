using System.Collections.Generic;
using ScriptableObjects;
using Utils;

namespace Model.ShopApp
{
    public abstract class ShopModel<T>
    {
        public ShopModel(List<T> shopItems)
        {
            InvariantChecker.CheckObjectInvariant(shopItems);
            ShopItems = shopItems;
        }
        
        public List<T> ShopItems { get; private set; }
    }
}