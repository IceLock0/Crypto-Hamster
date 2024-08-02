using System;
using Model.Wallet;
using UnityEngine;
using Views.Wallet;

namespace Presenters.Wallet.Cash
{
    public class WalletCashPresenter : WalletPresenter
    {
        private readonly WalletCashUIView _view;
        
        public WalletCashPresenter(WalletCashUIView view, WalletModel walletModel) : base(walletModel)
        {
            _view = view;
        }
        
        protected override void SetCurrencyText(Type type)
        {
            if (type != typeof(Currency.Cash))
                return;
            
            var amountValue = Model.Currencies[type].Amount;

            _view.SetText(amountValue);
        }
    }
}