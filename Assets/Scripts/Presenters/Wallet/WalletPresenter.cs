using System;
using System.Collections.Generic;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Utils;
using Views.Currency;
using Views.Wallet;
using Zenject;

namespace Presenters.Wallet
{
    public class WalletPresenter
    {
        private readonly WalletUIView _uiView;
        private readonly Dictionary<Type,ICurrency> _currencies;
        private readonly WalletModel _model;

        public WalletPresenter(WalletUIView uiView, WalletModel walletModel, Dictionary<Type,ICurrency> currencies)
        {
            InvariantChecker.CheckObjectInvariant(currencies);
            _uiView = uiView;
            _model = walletModel;
            _currencies = currencies;
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
    }
}