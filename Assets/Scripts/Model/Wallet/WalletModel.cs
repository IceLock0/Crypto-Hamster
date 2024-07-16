using System;
using System.Collections.Generic;
using System.Linq;
using Views.Currency;

namespace Model.Wallet
{
    public class WalletModel
    {
        public WalletModel()
        {
            Currencies = new Dictionary<Type, float>();
        }

        public Dictionary<Type, float> Currencies { get; private set; }

        public void AddCurrency<T>() where T : class, ICurrency
        {
            CheckDictionaryForCurrency<T>();

            Currencies.Add(typeof(T), 0.0f);
        }

        public void SetCurrencyAmount(Type currencyType, float amount)
        {
            amount = amount < 0 ? 0 : amount;

            Currencies[currencyType] = amount;
        }
        
        private void CheckDictionaryForCurrency<T>() where T : class, ICurrency
        {
            if (Currencies.ContainsKey(typeof(T)))
                throw new ArgumentException($"Currency type: {typeof(T)} is already contained");
        }
        
    }
}