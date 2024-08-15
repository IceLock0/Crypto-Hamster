using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Model.Staff;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Presenters.Character.Staff
{
    public abstract class StaffPresenter
    {
        private readonly StaffConfig _staffConfig;
        private readonly NavMeshAgent _navMeshAgent;
        
        protected readonly ContaminationPresenter ContaminationPresenter;

        protected StaffModel StaffModel;

        protected bool IsChecking = true;

        protected CancellationTokenSource CTS;

        public StaffPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent, ContaminationPresenter contaminationPresenter)
        {
            _staffConfig = staffConfig;
            _navMeshAgent = navMeshAgent;
            ContaminationPresenter = contaminationPresenter;

            CTS = new CancellationTokenSource();
        }

        public virtual void Enable()
        {
            ContaminationPresenter.ContaminationChanged += ProcessContaminationChange;
        }

        public virtual void Disable()
        {
            ContaminationPresenter.ContaminationChanged -= ProcessContaminationChange;
        }

        protected async UniTaskVoid CheckTaskEveryFrame()
        {
            while (IsChecking)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);

                if (StaffModel.HasWork == false)
                {
                    if (StaffModel.CompletedUnits >= StaffModel.Efficiency)
                        await Relax();

                    else 
                        await Work();
                }
            }
        }

        protected virtual async UniTask Work()
        {
            StaffModel.StartWork();

            try
            {
                await GoToDestination();

                await DoJob();
            }
            catch (OperationCanceledException e)
            {
                Debug.Log($"Work was canceled. Exc data: {e.Data}, Exc message {e.Message}");
                StaffModel.CompletedUnits--;
            }
            finally
            {
                StaffModel.EndWork();

                GoToSourcePoint();
                
                StaffModel.RemoveProcessedData();
            }
        }

        protected abstract UniTask DoJob();
        
        protected abstract void ProcessContaminationChange(float contaminationValue);
        
        protected void CancelWork()
        {
            CTS.Cancel();

            CTS = new CancellationTokenSource();
        }
        
        private async UniTask GoToDestination()
        {
            if (StaffModel.Agent.isActiveAndEnabled == false)
                return;
            
            StaffModel.Agent.SetDestination(StaffModel.DestinationPoint);

            await UniTask.WaitUntil(() =>
                    !StaffModel.Agent.pathPending && StaffModel.Agent.remainingDistance <= StaffModel.Agent.stoppingDistance, cancellationToken: CTS.Token
            );
        }
        
        private async UniTask Relax()
        {
            Debug.Log($"Model {StaffModel} RELAX");
        
            StaffModel.ResetCompletedUnits();

            await UniTask.Delay((int) (StaffModel.RelaxTime * 1000));
        }

        private void GoToSourcePoint()
        {
            StaffModel.Agent.SetDestination(StaffModel.SourcePoint.position);
        }
        
    }
}