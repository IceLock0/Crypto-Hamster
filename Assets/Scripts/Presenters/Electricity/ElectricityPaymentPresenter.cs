using System;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Views.UI.Electricity.ButtonPayment;

namespace Presenters.Electricity
{
    public class ElectricityPaymentPresenter
    {
        public event Action PaymentCompleted;
        
        private readonly WalletModel _walletModel;

        public ElectricityPaymentPresenter(WalletModel walletModel)
        {
            _walletModel = walletModel;
        }

        private float _paymentPrice = 100.0f;
        
        public void TryToPay()
        {
            if(_walletModel.Currencies[typeof(Cash)].Amount <= _paymentPrice)
                throw new ArgumentException("не хватает денег для оплаты электр"); // сделать по-людски
            
            Pay();
        }

        private void Pay()
        {
            _walletModel.AddCurrencyAmountPerValue(typeof(Cash), -_paymentPrice);
            
            PaymentCompleted?.Invoke();
        }
    }
}