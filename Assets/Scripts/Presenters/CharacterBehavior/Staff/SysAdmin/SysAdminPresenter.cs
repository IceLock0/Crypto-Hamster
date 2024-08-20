using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Model.Computer;
using Model.Staff.SysAdmin;
using ModestTree;
using Presenters.Character.Staff;
using Presenters.Computer;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using NavMeshSurface = Unity.AI.Navigation.NavMeshSurface;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter : StaffPresenter
    {
        private readonly NavMeshSurface _navMeshSurface;
        private readonly List<ComputerBuilderPresenter> _computerBuilderPresenters;
        private readonly List<ComputerModel> _computerModels;

        private readonly SysAdminModel _sysAdminModel;

        public SysAdminPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<ComputerBuilderPresenter> computerBuilderPresenters) :
            base(staffConfig, navMeshAgent, contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(staffConfig, navMeshAgent, contaminationPresenter,
                computerBuilderPresenters);
            
            _computerBuilderPresenters = computerBuilderPresenters;

            _computerModels = _computerBuilderPresenters.Select(presenter => presenter.Model).ToList();
            
            _sysAdminModel = new SysAdminModel(staffConfig, navMeshAgent, _computerModels);

            StaffModel = _sysAdminModel;

            CheckTaskEveryFrame().Forget();
        }

        public override void Enable()
        {
            base.Disable();

            foreach (var computer in _computerModels)
                computer.QualityChanged += _sysAdminModel.UpdateQueue;

            _sysAdminModel.ModelRemoved += CancelWork;
        }

        public override void Disable()
        {
            base.Enable();

            foreach (var computer in _computerModels)
                computer.QualityChanged -= _sysAdminModel.UpdateQueue;

            _sysAdminModel.ModelRemoved -= CancelWork;
        }

        protected override async UniTask Work()
        {
            if (_sysAdminModel.BrokenModels.IsEmpty())
                return;

            base.Work().Forget();
        }

        protected override async UniTask DoJob()
        {
            var timeToRepair = _sysAdminModel.GetTimeToRepair();

            await UniTask.Delay((int) (timeToRepair * 1000));

            _sysAdminModel.BrokenModels.Peek().ChangeQuality(100.0f);

            Debug.Log($"FIXED");
        }

        protected override void ProcessContaminationChange(float contaminationValue)
        {
            _sysAdminModel.SpeedModel.ChangeSpeedByContamination(contaminationValue);
        }
    }
}