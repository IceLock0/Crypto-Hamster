using Cysharp.Threading.Tasks;
using Model.Electricity;
using Model.Wallet;
using Presenters.ElectricityBar;
using UnityEngine.UI;
using Utils;
using Views.Empty.Electricity;
using Views.UI.Electricity;
using Views.UI.Electricity.ButtonPayment;

namespace Presenters.Electricity
{
    public class ElectricityBarPresenter
    {
        private readonly ElectricityUIBarView _barView;
        private readonly ElectricityUIButtonPayment _paymentButton;
        private readonly ElectricityPaymentPresenter _paymentPresenter;

        private readonly ElectricityModel _electricityModel;
        private readonly ElectricityIconView _electricityIconView;
        private readonly ElectricityFillView _electricityFillView;

        private Image _electricityIconImage;
        private Image _electricityFillImage;


        public ElectricityBarPresenter(ElectricityUIBarView barView, ElectricityUIButtonPayment paymentButton, WalletModel walletModel, ElectricityModel electricityModel, ElectricityIconView electricityIconView, ElectricityFillView electricityFillView)
        {
            InvariantChecker.CheckObjectInvariant(barView,paymentButton,walletModel,electricityModel,electricityIconView,electricityFillView);

            _barView = barView;

            _paymentButton = paymentButton;

            _paymentPresenter = new ElectricityPaymentPresenter(walletModel);
            
            _electricityModel = electricityModel;

            _electricityIconView = electricityIconView;

            _electricityFillView = electricityFillView;
            DecreaseElectricity().Forget();
        }

        public void InitializeImages()
        {
            _electricityIconImage = _electricityIconView.GetComponent<Image>();
            _electricityFillImage = _electricityFillView.GetComponent<Image>();
        }

        public void Enable()
        {
            _paymentButton.ButtonClicked += _paymentPresenter.TryToPay;
            
            _paymentPresenter.PaymentCompleted += FillElectricity;
        }

        public void Disable()
        {
            _paymentButton.ButtonClicked -= _paymentPresenter.TryToPay;
            
            _paymentPresenter.PaymentCompleted -= FillElectricity;
        }


        private async UniTaskVoid DecreaseElectricity()
        {
            while (true)
            {
                await UniTask.Delay((int) (_electricityModel.SecondsDelay * 1000));
                
                _electricityModel.DecreaseElectricity(_electricityModel.DecreaseValue);
                
                _barView.ChangeFillAmount(_electricityIconImage, _electricityModel.CurrentElectricity / _electricityModel.MaxElectricity, _electricityModel.SecondsDelay * 2);
                _barView.ChangeFillAmount(_electricityFillImage, _electricityModel.CurrentElectricity / _electricityModel.MaxElectricity, _electricityModel.SecondsDelay * 2);
            }
        }

        private void FillElectricity()
        {
            _electricityModel.ResetElectricity();
        }
    }
}