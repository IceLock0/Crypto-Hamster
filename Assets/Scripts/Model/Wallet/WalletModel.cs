using System;
using System.Collections.Generic;
using Views.Currency;

namespace Model.Wallet
{
    public class WalletModel
    {
        public WalletModel()
        {
            Currencies = new();
        }

        public Dictionary<ICurrency, float> Currencies { get; private set; }
        
        public void AddCurrency(ICurrency currency)
        {
            CheckDictionaryForCurrency(currency);
            
            Currencies.Add(currency, 0);
        }

        public void SetCurrencyAmount(ICurrency currency, float amount)
        {
            if (amount < 0)
                throw new ArgumentException($"Cannot set amount < 0. Amount = {amount}");

            Currencies[currency] = amount;
        }
        
        private void CheckDictionaryForCurrency(ICurrency currency)
        {
            if (Currencies.ContainsKey(currency))
                throw new ArgumentException($"Currency: {currency} is already contained");
        }
    }
}