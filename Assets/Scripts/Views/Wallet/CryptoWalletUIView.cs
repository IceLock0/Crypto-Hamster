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

        protected override void SetCurrencyAmountText(float amount)
        {   
            _currencyAmountTextTMP.text =  $"{amount:f5}";      
        }

        protected override Type GetCurrencyType()
        {
            return CryptoIndexContainer.TypesContainer[_currentCurrencyListIndex];
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            _dropdown.onValueChanged.AddListener(GetCurrentListIndex);
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            
            _dropdown.onValueChanged.RemoveListener(GetCurrentListIndex);
        }
        
        private void CreateIndices()
        {
            CryptoIndexContainer.AddCryptoIndex(CryptoCurrencyIndices.Bitcoin, typeof(Bitcoin));
            CryptoIndexContainer.AddCryptoIndex(CryptoCurrencyIndices.Ethereum, typeof(Ethereum));
            CryptoIndexContainer.AddCryptoIndex(CryptoCurrencyIndices.Solana, typeof(Solana));
        }
        
        private void GetCurrentListIndex(int index)
        {
            _currentCurrencyListIndex = index;
        }
        
    }
}