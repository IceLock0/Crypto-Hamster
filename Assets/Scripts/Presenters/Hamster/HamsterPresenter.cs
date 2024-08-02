using Cysharp.Threading.Tasks;
using Model.HamsterModel;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Utils;
using Views.Hamster;

namespace Presenters.Hamster
{
    public class HamsterPresenter
    {
        private readonly HamsterUIView _view;

        private readonly HamsterModel _model;

        private readonly WalletModel _walletModel;
        
        public HamsterPresenter(HamsterUIView view, WalletModel walletModel)
        {
            InvariantChecker.CheckObjectInvariant(view, walletModel);
            
            _view = view;

            _model = new HamsterModel();

            _walletModel = walletModel;

            SetAmountText();
            SetPerClickText();
            SetPerTimeText();
            SetPerClickPriceText();
            SetPerTimePriceText();
            SetRateText();

            ChangeRate();
            AddMoneyPerTime();
        }

        public void Enable()
        {
            _view.MainButtonPressed += AddMoneyPerClick;

            _view.UpgradePerClickButtonPressed += UpgradePerClick;

            _view.UpgradePerTimeButtonPressed += UpgradePerTime;

            _view.ExchangeButtonPressed += Exchange;

            _model.AmountChanged += SetAmountText;

            _model.PerClickChanged += SetPerClickText;

            _model.PerTimeChanged += SetPerTimeText;

            _model.PerClickPriceChanged += SetPerClickPriceText;

            _model.PerTimePriceChanged += SetPerTimePriceText;

            _model.RateChanged += SetRateText;
        }

        public void Disable()
        {
            _view.MainButtonPressed -= AddMoneyPerClick;

            _view.UpgradePerClickButtonPressed -= UpgradePerClick;

            _view.UpgradePerTimeButtonPressed -= UpgradePerTime;

            _view.ExchangeButtonPressed -= Exchange;

            _model.AmountChanged -= SetAmountText;

            _model.PerClickChanged -= SetPerClickText;

            _model.PerTimeChanged -= SetPerTimeText;

            _model.PerClickPriceChanged -= SetPerClickPriceText;

            _model.PerTimePriceChanged -= SetPerTimePriceText;

            _model.RateChanged -= SetRateText;
        }

        private float _rateChangeFrequencyInSeconds = 2.0f;
        private bool _isCanChangeRate = true;

        private float _hamsterAddingFrequencyInSeconds = 1.0f;
        private bool _isCanAddHamster = true;
        private async UniTaskVoid ChangeRate()
        {
            while (_isCanChangeRate)
            {
                await UniTask.Delay((int) _rateChangeFrequencyInSeconds * 1000);

                _model.ChangeRate();
            }
        }
        
        private async UniTaskVoid AddMoneyPerTime()
        {
            while (_isCanAddHamster)
            {
                await UniTask.Delay((int) _hamsterAddingFrequencyInSeconds * 1000);

                _model.AddPerTime();
            }
        }
        
        private void Exchange()
        {
           var resultCash = _model.Exchange();
           
           _walletModel.AddCurency(typeof(Cash), resultCash);
        }

        private void AddMoneyPerClick() => _model.AddPerClick();

        private void UpgradePerClick() => _model.UpgradePerClick();

        private void UpgradePerTime() => _model.UpgradePerTime();

        private void SetAmountText() => _view.SetText(HamsterTextType.Amount, _model.Hamster.Amount);

        private void SetPerClickText() => _view.SetText(HamsterTextType.PerClick, _model.Hamster.PerClick);

        private void SetPerTimeText() => _view.SetText(HamsterTextType.PerTime, _model.Hamster.PerTime);

        private void SetPerClickPriceText() =>
            _view.SetText(HamsterTextType.PerClickPrice, _model.Hamster.UpgradePerClickPrice);

        private void SetPerTimePriceText() =>
            _view.SetText(HamsterTextType.PerTimePrice, _model.Hamster.UpgradePerTimePrice);

        private void SetRateText() => _view.SetText(HamsterTextType.Rate, _model.Hamster.Rate);
    }
}