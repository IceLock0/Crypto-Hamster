using System;
using Cysharp.Threading.Tasks;
using Model.Contamination;
using ScriptableObjects;
using UnityEngine;
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

        public event Action<float> ContaminationChanged;
        
        public void Enable()
        {
            _model.CurrentContaminationChanged += ChangeContaminationFilling;
            _model.CurrentContaminationChanged += SpeedChange;
        }

        public void Disable()
        {
            _model.CurrentContaminationChanged -= ChangeContaminationFilling;
            _model.CurrentContaminationChanged -= SpeedChange;
        }

        public void ChangeContaminationByCleaner()
        {
            Debug.Log("Cleaned");
            _model.IncreaseContamination(-100.0f);
        }
        
        private async UniTask Contaminate()
        {
            while (_isCanContaminate)
            {
                await UniTask.Delay((int)(_model.SecondsDelay * 1000));

                _model.IncreaseContamination(_model.IncreaseValue);
                //  Debug.Log($"Contamination increased, current contamination = {_model.CurrentContamination}");
            }
        }

        private void SpeedChange()
        {
            ContaminationChanged?.Invoke(_model.CurrentContamination);
        }
        
        private void ChangeContaminationFilling()
        {
            _view.ChangeContaminationFilling(_model.CurrentContamination / _model.MaxContamination);
        }
    }

}