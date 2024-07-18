using System;
using Presenters.Currency;
using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class CashWalletUIView : WalletUIView
    {
        protected override void SetCurrencyAmountText(float amount)
        {
            _currencyAmountTextTMP.text = "Cash: " + $"{amount:f3}" + " $";
        }

        protected override Type GetCurrencyType()
        {
            return typeof(Cash);
        }
    }
}