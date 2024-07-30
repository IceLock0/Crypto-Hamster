using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.ComputerQualityChange
{
    public class ComputerQualityChangePresenter
    {
        private readonly ComputerModel _computerModel;
        private readonly ComputerConfig _computerConfig;
        
        public ComputerQualityChangePresenter(ComputerModel computerModel, ComputerConfig computerConfig)
        {
            InvariantChecker.CheckObjectInvariant(computerModel, computerConfig);
            
            _computerModel = computerModel;
            _computerConfig = computerConfig;
        }

        public void TryChangingQuality()
        {
            if (_computerModel.Quality <= 0 || _computerModel.ThermalQuality <= 0 || _computerModel.ComputerType == ComputerType.Empty)
            {
                Debug.Log("Computer is broken");
                return; //Пока заглушка
            }

            ChangeQuality();
            ChangeThermalQuality();
        }

        private async UniTaskVoid ChangeQuality()
        {
            while (_computerModel.Quality > 0)
            {
                _computerModel.ChangeQuality(Mathf.Clamp(_computerModel.Quality - _computerConfig.QualityFatigue, 
                    0f, 100f));
                await UniTask.Delay((int) (_computerConfig.QualityFatigueDelay * 1000));
                Debug.Log($"Quality Changed on {_computerModel.Quality}");
            }
        }

        private async UniTaskVoid ChangeThermalQuality()
        {
            while (_computerModel.ThermalQuality > 0)
            {
                _computerModel.ChangeThermalQuality(Mathf.Clamp(_computerModel.ThermalQuality - _computerConfig.ThermalQualityFatigue, 
                    0f, 100f));
                await UniTask.Delay((int) (_computerConfig.ThermalQualityFatigueDelay * 1000));
                Debug.Log($"Thermal Quality Changed on {_computerModel.ThermalQuality}");
            }
        }
    }
}