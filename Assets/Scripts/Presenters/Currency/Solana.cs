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
    public class Solana : ICurrency, IExchangeable
    {
        public float Amount { get; set; }
        public float MinRate { get; set; }
        public float Rate { get; set; }
        public float MaxRate { get; set; }

        public Solana(List<CryptoConfig> cryptoConfigs)
        {
            InvariantChecker.CheckObjectInvariant(cryptoConfigs);
            
            var targetConfig = cryptoConfigs.FirstOrDefault(x =>
                CryptoEnumToTypeService.CryptoToType(x.CryptoCurrency) == typeof(Solana));
            
            if (targetConfig == null)
                throw new NullReferenceException();
            
            Rate = targetConfig.Rate;
            MinRate = targetConfig.MinRate;
            MaxRate = targetConfig.MaxRate;
        }
        
        
        public float Sell()
        {
            var targetAmount = Amount * Rate;
            Amount = 0;
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