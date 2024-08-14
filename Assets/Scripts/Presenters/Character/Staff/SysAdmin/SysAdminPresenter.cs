using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Staff.SysAdmin;
using ModestTree;
using Presenters.Character.Staff;
using Presenters.Computer;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;
using Utils;
using NavMeshSurface = Unity.AI.Navigation.NavMeshSurface;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter : StaffPresenter
    {
        private readonly NavMeshSurface _navMeshSurface;
        private readonly List<ComputerBuilderPresenter> _computerBuilderPresenters;

        private readonly SysAdminModel _sysAdminModel;

        private CancellationTokenSource _cts;
        
        public SysAdminPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<ComputerBuilderPresenter> computerBuilderPresenters,
            NavMeshSurface navMeshSurface) : base(staffConfig, navMeshAgent, contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(staffConfig, navMeshAgent, contaminationPresenter, computerBuilderPresenters, navMeshSurface);

            _navMeshSurface = navMeshSurface;

            _computerBuilderPresenters = computerBuilderPresenters;
            
            var computerModels = _computerBuilderPresenters.Select(presenter => presenter.Model).ToList();

            _sysAdminModel = new SysAdminModel(staffConfig, navMeshAgent, computerModels);

            StaffModel = _sysAdminModel;

            _cts = new CancellationTokenSource();
            
            CheckTaskEveryFrame(_cts).Forget();
        }

        public override void Enable()
        {
            base.Disable();
            
            foreach (var computer in _sysAdminModel.Computers)
                computer.QualityChanged += _sysAdminModel.UpdateQueue;

            foreach (var presenter in _computerBuilderPresenters)
                presenter.ComputerBuilded += BuildNavMesh;

            _sysAdminModel.ModelRemoved += CancelWork;
        }

        public override void Disable()
        {
            base.Enable();
            
            foreach (var computer in _sysAdminModel.Computers)
                computer.QualityChanged -= _sysAdminModel.UpdateQueue;

            foreach (var presenter in _computerBuilderPresenters)
                presenter.ComputerBuilded -= BuildNavMesh;
            
            _sysAdminModel.ModelRemoved -= CancelWork;
        }

        protected override async UniTask Work(CancellationTokenSource cts)
        {
            if (_sysAdminModel.BrokenModels.IsEmpty())
                return;
             
            base.Work(cts).Forget();
        }

        protected override async UniTask DoJob(CancellationTokenSource cts)
        {
            var timeToRepair = _sysAdminModel.GetTimeToRepair();

            await UniTask.Delay((int) (timeToRepair * 1000), cancellationToken : cts.Token);

            _sysAdminModel.BrokenModels.Peek().ChangeQuality(100.0f);
        }

        protected override void ProcessContaminationChange(float contaminationValue)
        {
            _sysAdminModel.SpeedModel.ChangeSpeedByContamination(contaminationValue);
        }
        
        
        private void BuildNavMesh(ComputerType computerType)
        {
            if (computerType == ComputerType.Common)
                _navMeshSurface.BuildNavMesh();
        }
        
        private void CancelWork()
        {
            _cts.Cancel();

            _cts = new CancellationTokenSource();
        }
    }
}