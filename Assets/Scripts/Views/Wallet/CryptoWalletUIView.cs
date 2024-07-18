using System;
using Presenters.Currency;
using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class CryptoWalletUIView : WalletUIView
    {
        [SerializeField] private TMP_Dropdown _dropdown;

        private int _currentCurrencyListIndex;

        private void Start()
        {
            CreateIndices();
        }

        private void CreateIndices()
        {
            CryptoIndexContainer.AddCryptoIndex(CryptoCurrencyIndices.Bitcoin, typeof(Bitcoin));
            CryptoIndexContainer.AddCryptoIndex(CryptoCurrencyIndices.Ethereum, typeof(Ethereum));
            CryptoIndexContainer.AddCryptoIndex(CryptoCurrencyIndices.Solana, typeof(Solana));
        }
        
        protected override void SetCurrencyAmountText(float amount)
        {   
            _currencyAmountTextTMP.text =  $"{amount:f5}";      
        }

        protected override Type GetCurrencyType()
        {
            return CryptoIndexContainer.TypesContainer[_currentCurrencyListIndex];
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
    }
}