using System.Collections.Generic;
using ScriptableObjects;

namespace Model.ShopApp.RepairKitShop
{
    public class MusicShopModel : ShopModel<MusicItem>
    {
        public MusicShopModel(List<MusicItem> shopItems) : base(shopItems)
        {
        }
    }
}