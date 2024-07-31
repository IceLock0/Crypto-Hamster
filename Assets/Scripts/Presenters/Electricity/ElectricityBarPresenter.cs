using Cysharp.Threading.Tasks;
using Model.Electricity;
using Model.Wallet;
using UnityEngine;
using Utils;
using Views.UI.Electricity;
using Views.UI.Electricity.ButtonPayment;

namespace Presenters.Electricity
{
    public class ElectricityBarPresenter
    {

        private readonly ElectricityUIBarView _barView;
        private readonly ElectricityUIButtonPayment _buttonPayment;
        private readonly ElectricityPaymentPresenter _paymentPresenter;
        private readonly ElectricityModel _electricityModel;


        public ElectricityBarPresenter(ElectricityUIBarView barView, ElectricityUIButtonPayment buttonPayment, WalletModel walletModel, ElectricityModel electricityModel)
        {
            InvariantChecker.CheckObjectInvariant(barView,buttonPayment,walletModel,electricityModel);
            
            _barView = barView;
            _buttonPayment = buttonPayment;
            _paymentPresenter = new ElectricityPaymentPresenter(walletModel);
            _electricityModel = electricityModel;

            DecreaseElectricity().Forget();
        }

        public void Enable()
        {
            _buttonPayment.ButtonClicked += _paymentPresenter.TryToPay;
            _electricityModel.ElectricityRanOut += _barView.ShowNotification;
            _electricityModel.ElectricityReseted += _barView.HideNotification;
            _paymentPresenter.PaymentCompleted += FillElectricity;
        }

        public void Disable()
        {
            _buttonPayment.ButtonClicked -= _paymentPresenter.TryToPay;
            _electricityModel.ElectricityRanOut -= _barView.ShowNotification;
            _electricityModel.ElectricityReseted -= _barView.HideNotification;
            _paymentPresenter.PaymentCompleted -= FillElectricity;
        }

        private async UniTaskVoid DecreaseElectricity()
        {
            while (true)
            {
                await UniTask.Delay((int) (_electricityModel.SecondsDelay * 1000));
                
                _electricityModel.DecreaseElectricity(_electricityModel.DecreaseValue);
                
                _barView.ChangeFillAmount(_electricityModel.CurrentElectricity / _electricityModel.MaxElectricity, _electricityModel.SecondsDelay * 2);
            }
        }

        private void FillElectricity()
        {
            _electricityModel.ResetElectricity();
        }
    }
}