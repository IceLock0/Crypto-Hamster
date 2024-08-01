using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Model.Electricity;
using Presenters.Computer.ComputerParameterChange;
using Presenters.ComputerRepair;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.Computer.ComputerQualityChange
{
    public class ComputerQualityChangePresenter : ComputerParameterChangePresenter
    {
        private readonly ElectricityModel _electricityModel;
        public ComputerQualityChangePresenter(ComputerModel computerModel, List<ComputerConfig> computerConfigs, ComputerRepairPresenter computerRepairPresenter,ElectricityModel electricityModel) : base(computerModel, computerConfigs, computerRepairPresenter)
        {
            InvariantChecker.CheckObjectInvariant(electricityModel);

            _electricityModel = electricityModel;
        }

        protected override async UniTask ChangeComputerParameter()
        {
            while (ComputerModel.Quality > 0 && _electricityModel.CurrentElectricity > 0f)
            {
                await UniTask.Delay((int) (ComputerConfig.QualityFatigueDelay * 1000));
                ComputerModel.ChangeQuality(Mathf.Clamp(ComputerModel.Quality - ComputerConfig.QualityFatigue, 
                    0f, 100f));
            }
        }

        public override void Enable()
        {
            base.Enable();
            _electricityModel.ElectricityReseted += TryChangeComputerParameter;
        }

        public override void Disable()
        {
            base.Disable();
            _electricityModel.ElectricityReseted -= TryChangeComputerParameter;
        }

        protected override void OnComputerTypeChanged(ComputerType type)
        {
            base.OnComputerTypeChanged(type);
            TryChangeComputerParameter();
        }
    }
}