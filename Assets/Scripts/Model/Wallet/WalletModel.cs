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

        public void AddCurrencyAmount(Type currencyType)
        {
            Currencies[currencyType].Amount += Currencies[currencyType].AmountPerTime;
        }

        private void CheckDictionaryForCurrency<T>() where T : class, ICurrency
        {
            if (Currencies.ContainsKey(typeof(T)))
                throw new ArgumentException($"Currency type: {typeof(T)} is already contained");
        }
        
    }
}