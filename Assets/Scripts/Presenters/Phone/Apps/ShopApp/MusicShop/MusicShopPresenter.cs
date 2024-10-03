using Model.ShopApp.RepairKitShop;
using Services.Fabric;
using UnityEngine;

namespace Presenters.Phone.Apps.ShopApp.RepairKitShop.MusicShop
{
    public class MusicShopPresenter : ShopPresenter
    {
        private readonly MusicShopModel _musicShopModel;

        public MusicShopPresenter(MusicShopModel musicShopModel, ShopItemFactory factory, Transform container) : base(factory, container)
        {
            _musicShopModel = musicShopModel;
        }

        public override void InitializeItems()
        {
            foreach (var item in _musicShopModel.ShopItems)
            {
                Factory.Create(Container, item);
            }
        }
    }
}