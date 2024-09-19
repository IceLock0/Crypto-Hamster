using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using ScriptableObjects;

namespace Presenters.Currency
{
    public class Ethereum : CryptoCurrencyPresenter
    {
        public Ethereum(List<CryptoConfig> cryptoConfigs) : base(cryptoConfigs)
        {
        }

        protected override Type GetCryptoType()
        {
            return typeof(Ethereum);
        }
    }
}