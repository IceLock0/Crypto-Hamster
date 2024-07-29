using System;
using Presenters.Currency;
using UnityEngine;

namespace Model.HamsterModel
{
    public class HamsterModel
    {
        public event Action AmountChanged;
        public event Action PerClickChanged;
        public event Action PerTimeChanged;
        public event Action PerClickPriceChanged;
        public event Action PerTimePriceChanged;
        
        public Hamster Hamster { get; private set; }

        public HamsterModel()
        {
            Hamster = new Hamster
            {
                Amount = 0.0f,
                Rate = 5.0f,
                Timer = 0.0f,
                PerClick = 1.0f,
                PerTime = 0.5f,
                TimeToAdding = 1.0f,
                UpgradePerClickValue = 0.1f,
                UpgradePerTimeValue = 0.2f,
                UpgradePerClickPrice = 100.0f,
                UpgradePerTimePrice = 200.0f
            };
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