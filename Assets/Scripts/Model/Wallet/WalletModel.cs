using System;
using System.Collections.Generic;
using System.Linq;
using Presenters.Currency;
using UnityEngine;
using Views.Currency;

namespace Model.Wallet
{
    public class WalletModel
    {
        public event Action<Type> AmountChanged;
        
        public Dictionary<Type, ICurrency> Currencies { get; private set; }
        
        public WalletModel()
        {
            Currencies = new Dictionary<Type, ICurrency>();
        }

        public void AddCurrency<T>(T currency) where T : class, ICurrency
        {
            CheckDictionaryForCurrency<T>();

            Currencies.Add(typeof(T), currency);
        }
        
        public void AddCurrencyAmountPerValue(Type currencyType, float value)
        {
            Currencies[currencyType].Amount += value;
            
            AmountChanged?.Invoke(currencyType);
        }


        private void CheckDictionaryForCurrency<T>() where T : class, ICurrency
        {
            if (Currencies.ContainsKey(typeof(T)))
                throw new ArgumentException($"Currency type: {typeof(T)} is already contained");
        }
        
    }
}