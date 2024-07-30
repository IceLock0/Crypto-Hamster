using System;
using System.Collections.Generic;
using Presenters.Currency;
using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class CryptoDropDownHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cryptoText;
        [SerializeField] private TMP_Dropdown _dropdown;

        public TextMeshProUGUI CryptoText => _cryptoText;

        public event Action<Type> CryptoSelected;

        private readonly Dictionary<CryptoCurrencyIndices, Type> _cryptoIndexContainer = new();

        private void Start()
        {
            CreateIndices();
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
                CryptoSelected?.Invoke(type);
            }
        }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(GetCurrentListIndex);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(GetCurrentListIndex);
        }
    }
}