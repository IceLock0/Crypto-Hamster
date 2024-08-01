using System;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Model.Electricity
{

    public class ElectricityModel
    {
        public ElectricityModel(ElectricityConfig electricityConfig)
        {
            InvariantChecker.CheckObjectInvariant(electricityConfig);
            if (electricityConfig.MaxElectricity <= 0 || electricityConfig.SecondsDelay <= 0)
                throw new ArgumentOutOfRangeException();

            MaxElectricity = electricityConfig.MaxElectricity;
            SecondsDelay = electricityConfig.SecondsDelay;
            CurrentElectricity = MaxElectricity;
            PaymentPrice = electricityConfig.PaymentPrice;
            DecreaseValue = electricityConfig.DecreaseValue;
        }

        public float MaxElectricity { get; }
        public float SecondsDelay { get; }
        public float CurrentElectricity { get; private set; }
        public float DecreaseValue { get; private set; }
        public float PaymentPrice { get;  }

        public event Action ElectricityRanOut;
        public event Action ElectricityReseted;

        public void DecreaseElectricity(float amount)
        {
            CurrentElectricity = Mathf.Clamp(CurrentElectricity - amount,0f, MaxElectricity);
            Debug.Log($"Current electricity consumation : {DecreaseValue}");
            if(CurrentElectricity == 0)
                ElectricityRanOut?.Invoke();
        }

        public void IncreaseDecreaseValue(float amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException();
            DecreaseValue += amount;
        }

        public void ResetElectricity()
        {
            CurrentElectricity = MaxElectricity;
            ElectricityReseted?.Invoke();
        }
    }

}