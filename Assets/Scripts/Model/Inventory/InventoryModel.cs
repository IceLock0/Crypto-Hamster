using System;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace Model.Inventory
{
    public class InventoryModel
    {
        public InventoryModel()
        {
            Inventory = new Dictionary<Type, IList>();
        }
        
        public Dictionary<Type, IList> Inventory { get; private set; }

        public void AddItem<T>(T item)
        {
            InvariantChecker.CheckObjectInvariant(item);
            
            if (Inventory.ContainsKey(typeof(T)) == false)
                Inventory.Add(typeof(T), new List<T>()); 
            
            Inventory[typeof(T)].Add(item);
        }
    }
}