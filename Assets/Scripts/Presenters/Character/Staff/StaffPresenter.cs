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
        
        public StaffPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent, ContaminationPresenter contaminationPresenter)
        {
            _staffConfig = staffConfig;
            _navMeshAgent = navMeshAgent;
            ContaminationPresenter = contaminationPresenter;
        }

        public virtual void Enable()
        {
            ContaminationPresenter.ContaminationChanged += ProcessContaminationChange;
        }

        public virtual void Disable()
        {
            ContaminationPresenter.ContaminationChanged -= ProcessContaminationChange;
        }

        protected async UniTaskVoid CheckTaskEveryFrame(CancellationTokenSource cts = default)
        {
            while (IsChecking)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);

                if (StaffModel.HasWork == false)
                {
                    if (StaffModel.CompletedUnits >= StaffModel.Efficiency)
                        await Relax();

                    else 
                        await Work(cts);
                }
            }
        }

        protected virtual async UniTask Work(CancellationTokenSource cts)
        {
            StaffModel.StartWork();

            try
            {
                await GoToDestination(cts);

                await DoJob(cts);
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

        protected abstract UniTask DoJob(CancellationTokenSource cts);
        
        protected abstract void ProcessContaminationChange(float contaminationValue);
        
        private async UniTask GoToDestination(CancellationTokenSource cancellationToken)
        {
            StaffModel.Agent.SetDestination(StaffModel.DestinationPoint);
            
            await UniTask.WaitUntil(() =>
                    !StaffModel.Agent.pathPending && StaffModel.Agent.remainingDistance <= StaffModel.Agent.stoppingDistance, cancellationToken : cancellationToken.Token
            );
        }
        
        private async UniTask Relax()
        {
            StaffModel.ResetCompletedUnits();

            await UniTask.Delay((int) (StaffModel.RelaxTime * 1000));
        }

        private void GoToSourcePoint()
        {
            StaffModel.Agent.SetDestination(StaffModel.SourcePoint.position);
        }
    }
}