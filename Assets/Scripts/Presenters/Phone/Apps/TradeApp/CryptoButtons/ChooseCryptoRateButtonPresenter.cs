using System;
using System.Collections.Generic;
using Presenters.Currency;
using UnityEngine;
using Utils;
using Views.Phone.Apps.TradeApp.Rate;

namespace Presenters.Phone.Apps.TradeApp.CryptoButtons
{
    public class ChooseCryptoRateButtonPresenter
    {
        private readonly Dictionary<Type, IExchangeable> _cryptoExchangables;
        private readonly RatesTextsModel _ratesTextsModel;

        private IExchangeable _targetCrypto;
        
        public ChooseCryptoRateButtonPresenter(Dictionary<Type, IExchangeable> cryptoExchangables, RatesTextsModel ratesTextsModel)
        {
            InvariantChecker.CheckObjectInvariant(cryptoExchangables, ratesTextsModel);
            _cryptoExchangables = cryptoExchangables;
            _ratesTextsModel = ratesTextsModel;
        }

        public void ShowCorrectRate(Type cryptoType, string cryptoName)
        {
            FindCrypto(cryptoType);
            ShowCryptoRates(cryptoName);
        }

        private void ShowCryptoRates(string cryptoName)
        {
            _ratesTextsModel.CryptoToDollar.text = $"1 {cryptoName} = {_targetCrypto.Rate:F2}$";
            var target = Math.Round(100f / _targetCrypto.Rate, 3);
            _ratesTextsModel.DollarToCrypto.text = $"100$ = {100f / _targetCrypto.Rate:F5}";
        }

        private void FindCrypto(Type cryptoType)
        {
            if (_cryptoExchangables.ContainsKey(cryptoType) == false)
                throw new ArgumentOutOfRangeException();
            _targetCrypto = _cryptoExchangables[cryptoType];
        }
    }
}