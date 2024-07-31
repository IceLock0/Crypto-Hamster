using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Presenters.ComputerRepair;
using ScriptableObjects;
using Utils;

namespace Presenters.ComputerParameterChange
{

    public abstract class ComputerParameterChangePresenter
    {
        private readonly List<ComputerConfig> _computerConfigs;
        private readonly ComputerRepairPresenter _computerRepairPresenter;
        
        private UniTask _qualityChangeTask;
        
        protected readonly ComputerModel ComputerModel;
        protected ComputerConfig ComputerConfig;
        
        public ComputerParameterChangePresenter(ComputerModel computerModel, List<ComputerConfig> computerConfigs, ComputerRepairPresenter computerRepairPresenter)
        {
            InvariantChecker.CheckObjectInvariant(computerModel, computerConfigs, computerRepairPresenter);
            
            ComputerModel = computerModel;
            _computerConfigs = computerConfigs;
            _computerRepairPresenter = computerRepairPresenter;
        }

        public virtual void Enable()
        {
            _computerRepairPresenter.ComputerFixed += OnComputerFixed;
            ComputerModel.ComputerTypeChanged += OnComputerTypeChanged;
        }
        public virtual void Disable()
        {
            _computerRepairPresenter.ComputerFixed -= OnComputerFixed;
            ComputerModel.ComputerTypeChanged -= OnComputerTypeChanged;
        }

        protected abstract UniTask ChangeComputerParameter();

        protected void TryChangeComputerParameter()
        {
            if(_qualityChangeTask.Status == UniTaskStatus.Succeeded)
                _qualityChangeTask = ChangeComputerParameter();
        }

        protected virtual void OnComputerTypeChanged(ComputerType type)
        {
            ComputerConfig = _computerConfigs.FirstOrDefault(x => x.ComputerType == type);
        }

        private void OnComputerFixed()
        {
            TryChangeComputerParameter();
        }
    }

}