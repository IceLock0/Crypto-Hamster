using System;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Views.Wallet;
using Zenject;

namespace Presenters.Wallet
{
    public class WalletPresenter
    {
        private readonly WalletUIView _uiView;
        private readonly WalletModel _model;

        public WalletPresenter(WalletUIView uiView, WalletModel walletModel)
        {
            _uiView = uiView;

            _model = walletModel;
        
            CreateCurrencies();
        }

        public void Enable()
        {
            _model.AmountChanged += SetCurrencyText;
        }

        public void Disable()
        {
            _model.AmountChanged -= SetCurrencyText;
        }

        private void SetCurrencyText(Type type)
        {
            var amountValue =_model.Currencies[type].Amount;

            if(type == typeof(Cash))
                _uiView.SetCashText(amountValue);
            else
                _uiView.SetCryptoText();
        }

        public float GetCryptoAmount(Type type) => _model.Currencies[type].Amount;


        private void CreateCurrencies()
        {
            _model.AddCurrency(new Cash());
            _model.AddCurrencyAmountPerValue(typeof(Cash), 10000000000000f);
            _model.AddCurrency(new Bitcoin());
            _model.AddCurrency(new Ethereum());
            _model.AddCurrency(new Solana());
        }
    }
}