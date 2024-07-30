using Enums;
using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Computer Config", menuName = "Configs/Computer", order = 0)]
    public class ComputerConfig : ScriptableObject
    {
        [Header("Quality Change Parameters")]
        [SerializeField] private float _qualityFatigue;
        [SerializeField] private float _qualityFatigueDelay;
        [Space(3)]
        [SerializeField] private float _thermalQualityFatigue;
        [SerializeField] private float _thermalQualityFatigueDelay;
        [Space(20)] 
        [SerializeField] private ComputerType _computerType;

        public float QualityFatigue => _qualityFatigue;
        public float QualityFatigueDelay => _qualityFatigueDelay;

        public float ThermalQualityFatigue => _thermalQualityFatigue;
        public float ThermalQualityFatigueDelay => _thermalQualityFatigueDelay;
        public ComputerType ComputerType => _computerType;

    }

}