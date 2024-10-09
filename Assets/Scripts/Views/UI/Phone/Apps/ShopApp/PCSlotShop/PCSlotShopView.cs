using System;
using Model.ComputerCells;
using Presenters.Phone.Apps.PCSlotShop;
using Services.Fabric;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Phone.Apps.ShopApp.RepairKitShop.PCSlotShop
{
    public class PCSlotShopView : ShopView
    {
        [Inject]
        public void Initialize(ComputerCellsModel computerCellsModel, PCSLotShopItemFactory itemFactory)
        {
            Presenter = new PCSlotShopPresenter(computerCellsModel,ItemContainer, itemFactory);
        }
    }
}