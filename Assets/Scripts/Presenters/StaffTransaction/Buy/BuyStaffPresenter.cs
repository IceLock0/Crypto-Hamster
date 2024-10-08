﻿using System;
using System.Collections.Generic;
using System.Linq;
using Enums.Staff;
using Model.Staff;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using Services.Fabric.Staff;
using Unity.Mathematics;
using UnityEngine;
using Views.Staff;
using Views.UI.Phone.Apps.Staff.MainApp.BuyStaff;

namespace Presenters.StaffTransaction.Buy
{
    public class BuyStaffPresenter
    {
        private readonly WalletModel _walletModel;
        private readonly IStaffFactory _staffFactory;

        private readonly List<SysAdminConfig> _sysAdminConfigs;
        private readonly List<CleanerConfig> _cleanerConfigs;

        private readonly Dictionary<StaffType, StaffModel> _staffModels;

        private readonly BuyStaffView _buyStaffView;

        public BuyStaffPresenter(WalletModel walletModel, IStaffFactory staffFactory,
            List<SysAdminConfig> sysAdminConfigs, List<CleanerConfig> cleanerConfigs, BuyStaffView buyStaffView)
        {
            _walletModel = walletModel;
            _staffFactory = staffFactory;

            _sysAdminConfigs = sysAdminConfigs;
            _cleanerConfigs = cleanerConfigs;

            _staffModels = new();
            _staffModels[StaffType.Admin] = null;
            _staffModels[StaffType.SysAdmin] = null;
            _staffModels[StaffType.Cleaner] = null;

            _buyStaffView = buyStaffView;
        }

        public void BuyUpgrade(StaffType staffType)
        {
            if (_staffModels[staffType] == null)
                Buy(staffType);

            else Upgrade(staffType);
            
            _buyStaffView.SetBuyUpgradeText(staffType);
        }

        public string GetCurrentText(StaffType staffType)
        {
            const string BUY_TEXT = "КУПИТЬ";
            const string UPGRADE_TEXT = "УЛУЧШИТЬ";
            const string MAX_UPGRADE_TEXT = "МАКС. УРОВЕНЬ";

            if (_staffModels[staffType] == null)
                return BUY_TEXT;

            var enumUpgradeLength = Enum.GetNames(typeof(StaffUpgradeType)).Length;

            var lastUpgrade = (StaffUpgradeType) enumUpgradeLength - 1;

            if (_staffModels[staffType].StaffUpgradeType == lastUpgrade)
                return MAX_UPGRADE_TEXT;

            return UPGRADE_TEXT;
        }
        
        private void Buy(StaffType staffType)
        {
            var staffConfig = GetCurrentStaffConfig(staffType, StaffUpgradeType.Common);

            CheckForAvailabilityForMoney(staffConfig);

            _walletModel?.RemoveCurrency(typeof(Cash), staffConfig.Price);

            var staffGameObject =
                _staffFactory.Create(staffType, staffConfig.SourcePoint.position, quaternion.identity, null);

            var staffModel = staffGameObject.GetComponent<StaffView>().StaffPresenter.StaffModel;

            staffModel.SetUpgradeType(StaffUpgradeType.Common, staffConfig);

            _staffModels[staffType] = staffModel;
        }

        private void Upgrade(StaffType staffType)
        {
            var staffModel = _staffModels[staffType];

            var nextUpgradeType = staffModel.StaffUpgradeType + 1;

            var staffConfig = GetCurrentStaffConfig(staffType, nextUpgradeType);

            if (staffConfig == null)
                return;

            Debug.Log($"StaffConfig = {staffConfig}");
            
            CheckForAvailabilityForMoney(staffConfig);

            staffModel.SetUpgradeType(nextUpgradeType, staffConfig);

            _walletModel?.RemoveCurrency(typeof(Cash), staffConfig.Price);
        }

        private StaffConfig GetCurrentStaffConfig(StaffType staffType, StaffUpgradeType staffUpgradeType)
        {
            switch (staffType)
            {
                case StaffType.Admin:
                    break;
                case StaffType.SysAdmin:
                    return _sysAdminConfigs.FirstOrDefault(config => config.UpgradeType == staffUpgradeType);
                case StaffType.Cleaner:
                    return _cleanerConfigs.FirstOrDefault(config => config.UpgradeType == staffUpgradeType);
                default:
                    throw new ArgumentOutOfRangeException(nameof(staffType), staffType, null);
            }

            return default;
        }

        private void CheckForAvailabilityForMoney(StaffConfig staffConfig)
        {
            if (_walletModel?.Currencies[typeof(Cash)].Amount < staffConfig.Price)
                throw new ArgumentException("Not enough money to do this transaction.");
        }
        
    }
}