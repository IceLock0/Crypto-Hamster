using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Presenters.Currency;

namespace Views.Wallet
{
    public class CryptoWalletUIDropdownHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        
        [SerializeField] private List<DropdownValue> _dropdownCryptoList;

        private int _currentCurrencyListIndex;

        private void Start()
        {
            foreach (var value in _dropdownCryptoList)
                AddNewCrypto(value);
        }

        public Type GetCurrentCryptoType()
        {
            return _currentCurrencyListIndex switch
            {
                (int) CryptoCurrencyIndices.Bitcoin => typeof(Bitcoin),
                (int) CryptoCurrencyIndices.Ethereum => typeof(Ethereum),
                (int) CryptoCurrencyIndices.Solana => typeof(Solana),
                _ => null
            };
        }
        
        private void AddNewCrypto(DropdownValue value)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData(value.Name, value.Sprite, value.Color));
            _dropdown.RefreshShownValue();
        }

        private void GetCurrentListIndex(int index)
        {
            _currentCurrencyListIndex = index;
        }
        
        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(GetCurrentListIndex);
        }
        
        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(GetCurrentListIndex);
        }

        [Serializable]
        public class DropdownValue
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite _sprite;
            [SerializeField] private Color _color = Color.white;

            public string Name => _name;
            public Sprite Sprite => _sprite;
            public Color Color => _color;

        }
    }
}   