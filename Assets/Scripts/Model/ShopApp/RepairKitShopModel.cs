using System.Collections.Generic;
using ScriptableObjects;
using Utils;

namespace Model.ShopApp
{
    public class RepairKitShopModel
    {
        public RepairKitShopModel(List<RepairKit> repairKits)
        {
            InvariantChecker.CheckObjectInvariant(repairKits);
            RepairKits = repairKits;
        }
        
        public List<RepairKit> RepairKits { get; private set; }
    }
}