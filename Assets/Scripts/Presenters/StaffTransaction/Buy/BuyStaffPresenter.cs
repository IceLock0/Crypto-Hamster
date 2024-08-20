using System;
using Enums.Staff;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using Services.Fabric.Staff;
using UnityEngine;

namespace Presenters.StaffTransaction
{
    public class BuyStaffPresenter
    {
        private readonly WalletModel _walletModel;
        private readonly IStaffFabric _staffFabric;
        
        public BuyStaffPresenter( WalletModel walletModel, IStaffFabric staffFabric)
        {
            _walletModel = walletModel;
            _staffFabric = staffFabric;
        }

        public void Buy(StaffType staffType, StaffConfig staffConfig)
        {
            if (_walletModel?.Currencies[typeof(Cash)].Amount < staffConfig.Price)
                throw new ArgumentException("Not enough money to buy this staff.");
            
            _walletModel?.RemoveCurrency(typeof(Cash), staffConfig.Price);

            _staffFabric.Create(staffType, staffConfig.SourcePoint.position, Quaternion.identity, null);
        }
    }
}