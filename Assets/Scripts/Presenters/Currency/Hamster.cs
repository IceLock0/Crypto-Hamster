using UnityEngine;
using Views.Currency;

namespace Presenters.Currency
{
    public class Hamster : ICurrency, IExchangeable
    {
        public float MinRate { get; set; }
        public float Amount { get; set; }
        public float Rate { get; set; }
        public float MaxRate { get; set; }
        public float PerClick { get; set; }
        public float PerTime { get; set; }
        public float UpgradePerClickValue { get; set; }
        public float UpgradePerTimeValue { get; set; }
        public float UpgradePerClickPrice { get; set; }
        public float UpgradePerTimePrice { get; set; }
        public float TimeToAdding { get; set; }
        public float Timer { get; set; }

        public Hamster(float amount,
            float rate,
            float timer, float perClick, float perTime, 
            float timeToAdding, float upgradePerClickValue, 
            float upgradePerTimeValue, float upgradePerClickPrice, float upgradePerTimePrice)
        {
            Amount = amount;
            Rate = rate;
            Timer = timer;
            PerClick = perClick;
            PerTime = perTime;
            TimeToAdding = timeToAdding;
            UpgradePerClickValue = upgradePerClickValue;
            UpgradePerTimeValue = upgradePerTimeValue;
            UpgradePerClickPrice = upgradePerClickPrice;
            UpgradePerTimePrice = upgradePerTimePrice;
            
            MinRate = rate - rate * 0.2f;
            MaxRate = rate + rate * 0.2f;
        }
        
        public float Exchange()
        {
            var resultCash = Amount * Rate;

            Amount = 0;
            
            return resultCash;
        }

        public void ChangeRate()
        {
            var step = Rate / 100;

            var newRate = Random.Range(Rate - step, Rate + step);

            if (newRate > MaxRate)
                newRate = MaxRate;
            else if (newRate < MinRate)
                newRate = MinRate;

            Rate = newRate;
        }
    }
}