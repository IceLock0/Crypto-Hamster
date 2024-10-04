using UnityEngine;

namespace ScriptableObjects
{
    public abstract class ShopItem : ScriptableObject
    {
        [SerializeField] private float _cost;
        [SerializeField] private Sprite _itemImage;
        [SerializeField] private string _itemName;

        public float Cost => _cost;
        public Sprite Image => _itemImage;
        public string ItemName => _itemName;
    }
}