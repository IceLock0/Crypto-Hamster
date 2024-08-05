using System;
using UnityEngine;
using Views.Currency;
using Random = UnityEngine.Random;

namespace Presenters.Currency
{
    public class Hamster : ICurrency, IExchangeable
    {
        public float MinRate { get; set; }
        public float Amount { get; set; }
        public void ChangeAmount(float amount, Action<Type> callback)
        {
            throw new NotImplementedException();
        }

        public void Reset(Action<Type> callback)
        {
            Amount = 0;
            callback?.Invoke(typeof(Hamster));
        }

        public float Rate { get; set; }
        public float MaxRate { get; set; }
        public float PerClick { get; set; }
        public float PerTime { get; set; }
        public float UpgradePerClickValue { get; set; }
        public float UpgradePerTimeValue { get; set; }
        public float UpgradePerClickPrice { get; set; }
        public float UpgradePerTimePrice { get; set; }

        public Hamster(float amount,
            float rate, float perClick, float perTime, 
             float upgradePerClickValue, 
            float upgradePerTimeValue, float upgradePerClickPrice, float upgradePerTimePrice)
        {
            Amount = amount;
            Rate = rate;
            PerClick = perClick;
            PerTime = perTime;
            UpgradePerClickValue = upgradePerClickValue;
            UpgradePerTimeValue = upgradePerTimeValue;
            UpgradePerClickPrice = upgradePerClickPrice;
            UpgradePerTimePrice = upgradePerTimePrice;
            
            MinRate = rate - rate * 0.2f;
            MaxRate = rate + rate * 0.2f;
        }
        
        public float GetSellAmount()
        {
            var resultCash = Amount * Rate;

            Amount = 0;
            
            return resultCash;
        }

        public void Buy(float amount)
        {
            throw new NotImplementedException();
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