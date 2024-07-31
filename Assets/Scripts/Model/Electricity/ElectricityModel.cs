using System;
using UnityEngine;

namespace Model.Electricity
{
    public class ElectricityModel
    {
        public ElectricityModel(float maxElectricity, float secondsDelay, float paymentPrice, float decreaseValue)
        {
            if (maxElectricity <= 0 || secondsDelay <= 0 || paymentPrice <= 0 || decreaseValue < 0)
                throw new ArgumentOutOfRangeException();
            
            MaxElectricity = maxElectricity;
            SecondsDelay = secondsDelay;
            CurrentElectricity = MaxElectricity;
            PaymentPrice = paymentPrice;
            DecreaseValue = decreaseValue;
        }
        
        public float MaxElectricity { get; }
        public float SecondsDelay { get; }
        public float CurrentElectricity { get; private set; }
        public float DecreaseValue { get;  }
        public float PaymentPrice { get;  }

        public event Action ElectricityRanOut;
        public event Action ElectricityReseted;

        public void DecreaseElectricity(float amount)
        {
            CurrentElectricity = Mathf.Clamp(CurrentElectricity - amount,0f, MaxElectricity);
            if(CurrentElectricity == 0)
                ElectricityRanOut?.Invoke();
        }

        public void ResetElectricity()
        {
            CurrentElectricity = MaxElectricity;
            ElectricityReseted?.Invoke();
        }
    }
}