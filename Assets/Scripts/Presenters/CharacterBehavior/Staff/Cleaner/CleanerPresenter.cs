using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Model.Staff.Cleaner;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;
using Utils;
using Views.Staff.Cleaner;

namespace Presenters.Character.Staff.Cleaner
{
    public class CleanerPresenter : StaffPresenter
    {
        private readonly CleanerModel _cleanerModel;
        
        private readonly NavMeshPath _navMeshPath;

        public CleanerPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<CleanerView.CleaningPoint> cleaningPoints)
            : base(staffConfig, navMeshAgent, contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(staffConfig, navMeshAgent, contaminationPresenter, cleaningPoints);

            _cleanerModel = new CleanerModel(staffConfig, navMeshAgent, cleaningPoints);

            StaffModel = _cleanerModel;
            
            _navMeshPath = new NavMeshPath();

            CheckTaskEveryFrame().Forget();
        }


        protected override async UniTask Work()
        {
            if (_cleanerModel.CurrentCleaningPoint == null)
                return;
            
            base.Work().Forget();
        }

        protected override async UniTask DoJob()
        {
            var timeToClean = _cleanerModel.GetTimeToClean(_cleanerModel.LastContaminationValue);
            
            await UniTask.Delay((int) (timeToClean * 1000), cancellationToken: CTS.Token);

            ContaminationPresenter.Clean();
        }

        protected override void ProcessContaminationChange(float contaminationValue)
        {
            if (contaminationValue <= _cleanerModel.ValueReaction)
            {
                if(_cleanerModel.CurrentCleaningPoint != null)
                    CancelWork();
                
                return;
            }

            _cleanerModel.LastContaminationValue = contaminationValue;
            
            _cleanerModel.UpdateCleaningPoint(_navMeshPath);
        }
    }
}