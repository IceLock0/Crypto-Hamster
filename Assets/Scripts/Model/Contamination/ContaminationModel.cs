using System;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Model.Contamination
{
    public class ContaminationModel
    {
        public ContaminationModel(ContaminationConfig config)
        {
            InvariantChecker.CheckObjectInvariant(config);

            MaxContamination = config.MaxContamination;
            SecondsDelay = config.SecondsDelay;
            CurrentContamination = 0;
            IncreaseValue = config.IncreaseValue;
        }
        
        public float MaxContamination { get;} 
        public float SecondsDelay { get;}
        public float CurrentContamination { get; private set; }
        public float IncreaseValue { get;}

        public event Action CurrentContaminationChanged;
        
        public void IncreaseContamination(float amount)
        {
            CurrentContamination = Mathf.Clamp(CurrentContamination + amount, 0f, MaxContamination);
            CurrentContaminationChanged?.Invoke();
        }

        public void NullifyContamination()
        {
            CurrentContamination = 0.0f;
            CurrentContaminationChanged?.Invoke();
        }
    }
}