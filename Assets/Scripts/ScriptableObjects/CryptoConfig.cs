using UnityEngine;
using Views.Wallet.Association_dropdown;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "New crypto", menuName = "Configs/Crypto", order = 0)]
    public class CryptoConfig : ScriptableObject
    {
        [SerializeField] private CryptoCurrencyIndices _cryptoCurrency;
        [SerializeField] private float _rateChangeDelay;
        [SerializeField] private float _rate;
        [SerializeField] private float _minRate;
        [SerializeField] private float _maxRate;

        public CryptoCurrencyIndices CryptoCurrency => _cryptoCurrency;
        public float Rate => _rate;
        public float MinRate => _minRate;
        public float MaxRate => _maxRate;
        public float RateChangeDelay => _rateChangeDelay;
    }

}