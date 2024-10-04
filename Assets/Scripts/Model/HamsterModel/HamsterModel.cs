using System;
using Presenters.Currency;

namespace Model.HamsterModel
{
    public class HamsterModel
    {
        public event Action AmountChanged;
        public event Action PerClickChanged;
        public event Action PerTimeChanged;
        public event Action PerClickPriceChanged;
        public event Action PerTimePriceChanged;

        public event Action RateChanged;
        
        public Hamster Hamster { get; private set; }

        public HamsterModel()
        {
            Hamster = new Hamster(amount: 0.0f, rate: 5.0f, perClick: 1.0f, perTime: 0.5f,
                upgradePerClickValue: 0.1f, upgradePerTimeValue: 0.2f, upgradePerClickPrice: 100.0f,
                upgradePerTimePrice: 200.0f);
        }

        public void ChangeRate()
        {
            Hamster.ChangeRate();

            RateChanged?.Invoke();
        }
        
        public float Exchange()
        {
            var resultCash = Hamster.GetSellAmount();

            AmountChanged?.Invoke();

            return resultCash;
        }
        
        public void AddPerClick()
        {
            Hamster.Amount += Hamster.PerClick;
            
            AmountChanged?.Invoke();
        }

        public void AddPerTime()
        {
            Hamster.Amount += Hamster.PerTime;
            
            AmountChanged?.Invoke();
        }

        public void UpgradePerClick()
        {
            UpgradeProcess(Hamster.UpgradePerClickPrice);

            Hamster.PerClick += Hamster.UpgradePerClickValue;
            
            PerClickChanged?.Invoke();
        }

        public void UpgradePerTime()
        {
            UpgradeProcess(Hamster.UpgradePerTimePrice);

            Hamster.PerTime += Hamster.UpgradePerTimeValue;
            
            PerTimeChanged?.Invoke();
        }

        private void IncreasePerClickPrice()
        {
            PerClickPriceChanged?.Invoke();
        }

        private void IncreasePerTimePrice()
        {
            PerTimePriceChanged?.Invoke();
        }
        
        private void UpgradeProcess(float value)
        {
            if (Hamster.Amount < value)
                throw new ArgumentException("не хватает денег");// другая обработка

            Hamster.Amount -= value;

            AmountChanged?.Invoke();
        }
    }
}