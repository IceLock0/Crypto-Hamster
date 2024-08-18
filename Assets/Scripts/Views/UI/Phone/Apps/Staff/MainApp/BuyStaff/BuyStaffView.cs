using System;
using System.Collections.Generic;
using Enums.Staff;
using Model.Wallet;
using Presenters.StaffTransaction;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.UI.Phone.Apps.Staff.MainApp.BuyStaff
{
    public class BuyStaffView : MonoBehaviour
    {
        [SerializeField] private StaffBuyUpgradeButtonView _buyButton;

        private BuyStaffPresenter _presenter;

        private Dictionary<StaffType, StaffConfig> _staffConfigs = new();

        [Inject]
        public void Initialize(SysAdminConfig sysAdminConfig, CleanerConfig cleanerConfig, WalletModel walletModel)
        {
            _staffConfigs[StaffType.Admin] = null;
            _staffConfigs[StaffType.SysAdmin] = sysAdminConfig;
            _staffConfigs[StaffType.Cleaner] = cleanerConfig;

            _presenter = new BuyStaffPresenter(walletModel);
        }

        private void OnEnable()
        {
            _buyButton.BuyClicked += Buy;
        }

        private void OnDisable()
        {
            _buyButton.BuyClicked -= Buy;
        }

        private void Buy(StaffType staffType)
        {
            _presenter.Buy(_staffConfigs[staffType]);
        }
    }
}