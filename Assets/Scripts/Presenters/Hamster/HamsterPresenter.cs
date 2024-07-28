using Model.HamsterModel;
using UnityEngine;
using Views.Hamster;
using Views.Hamster.Buttons;

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
            SetAmountPerClickText();
            SetAmountPerTimeText();
        }

        public void Enable()
        {
            _view.Updated += UpdateFromView;

            _model.AmountChanged += SetAmountText;

            _model.AmountPerClickChanged += SetAmountPerClickText;

            _model.AmountPerTimeChanged += SetAmountPerTimeText;
        }
        
        public void Disable()
        {
            _view.Updated -= UpdateFromView;
            
            _model.AmountChanged -= SetAmountText;
            
            _model.AmountPerClickChanged -= SetAmountPerClickText;
            
            _model.AmountPerTimeChanged -= SetAmountPerTimeText;
        }

        public void AddMoneyPerClick()
        {
            _model.AddMoneyPerClick();
        }

        public void IncreaseMoneyPerClick()
        {
            _model.IncreaseMoneyPerClick();
        }
        
        public void IncreaseMoneyPerTime()
        {
            _model.IncreaseMoneyPerTime();
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

        private void AddMoneyPerTime()
        {
            _model.AddMoneyPerTime();
        }
        
        private void SetAmountText()
        {
            _view.SetText(HamsterButtonType.MainButton, _model.Hamster.Amount);
        }

        private void SetAmountPerClickText()
        {
            _view.SetText(HamsterButtonType.UpgradePerClickButton, _model.Hamster.AmountPerClick);
        }

        private void SetAmountPerTimeText()
        {
            _view.SetText(HamsterButtonType.UpgradePerTimeButton, _model.Hamster.AmountPerTime);
        }
        
    }
}