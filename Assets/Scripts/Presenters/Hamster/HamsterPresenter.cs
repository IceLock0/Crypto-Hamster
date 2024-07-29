using Model.HamsterModel;
using UnityEngine;
using Views.Hamster;

namespace Presenters.Hamster
{
    public class HamsterPresenter
    {
        private readonly HamsterUIView _view;

        private readonly HamsterModel _model;

        public HamsterPresenter(HamsterUIView view)
        {
            _view = view;

            _model = new HamsterModel();

            SetAmountText();
            SetPerClickText();
            SetPerTimeText();
            SetPerClickPriceText();
            SetPerTimePriceText();
        }

        public void Enable()
        {
            _view.Updated += UpdateFromView;

            _view.MainButtonPressed += AddMoneyPerClick;

            _view.UpgradePerClickButtonPressed += UpgradePerClick;

            _view.UpgradePerTimeButtonPressed += UpgradePerTime;

            _model.AmountChanged += SetAmountText;

            _model.PerClickChanged += SetPerClickText;

            _model.PerTimeChanged += SetPerTimeText;

            _model.PerClickPriceChanged += SetPerClickPriceText;

            _model.PerTimePriceChanged += SetPerTimePriceText;
        }

        public void Disable()
        {
            _view.Updated -= UpdateFromView;

            _view.MainButtonPressed -= AddMoneyPerClick;

            _view.UpgradePerClickButtonPressed -= UpgradePerClick;

            _view.UpgradePerTimeButtonPressed -= UpgradePerTime;

            _model.AmountChanged -= SetAmountText;

            _model.PerClickChanged -= SetPerClickText;

            _model.PerTimeChanged -= SetPerTimeText;

            _model.PerClickPriceChanged -= SetPerClickPriceText;

            _model.PerTimePriceChanged -= SetPerTimePriceText;
        }

        private void UpdateFromView()
        {
            if (_model.Hamster.Timer >= _model.Hamster.TimeToAdding)
            {
                AddMoneyPerTime();
                _model.Hamster.Timer = 0.0f;
            }

            _model.Hamster.Timer += Time.deltaTime;
        }

        
        private void AddMoneyPerClick() => _model.AddPerClick();

        private void AddMoneyPerTime() => _model.AddPerTime();
        
        private void UpgradePerClick() => _model.UpgradePerClick();

        private void UpgradePerTime() => _model.UpgradePerTime();
        
        private void SetAmountText() => _view.SetText(HamsterTextType.Amount, _model.Hamster.Amount);

        private void SetPerClickText() => _view.SetText(HamsterTextType.PerClick, _model.Hamster.PerClick);

        private void SetPerTimeText() => _view.SetText(HamsterTextType.PerTime, _model.Hamster.PerTime);

        private void SetPerClickPriceText() => _view.SetText(HamsterTextType.PerClickPrice, _model.Hamster.UpgradePerClickPrice);

        private void SetPerTimePriceText() => _view.SetText(HamsterTextType.PerTimePrice, _model.Hamster.UpgradePerTimePrice);
    }
}