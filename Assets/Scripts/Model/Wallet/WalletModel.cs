using System;
using System.Collections.Generic;
using Presenters.Currency;
using Utils;
using Views.Currency;

namespace Model.Wallet
{
    public class WalletModel
    {
        public event Action<Type> AmountChanged;
        
        public Dictionary<Type, ICurrency> Currencies { get; private set; }
        
        public WalletModel(Dictionary<Type, ICurrency> currencies)
        {
            InvariantChecker.CheckObjectInvariant(currencies);
            Currencies = currencies;
            AddCurency(typeof(Cash), 99999); // DEBUG
        }

        public void AddCurency(Type currencyType, float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            ChangeCurrencyValue(currencyType, value);
        }

        public void NullifyCurrency(Type currencyType)
        {
            Currencies[currencyType].Reset(AmountChanged);
            ChangeCurrencyValue(currencyType, 0);
        }

        public void RemoveCurrency(Type currencyType, float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            ChangeCurrencyValue(currencyType, -value);
        }

        private void ChangeCurrencyValue(Type currencyType, float value)
        {
            Currencies[currencyType].ChangeAmount(value, AmountChanged);
        }
    }
}