using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Model;
using Model.Contamination;
using ScriptableObjects;
using Views.Room;

namespace Presenters.Room
{
    public class ContaminationPresenter
    {
        private readonly ContaminationModel _model;
        private readonly ContaminationView _view;

        private bool _isCanContaminate = true;

        public ContaminationPresenter(ContaminationConfig config, ContaminationView view)
        {
            _model = new ContaminationModel(config);
            _view = view;

            ChangeContaminationFilling();
            Contaminate().Forget();
        }

        public event Action<float> SpeedChanged;
        
        public void Enable()
        {
            _model.CurrentContaminationChanged += ChangeContaminationFilling;
            _model.CurrentContaminationChanged += ChangeSpeed;
        }

        public void Disable()
        {
            _model.CurrentContaminationChanged -= ChangeContaminationFilling;
            _model.CurrentContaminationChanged -= ChangeSpeed;
        }

        private async UniTask Contaminate()
        {
            while (_isCanContaminate)
            {
                await UniTask.Delay((int)(_model.SecondsDelay * 1000));

                _model.IncreaseContamination(_model.IncreaseValue);
            }
        }

        private void ChangeSpeed()
        {
            SpeedChanged?.Invoke(_model.CurrentContamination);
        }
        
        private void ChangeContaminationFilling()
        {
            _view.ChangeContaminationFilling(_model.CurrentContamination / _model.MaxContamination);
        }
    }

}