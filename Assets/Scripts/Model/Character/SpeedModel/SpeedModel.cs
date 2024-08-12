using System;
using UnityEngine;

namespace Model
{
    public class SpeedModel
    {
        public SpeedModel(float currentSpeed)
        {
            if (currentSpeed < 0.0f)
                throw new ArgumentOutOfRangeException();
            CurrentSpeed = currentSpeed;

            MaxSpeed = CurrentSpeed;
            MinSpeed = CurrentSpeed * 0.3f;
        }

        public float MaxSpeed { get; }

        public float CurrentSpeed { get;  set;}

        public float MinSpeed { get; }

        public void ChangeSpeedByContamination(float contamination)
        {
            contamination = Mathf.Clamp01(contamination / 100f);
            CurrentSpeed = Mathf.Lerp(MaxSpeed, MinSpeed, contamination);
            Debug.Log($"CurrentSpeed = {CurrentSpeed}");
        }
    }
}