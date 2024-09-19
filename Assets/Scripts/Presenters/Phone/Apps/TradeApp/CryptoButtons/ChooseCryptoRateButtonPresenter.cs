using System;
using System.Collections.Generic;
using Model.TradeApp;
using Presenters.Currency;
using TMPro;
using UnityEngine;
using Utils;
using Views.Phone.Apps.TradeApp.Rate;

namespace Presenters.Phone.Apps.TradeApp.CryptoButtons
{
    public class ChooseCryptoRateButtonPresenter
    {
        private readonly Dictionary<Type, IExchangeable> _cryptoExchangables;
        private readonly RatesTextsModel _ratesTextsModel;
        private readonly TradeAppModel _tradeAppModel;

        private IExchangeable _targetCrypto;
        
        public ChooseCryptoRateButtonPresenter(Dictionary<Type, IExchangeable> cryptoExchangables, RatesTextsModel ratesTextsModel, TradeAppModel tradeAppModel)
        {
            InvariantChecker.CheckObjectInvariant(cryptoExchangables, ratesTextsModel, tradeAppModel);
            _cryptoExchangables = cryptoExchangables;
            _ratesTextsModel = ratesTextsModel;
            _tradeAppModel = tradeAppModel;
        }

        public void UpdateRate(Type cryptoType, string cryptoName)
        {
            FindCrypto(cryptoType);
            _tradeAppModel.ChangeTargetCrypto(cryptoType);
            ShowCryptoRates(cryptoName);
        }

        private void ShowCryptoRates(string cryptoName)
        {
            _ratesTextsModel.CryptoToDollar.text = $"1 {cryptoName} = {_targetCrypto.Rate:F2}$";
            _ratesTextsModel.DollarToCrypto.text = $"100$ = {100f / _targetCrypto.Rate:F5}";
        }

        private void FindCrypto(Type cryptoType)
        {
            if (_cryptoExchangables.ContainsKey(cryptoType) == false)
                throw new ArgumentOutOfRangeException();
            _targetCrypto = _cryptoExchangables[cryptoType];
        }

        public void UpdateChosenCrypto(TMP_Text chooseText, string cryptoName)
        {
            chooseText.text = $"Выбранная валюта: {cryptoName}";
        }
    }
}