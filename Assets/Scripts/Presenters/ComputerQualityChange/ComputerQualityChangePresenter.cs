using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Presenters.ComputerRepair;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.ComputerQualityChange
{
    public class ComputerQualityChangePresenter
    {
        private readonly ComputerModel _computerModel;
        private readonly List<ComputerConfig> _computerConfigs;
        private readonly ComputerRepairPresenter _computerRepairPresenter;
        
        private ComputerConfig _computerConfig;
        private UniTask _qualityChangeTask;
        
        public ComputerQualityChangePresenter(ComputerModel computerModel, List<ComputerConfig> computerConfigs, ComputerRepairPresenter computerRepairPresenter)
        {
            InvariantChecker.CheckObjectInvariant(computerModel, computerConfigs);
            
            _computerModel = computerModel;
            _computerConfigs = computerConfigs;
            _computerRepairPresenter = computerRepairPresenter;
        }

        public void Enable()
        {
            _computerRepairPresenter.ComputerFixed += OnComputerFixed;
            _computerModel.ComputerTypeChanged += OnComputerTypeChanged;
        }
        public void Disable()
        {
            _computerRepairPresenter.ComputerFixed -= OnComputerFixed;
            _computerModel.ComputerTypeChanged -= OnComputerTypeChanged;
        }
        
        private async UniTask ChangeComputerQuality()
        {
            while (_computerModel.Quality > 0)
            {
                _computerModel.ChangeQuality(Mathf.Clamp(_computerModel.Quality - _computerConfig.QualityFatigue, 
                    0f, 100f));
                await UniTask.Delay((int) (_computerConfig.QualityFatigueDelay * 1000));
            }
        }

        private void TryChangeComputerQuality()
        {
            if(_qualityChangeTask.Status == UniTaskStatus.Succeeded)
                _qualityChangeTask = ChangeComputerQuality();
        }

        private void OnComputerTypeChanged(ComputerType type)
        {
            _computerConfig = _computerConfigs.FirstOrDefault(x => x.ComputerType == type);
            TryChangeComputerQuality();
        }

        private void OnComputerFixed()
        {
            TryChangeComputerQuality();
        }
    }
}