using System.Collections.Generic;
using System.Linq;
using Enums.Slot;
using Model.ComputerCells;
using Presenters.Phone.Apps.ShopApp.RepairKitShop;
using Services.Fabric;
using UnityEngine;
using Utils;
using Views.Phone.Apps.ShopApp.RepairKitShop.PCSlotShop;

namespace Presenters.Phone.Apps.PCSlotShop
{
    public class PCSlotShopPresenter : ShopPresenter
    {
        private readonly ComputerCellsModel _computerCellsModel;
        private readonly Transform _container;
        private readonly PCSLotShopItemFactory _itemFactory;
        private readonly List<SlotView> _items;


        public PCSlotShopPresenter(ComputerCellsModel computerCellsModel, Transform container,
            PCSLotShopItemFactory itemFactory) : base(null, container)
        {
            InvariantChecker.CheckObjectInvariant(computerCellsModel, container, itemFactory);

            _computerCellsModel = computerCellsModel;
            _container = container;
            _itemFactory = itemFactory;
            _items = new();
        }

        public override void Enable()
        {
            _computerCellsModel.CellBuyied += OnCellBuyied;
        }

        public override void Disable()
        {
            _computerCellsModel.CellBuyied -= OnCellBuyied;
        }

        public override void InitializeItems()
        {
            foreach (var cell in _computerCellsModel.ComputerCellViews)
            {
                _items.Add(_itemFactory.Create(_container, cell.gameObject.activeSelf? PCSlotType.Unavailable : PCSlotType.Available).GetComponent<SlotView>());
            }
        }

        private void OnCellBuyied()
        {
            _items.First(item => item.Type == PCSlotType.Available).Buy();
        }
    }
}