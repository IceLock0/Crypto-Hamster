using Model.HamsterModel;
using UnityEngine;
using Views.Hamster;

namespace Presenters.Hamster
{
    public class HamsterPresenter
    {
        private readonly HamsterUIView _view;

        private readonly HamsterModel _model;

        private float _timerToAddMoney;
        
        public HamsterPresenter(HamsterUIView view)
        {
            _view = view;

            _view.OnUpdate += UpdateFromView;
            
            _model = new HamsterModel();

            _timerToAddMoney = 0.0f;
        }

        private void UpdateFromView()
        {
            if (_timerToAddMoney >= _model.TimeToAddMoney)
            {
                AddMoneyPerTime();
                _timerToAddMoney = 0.0f;
            }

            _timerToAddMoney += Time.deltaTime;
        }
        
        public void AddMoneyPerClick()
        {
            var currentMoney = _model.Money + _model.MoneyPerClick;

            SetModelAndViewValue(currentMoney);
        }

        private void AddMoneyPerTime()
        {
            var currentMoney = _model.Money + _model.MoneyPerSecond;

            SetModelAndViewValue(currentMoney);
        }

        private void SetModelAndViewValue(double value)
        {
            _view.SetCounterText(value);
            
            _model.SetMoney(value);
        }
    }
}