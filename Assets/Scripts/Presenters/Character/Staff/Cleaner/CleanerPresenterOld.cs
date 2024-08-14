using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Model.Staff.Cleaner;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Views.Staff.Cleaner;
using Random = UnityEngine.Random;

namespace Presenters.Character.Staff.Cleaner
{
    public class CleanerPresenterOld
    {
        private readonly CleanerConfig _cleanerConfig;
        private readonly Unity.AI.Navigation.NavMeshSurface _surface;
        private readonly ContaminationPresenter _contaminationPresenter;
        private readonly CleanerModel _cleanerModel;

        private readonly NavMeshPath _path;

        private CancellationTokenSource _cts;

        public CleanerPresenterOld(CleanerConfig cleanerConfig, NavMeshAgent agent,
            Unity.AI.Navigation.NavMeshSurface surface, ContaminationPresenter contaminationPresenter,
            List<CleanerView.CleaningPoint> cleaningPoints)
        {
            InvariantChecker.CheckObjectInvariant(cleanerConfig, agent, surface, contaminationPresenter);

            _cleanerModel = new CleanerModel(cleanerConfig, agent, cleaningPoints);

            _surface = surface;

            _cts = new CancellationTokenSource();

            _contaminationPresenter = contaminationPresenter;

            _path = new NavMeshPath();
        }

        public void Enable()
        {
            _contaminationPresenter.ContaminationChanged += StartWork;
        }

        public void Disable()
        {
            _contaminationPresenter.ContaminationChanged -= StartWork;
        }

        private async void StartWork(float contamination)
        {
            if (_cleanerModel.HasWork != false || contamination < _cleanerModel.ContaminationValueReaction)
                return;
            
            Debug.Log("Work started");
            
            _cleanerModel.GetPoint(contamination);

            await StartCleaningProcess(contamination);
        }

        private async UniTask StartCleaningProcess(float contamination)
        {
            _cleanerModel.StartWork();

            try
            {
                await GoToDestination(_cts.Token);

                await Clean(_cts.Token, contamination);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Cleaning process was canceled");
                _cleanerModel.CompletedUnits--;
            }
            finally
            {
                _cleanerModel.EndWork();
                
                _cleanerModel.RemoveCurrentCleaningPoint();
            
                GoToSourcePoint();
            }
        }
        
        private async UniTask GoToDestination(CancellationToken cancellationToken)
        {
            Vector3 randomPoint = Vector3.zero;

            var isPointCorrect = false;

            while (!isPointCorrect)
            {
                var cleaningPoint = _cleanerModel.CurrentCleaningPoint;

                NavMeshHit hit;
                NavMesh.SamplePosition(
                    Random.insideUnitSphere * cleaningPoint.PointRadius + cleaningPoint.PointTransform.position,
                    out hit,
                    cleaningPoint.PointRadius, NavMesh.AllAreas);
                randomPoint = hit.position;

                _cleanerModel.Agent.CalculatePath(randomPoint, _path);

                isPointCorrect = _path.status == NavMeshPathStatus.PathComplete;
            }

            _cleanerModel.Agent.SetDestination(randomPoint);

            await UniTask.WaitUntil(() =>
                    !_cleanerModel.Agent.pathPending && _cleanerModel.Agent.remainingDistance <= _cleanerModel.Agent.stoppingDistance, cancellationToken : cancellationToken
            );
        }
        
        private async UniTask Clean(CancellationToken cancellationToken, float contamination)
        {
            var timeToClean = _cleanerModel.GetTimeToClean(contamination);

            
            
            await UniTask.Delay((int) (timeToClean * 1000), cancellationToken : cancellationToken);

            _contaminationPresenter.ChangeContaminationByCleaner();
        }
        
        private void GoToSourcePoint()
        {
            _cleanerModel.Agent.SetDestination(_cleanerModel.SourcePoint.position);
        }
    }
}