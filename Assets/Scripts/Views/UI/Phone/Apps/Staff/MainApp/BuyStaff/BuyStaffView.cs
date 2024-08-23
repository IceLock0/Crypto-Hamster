    using System;
using System.Collections.Generic;
using Enums.Staff;
using Model.Wallet;
using Presenters.StaffTransaction;
    using Presenters.StaffTransaction.Buy;
    using ScriptableObjects;
using Services.Fabric.Staff;
using UnityEngine;
using Zenject;

namespace Views.UI.Phone.Apps.Staff.MainApp.BuyStaff
{
    public class BuyStaffView : MonoBehaviour
    {
        [SerializeField] private StaffBuyUpgradeButtonView _buyButton;

        private BuyStaffPresenter _presenter;
        
        [Inject]
        public void Initialize(WalletModel walletModel, IStaffFabric staffFabric, List<SysAdminConfig> sysAdminConfigs, List<CleanerConfig> cleanerConfigs)
        {
            _presenter = new BuyStaffPresenter(walletModel, staffFabric, sysAdminConfigs, cleanerConfigs);
        }

        private void OnEnable()
        {
            _buyButton.Clicked += ProcessBuyUpgradeClick;
        }
        
        private void OnDisable()
        {
            _buyButton.Clicked -= ProcessBuyUpgradeClick;
        }
        
        private void ProcessBuyUpgradeClick(StaffType staffType)
        {
            _presenter.BuyUpgrade(staffType);
        }
    }
}