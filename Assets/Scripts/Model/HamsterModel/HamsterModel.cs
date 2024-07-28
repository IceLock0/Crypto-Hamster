using System;
using Presenters.Currency;
using UnityEngine;

namespace Model.HamsterModel
{
    public class HamsterModel
    {
        public event Action AmountChanged;
        public event Action AmountPerClickChanged;
        public event Action AmountPerTimeChanged;

        public Hamster Hamster { get; private set; }

        public HamsterModel()
        {
            Hamster = new Hamster
            {
                Amount = 0.0f,
                Rate = 5.0f,
                Timer = 0.0f,
                AmountPerClick = 1.0f,
                AmountPerTime = 0.5f,
                TimeToAdding = 1.0f,
                AmountOfIncreaseMoneyPerClick = 0.1f,
                AmountOfIncreaseMoneyPerTime = 0.2f
            };
        }

        public void AddMoneyPerClick()
        {
            Hamster.Amount += Hamster.AmountPerClick;
            
            AmountChanged?.Invoke();
        }

        public void AddMoneyPerTime()
        {
            Hamster.Amount += Hamster.AmountPerTime;
            
            AmountChanged?.Invoke();
        }

        public void IncreaseMoneyPerClick()
        {
            Hamster.AmountPerClick += Hamster.AmountOfIncreaseMoneyPerClick;
            
            AmountPerClickChanged?.Invoke();
        }

        public void IncreaseMoneyPerTime()
        {
            Hamster.AmountPerTime += Hamster.AmountOfIncreaseMoneyPerTime;
            
            AmountPerTimeChanged?.Invoke();
        }
    }
}