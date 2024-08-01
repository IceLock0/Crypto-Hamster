using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Presenters.ComputerParameterChange;
using Presenters.ComputerRepair;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.ComputerQualityChange
{
    public class ComputerQualityChangePresenter : ComputerParameterChangePresenter
    {
        public ComputerQualityChangePresenter(ComputerModel computerModel, List<ComputerConfig> computerConfigs, ComputerRepairPresenter computerRepairPresenter) : base(computerModel, computerConfigs, computerRepairPresenter)
        {
        }

        protected override async UniTask ChangeComputerParameter()
        {
            while (ComputerModel.Quality > 0)
            {
               Debug.Log($"Computer Quality : {ComputerModel.Quality}\n");
                ComputerModel.ChangeQuality(Mathf.Clamp(ComputerModel.Quality - ComputerConfig.QualityFatigue, 
                    0f, 100f));
                await UniTask.Delay((int) (ComputerConfig.QualityFatigueDelay * 1000));
            }
        }

        protected override void OnComputerTypeChanged(ComputerType type)
        {
            base.OnComputerTypeChanged(type);
            TryChangeComputerParameter();
        }
    }
}