using System;
using ScriptableObjects;
using UnityEngine;

namespace Model
{
    public class SpeedModel
    {
        public SpeedModel(CharacterConfig characterConfig)
        {
            if (characterConfig.MovementSpeed < 0.0f)
                throw new ArgumentOutOfRangeException();
            
            CurrentSpeed = characterConfig.MovementSpeed;

            MaxSpeed = CurrentSpeed;
            MinSpeed = CurrentSpeed * 0.3f;

            AngularSpeed = characterConfig.AngularSpeed;
        }

        public float MaxSpeed { get; }

        public float CurrentSpeed { get;  set;}

        public float MinSpeed { get; }

        public float AngularSpeed { get; }

        public void ChangeSpeedByContamination(float contamination)
        {
            contamination = Mathf.Clamp01(contamination / 100f);
            CurrentSpeed = Mathf.Lerp(MaxSpeed, MinSpeed, contamination);
         //   Debug.Log($"CurrentSpeed = {CurrentSpeed}");
        }
    }
}