using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Utils.EnumToTypeService;
using Views.Currency;
using Random = UnityEngine.Random;

namespace Presenters.Currency
{
    public class Ethereum : ICurrency, IExchangeable
    {
        public float Amount { get; set; }
        public void ChangeAmount(float amount, Action<Type> callback)
        {
            Amount += amount;
            callback?.Invoke(typeof(Ethereum));
        }

        public void Reset(Action<Type> callback)
        {
            Amount = 0;
            callback?.Invoke(typeof(Ethereum));
        }

        public float MinRate { get; set; }
        public float Rate { get; set; }
        public float MaxRate { get; set; }

        public Ethereum(List<CryptoConfig> cryptoConfigs)
        {
            InvariantChecker.CheckObjectInvariant(cryptoConfigs);
            
            var targetConfig = cryptoConfigs.FirstOrDefault(x =>
                CryptoEnumToTypeService.CryptoToType(x.CryptoCurrency) == typeof(Ethereum));
            
            if (targetConfig == null)
                throw new NullReferenceException();
            
            Rate = targetConfig.Rate;
            MinRate = targetConfig.MinRate;
            MaxRate = targetConfig.MaxRate;
        }
        
        public float GetSellAmount()
        {
            var targetAmount = Amount * Rate;
            return targetAmount;
        }

        public void Buy(float amount)
        {
            Amount = amount / Rate;
        }

        public void ChangeRate()
        {
            var step = Rate / 100;

            var newRate = Random.Range(Rate - step, Rate + step);

            newRate = Mathf.Clamp(newRate, MinRate, MaxRate);

            Rate = newRate;
        }
        
    }
}