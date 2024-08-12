using System.Collections.Generic;
using System.Threading;
using Model.Staff.Cleaner;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Views.Staff.Cleaner;

namespace Presenters.Character.Staff.Cleaner
{
    public class CleanerPresenter
    {
        private readonly CleanerConfig _cleanerConfig;
        private readonly Unity.AI.Navigation.NavMeshSurface _surface;
        private readonly ContaminationPresenter _contaminationPresenter;
        private readonly CleanerModel _cleanerModel;

        private readonly List<CleanerView.PatrolPoint> _patrolPoints;
        
        private readonly NavMeshPath _path;
        
        private CancellationTokenSource _cts;

        public CleanerPresenter(CleanerConfig cleanerConfig, NavMeshAgent agent,
            Unity.AI.Navigation.NavMeshSurface surface, ContaminationPresenter contaminationPresenter, List<CleanerView.PatrolPoint> patrolPoints)
        {
            InvariantChecker.CheckObjectInvariant(cleanerConfig, agent, surface, contaminationPresenter);

            _cleanerModel = new CleanerModel(cleanerConfig, agent);

            _surface = surface;

            _cts = new CancellationTokenSource();

            _contaminationPresenter = contaminationPresenter;
            
            _path = new NavMeshPath();

            _patrolPoints = patrolPoints;

            //CheckBrokenComputersInQueue().Forget();
        }

        public void GetRandomNavMeshPoint()
        {
            Vector3 randomPoint = Vector3.zero;
            
            var isPointCorrect = false;
            
            while (!isPointCorrect)
            {
                var randomPatrolPoint = _patrolPoints[Random.Range(0, _patrolPoints.Count)];
                
                NavMeshHit hit;
                NavMesh.SamplePosition(Random.insideUnitSphere * randomPatrolPoint.PointRadius + randomPatrolPoint.PointTransform.position, out hit,
                    randomPatrolPoint.PointRadius, NavMesh.AllAreas);
                randomPoint = hit.position;

                _cleanerModel.Agent.CalculatePath(randomPoint, _path);

                isPointCorrect = _path.status == NavMeshPathStatus.PathComplete;
                
                Debug.Log("Path founded");
            }
            
            _cleanerModel.Agent.SetDestination(randomPoint);
        }
    }
}