using System;
using System.Collections.Generic;
using Presenters.Currency;
using Utils;

namespace Model.Exchange
{
    public class ExchangeModel
    {
        public ExchangeModel(Dictionary<Type, IExchangeable> cryptoExchangables)
        {
            InvariantChecker.CheckObjectInvariant(cryptoExchangables);
            CryptoExchangables = cryptoExchangables;
        }

        public Dictionary<Type, IExchangeable> CryptoExchangables { get; private set; }
    }
}