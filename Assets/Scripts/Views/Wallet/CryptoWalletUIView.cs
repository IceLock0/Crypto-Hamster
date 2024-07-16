using System;
using Presenters.Currency;
using TMPro;
using UnityEngine;
using Views.Currency;

namespace Views.Wallet
{
    public class CryptoWalletUIView : WalletUIView
    {
        [SerializeField] private TMP_Dropdown _cryptoDropdown;
        [SerializeField] private TextMeshProUGUI _amountCurrencyText;

        [SerializeField] private CryptoWalletUIDropdownHandler _dropdown;
        
        private void Start()
        {
            base.Start();               
                                  
            TimeBetweenAdding = 0.5f;   
            CurrencyPerSecond = 0.0001f;
        }

        protected void Update()                     
        {                                           
            base.Update();

            var currencyType = _dropdown.GetCurrentCryptoType();

            if (currencyType == null)
                throw new NullReferenceException("Crypto type not found.");
            
            if (_isCanAdd)
                AddCurrencyAmount(currencyType);
        }

        public override void SetCurrencyAmountText(float amount)
        {
            _amountCurrencyText.text =  $"{amount:f5}";      
        }
    }
}