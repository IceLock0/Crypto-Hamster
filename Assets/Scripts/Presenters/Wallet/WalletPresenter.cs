using System;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Views.Currency;
using Views.Wallet;

namespace Presenters.Wallet
{
    public class WalletPresenter
    {
        private readonly WalletUIView _uiView;
        private readonly WalletModel _model;
        
        public WalletPresenter(WalletUIView uiView)
        {
            _uiView = uiView;

            _model = new WalletModel();
            
            CreateCurrencyTypes();
        }

        public void AddCurrencyAmount(Type currencyType, float amount)
        {
            var resultAmount = _model.Currencies[currencyType] + amount;
            
            _model.SetCurrencyAmount(currencyType, resultAmount);
            
            _uiView.SetCurrencyAmountText(resultAmount);
        }
        
        private void CreateCurrencyTypes()
        {
            _model.AddCurrency<Cash>();
            _model.AddCurrency<Bitcoin>();
            _model.AddCurrency<Ethereum>();
            _model.AddCurrency<Solana>();
        }
    }
}