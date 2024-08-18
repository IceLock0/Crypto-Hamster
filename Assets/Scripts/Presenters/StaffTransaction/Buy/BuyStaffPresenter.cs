using System;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using UnityEngine;

namespace Presenters.StaffTransaction
{
    public class BuyStaffPresenter
    {
        private readonly WalletModel _walletModel;

        public BuyStaffPresenter( WalletModel walletModel)
        {
            _walletModel = walletModel;
        }

        public void Buy(StaffConfig staffConfig)
        {
            if (_walletModel?.Currencies[typeof(Cash)].Amount < staffConfig.Price)
                throw new ArgumentException("Not enough money to buy this staff.");
            
            _walletModel?.RemoveCurrency(typeof(Cash), staffConfig.Price);
            
            //create
        }
    }
}