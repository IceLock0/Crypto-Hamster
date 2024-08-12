using System;
using Presenters.Character.Staff.Cleaner;
using Presenters.Room;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Views.Staff.Cleaner
{
    public class CleanerView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Unity.AI.Navigation.NavMeshSurface _surface;

        [SerializeField] private List<CleaningPoint> _cleaningPoints;
        
        private CleanerPresenter _presenter;
        
        private CleanerConfig _cleanerConfig;
        
        private ContaminationPresenter _contaminationPresenter;

        [Inject]
        public void Initialize(CleanerConfig cleanerConfig, ContaminationPresenter contaminationPresenter)
        {
            _cleanerConfig = cleanerConfig;
            _contaminationPresenter = contaminationPresenter;

            _presenter = new CleanerPresenter(_cleanerConfig, _agent, _surface, _contaminationPresenter, _cleaningPoints);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;

            foreach (var patrolPoint in _cleaningPoints)
            {
                var point = patrolPoint.PointTransform;
                var radius = patrolPoint.PointRadius;
                
                Gizmos.DrawWireSphere(point.position , radius);
            }

        }

        private void OnEnable()
        {
            _presenter.Enable();
        }
        
        private void OnDisable()
        {
            _presenter.Disable();
        }

        [Serializable]
        public class CleaningPoint
        {
            [SerializeField] private Transform _pointTransform;
            [SerializeField] private float _pointRadius;

            public Transform PointTransform => _pointTransform;
            public float PointRadius => _pointRadius;
        }
    }
}