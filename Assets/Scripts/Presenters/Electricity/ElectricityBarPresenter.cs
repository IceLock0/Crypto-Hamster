using Cysharp.Threading.Tasks;
using Model.Wallet;
using UnityEngine;
using Views.UI.Electricity;
using Views.UI.Electricity.ButtonPayment;

namespace Presenters.Electricity
{
    public class ElectricityBarPresenter
    {
        public float PaymentPrice { get; private set; }

        private readonly ElectricityUIBarView _barView;
        private readonly ElectricityUIButtonPayment _buttonPayment;
        private readonly ElectricityPaymentPresenter _paymentPresenter;
        
        private float _maxElectricity = 100.0f;
        private float _currentElectricity;
        private float _secondsDelay = 1.0f;
        private float _decreaseValue = 5.0f;
        
        public ElectricityBarPresenter(ElectricityUIBarView barView, ElectricityUIButtonPayment buttonPayment, WalletModel walletModel)
        {
            _barView = barView;

            _buttonPayment = buttonPayment;

            _paymentPresenter = new ElectricityPaymentPresenter(walletModel);
            
            _currentElectricity = _maxElectricity;

            PaymentPrice = 100.0f;
            
            DecreaseElectricity();
        }

        public void Enable()
        {
            _buttonPayment.ButtonClicked += _paymentPresenter.TryToPay;

            _paymentPresenter.PaymentCompleted += FillElectricity;
        }

        public void Disable()
        {
            _buttonPayment.ButtonClicked -= _paymentPresenter.TryToPay;
            
            _paymentPresenter.PaymentCompleted -= FillElectricity;
        }
        
        public void SetCurrentElectricity(float value)
        {
            _currentElectricity = Mathf.Clamp(value, 0, _maxElectricity);
            
            if(_currentElectricity <= 0) _barView.ShowNotification();
            else _barView.HideNotification();
        }
        
        private async UniTaskVoid DecreaseElectricity()
        {
            while (true)
            {
                await UniTask.Delay((int) _secondsDelay * 1000);
                
                SetCurrentElectricity(_currentElectricity - _decreaseValue);
                
                _barView.ChangeFillAmount(_currentElectricity / _maxElectricity, _secondsDelay * 2);
            }
        }

        private void FillElectricity()
        {
            SetCurrentElectricity(100.0f);
        }
    }
}