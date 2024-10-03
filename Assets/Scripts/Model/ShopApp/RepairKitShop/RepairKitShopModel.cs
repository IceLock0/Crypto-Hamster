using System.Collections.Generic;
using ScriptableObjects;

namespace Model.ShopApp.RepairKitShop
{
    public class RepairKitShopModel : ShopModel<RepairKit>
    {
        public RepairKitShopModel(List<RepairKit> shopItems) : base(shopItems)
        {
        }
    }
}