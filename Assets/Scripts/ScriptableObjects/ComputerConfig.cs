using System.Collections.Generic;
using Enums;
using Model.Crypto;
using UnityEngine;
using Views.Wallet.Association_dropdown;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Computer Config", menuName = "Configs/Computer", order = 0)]
    public class ComputerConfig : ScriptableObject
    {
        [Header("Quality Change Parameters")]
        [SerializeField] private float _qualityFatigue;
        [SerializeField] private float _qualityFatigueDelay;
        [Space(20)] 
        [SerializeField] private ComputerType _computerType;
        [Space(40)] 
        [SerializeField] private List<CryptoModel> _cryptoModels;
        [SerializeField] private float _electricityConsumation;

        public float QualityFatigue => _qualityFatigue;
        public float QualityFatigueDelay => _qualityFatigueDelay;
        public ComputerType ComputerType => _computerType;
        public List<CryptoModel> CryptoModels => _cryptoModels;
        public float ElectricityConsumation => _electricityConsumation;

    }

}