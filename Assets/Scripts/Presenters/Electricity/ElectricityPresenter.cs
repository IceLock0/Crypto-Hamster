using Cysharp.Threading.Tasks;
using UnityEngine;
using Views.UI.Electricity;

namespace Presenters.Electricity
{
    public class ElectricityPresenter
    {
        private readonly ElectricityUIBarView _view;

        public ElectricityPresenter(ElectricityUIBarView view)
        {
            _view = view;

            _currentElectricity = _maxElectricity;
            
            DecreaseElectricity();
        }
        
        private float _maxElectricity = 100.0f;
        private float _currentElectricity;
        private float _secondsDelay = 1.0f;
        private float _decreaseValue = 5.0f;

        private void SetCurrentElectricity(float value)
        {
            _currentElectricity = Mathf.Clamp(value, 0, _maxElectricity);

            Debug.Log($"{_currentElectricity}");
            
            if(_currentElectricity <= 0) _view.ShowNotification();
            else _view.HideNotification();
        }
        
        private async UniTaskVoid DecreaseElectricity()
        {
            while (true)
            {
                await UniTask.Delay((int) _secondsDelay * 1000);
                
                SetCurrentElectricity(_currentElectricity - _decreaseValue);
                
                _view.ChangeFillAmount(_currentElectricity / _maxElectricity, _secondsDelay * 2);
            }
        }
    }
}