using Model.HamsterModel;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
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
            _view = view;

            _model = new HamsterModel();

            _walletModel = walletModel;

            SetAmountText();
            SetPerClickText();
            SetPerTimeText();
            SetPerClickPriceText();
            SetPerTimePriceText();
            SetRateText();
        }

        public void Enable()
        {
            _view.Updated += UpdateFromView;

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
            _view.Updated -= UpdateFromView;

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

        private void UpdateFromView()
        {
            AddMoneyPerTime();
            ChangeRate();
        }
        //привести в порядок таймеры
        private float timer = 0.0f;
        
        private void ChangeRate()
        {
            if (timer >= 2.0f)
            {
                _model.ChangeRate();
                timer = 0.0f;
            }

            timer += Time.deltaTime;;
        }
        
        private void Exchange()
        {
           var resultCash = _model.Exchange();
           
           _walletModel.AddCurrencyAmountPerValue(typeof(Cash), resultCash);
        }

        private void AddMoneyPerClick() => _model.AddPerClick();
            
        private void AddMoneyPerTime()
        {
            if (_model.Hamster.Timer >= _model.Hamster.TimeToAdding)
            {
                _model.AddPerTime();
                _model.Hamster.Timer = 0.0f;
            }

            _model.Hamster.Timer += Time.deltaTime;
        }

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