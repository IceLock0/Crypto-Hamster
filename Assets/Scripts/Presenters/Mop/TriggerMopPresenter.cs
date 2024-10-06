using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using Views.Mop;

namespace Presenters.Mop
{
    public class TriggerMopPresenter
    {
        private readonly TriggerMopView _triggerMopView;
        private readonly MopConfig _mopConfig;
        private readonly ContaminationPresenter _contaminationPresenter;

        private CancellationTokenSource _cts;
        
        public TriggerMopPresenter(TriggerMopView triggerMopView, MopConfig mopConfig, ContaminationPresenter contaminationPresenter)
        {
            _triggerMopView = triggerMopView;
            _mopConfig = mopConfig;
            _contaminationPresenter = contaminationPresenter;

            _cts = new CancellationTokenSource();
        }

        public void OnEnable()
        {
            _triggerMopView.Entered += StartClean;
            _triggerMopView.Exited += StopClean;

            _contaminationPresenter.ContaminationChanged += OnContaminationChanged;
        }

        public void OnDisable()
        {
            _triggerMopView.Entered -= StartClean;
            _triggerMopView.Exited -= StopClean;
            
            _contaminationPresenter.ContaminationChanged -= OnContaminationChanged;
        }
        
        private async void StartClean()
        {
            Debug.Log("StarClean");

            try
            {
                await UniTask.Delay((int) (_mopConfig.TimeToClean * 1000), cancellationToken: _cts.Token);
            }
            catch (OperationCanceledException e)
            {
                Debug.Log($"Work was canceled. Exc data: {e.Data}, Exc message {e.Message}");
                return;
            }
            
            Debug.Log("PLAYER");
            _contaminationPresenter.Clean();
        }

        private void OnContaminationChanged(float value)
        {
            if (value <= _mopConfig.Power)
            {
                StopClean();
            }
        }
        
        private void StopClean()
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
        }
    }
}