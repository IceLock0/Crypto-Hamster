using System;
using Model.Wallet;
using Presenters.Currency;

namespace Presenters.ElectricityBar
{
    public class ElectricityPaymentPresenter
    {
        private readonly WalletModel _walletModel;
        
        private float _paymentPrice = 100.0f;

        public ElectricityPaymentPresenter(WalletModel walletModel)
        {
            _walletModel = walletModel;
        }

        public event Action PaymentCompleted;
        
        public void TryToPay()
        {
            if(_walletModel.Currencies[typeof(Cash)].Amount <= _paymentPrice)
                throw new ArgumentException("не хватает денег для оплаты электр"); // сделать по-людски
            
            Pay();
        }

        private void Pay()
        {
            _walletModel.AddCurency(typeof(Cash), -_paymentPrice);
            
            PaymentCompleted?.Invoke();
        }
    }
}