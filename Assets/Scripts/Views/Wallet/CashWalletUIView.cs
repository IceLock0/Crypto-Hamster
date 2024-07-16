using System;
using Presenters.Currency;
using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class CashWalletUIView : WalletUIView
    {
        [SerializeField] private TextMeshProUGUI _amountCurrencyText;
        
        protected void Start()
        {
            base.Start();
            
            TimeBetweenAdding = 1f;
            CurrencyPerSecond = 1.25f;
        }

        protected void  Update()
        {
            base.Update();
            
            if(_isCanAdd) 
                AddCurrencyAmount(typeof(Cash));
        }
        
        public override void SetCurrencyAmountText(float amount)
        {
            _amountCurrencyText.text = "Cash: " + $"{amount:f3}" + " $";
        }
    }
}