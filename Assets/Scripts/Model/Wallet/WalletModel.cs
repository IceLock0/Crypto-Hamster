using System;
using System.Collections.Generic;
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
        }

        public void AddCurency(Type currencyType, float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            ChangeCurrencyValue(currencyType, value);
        }

        public void RemoveCurrency(Type currencyType, float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            ChangeCurrencyValue(currencyType, -value);
        }

        private void ChangeCurrencyValue(Type currencyType, float value)
        {
            Currencies[currencyType].Amount += value;
            
            AmountChanged?.Invoke(currencyType);
        }
    }
}