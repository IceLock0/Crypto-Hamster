using System;
using System.Collections.Generic;
using Presenters.Currency;
using TMPro;
using UnityEngine;
using Views.Wallet.Association_dropdown;

namespace Views.UI.Wallet
{
    public class CryptoDropDownHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cryptoText;
        [SerializeField] private TMP_Dropdown _dropdown;
        
        private readonly Dictionary<CryptoCurrencyIndices, Type> _cryptoIndexContainer = new();

        private void Awake()
        {
            CreateIndices();
            CurrentCrypto = _cryptoIndexContainer[(CryptoCurrencyIndices)_dropdown.value];
        }
        public TextMeshProUGUI CryptoText => _cryptoText;
        public event Action<Type> CryptoSelected;
        public Type CurrentCrypto { get; private set; }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(GetCurrentListIndex);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(GetCurrentListIndex);
        }
        private void CreateIndices()
        {
            _cryptoIndexContainer[CryptoCurrencyIndices.Bitcoin] = typeof(Bitcoin);
            _cryptoIndexContainer[CryptoCurrencyIndices.Ethereum] = typeof(Ethereum);
            _cryptoIndexContainer[CryptoCurrencyIndices.Solana] = typeof(Solana);
        }
        private void GetCurrentListIndex(int index)
        {
            if (!Enum.IsDefined(typeof(CryptoCurrencyIndices), index))
                return;

            var selectedIndex = (CryptoCurrencyIndices) index;

            if (_cryptoIndexContainer.TryGetValue(selectedIndex, out Type type))
            {
                CurrentCrypto = type;
                CryptoSelected?.Invoke(type);
            }
        }


    }
}