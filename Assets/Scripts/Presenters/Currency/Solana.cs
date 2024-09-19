using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using ScriptableObjects;

namespace Presenters.Currency
{
    public class Solana : CryptoCurrencyPresenter
    {
        public Solana(List<CryptoConfig> cryptoConfigs) : base(cryptoConfigs)
        {
        }

        protected override Type GetCryptoType()
        {
            return typeof(Solana);
        }
    }
}