using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using ScriptableObjects;

namespace Presenters.Currency
{
    public class Bitcoin : CryptoCurrencyPresenter
    {
        public Bitcoin(List<CryptoConfig> cryptoConfigs) : base(cryptoConfigs)
        {
        }

        protected override Type GetCryptoType()
        {
            return typeof(Bitcoin);
        }
    }
}