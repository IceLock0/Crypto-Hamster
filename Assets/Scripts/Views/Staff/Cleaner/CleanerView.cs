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
    public class CleanerView : StaffView
    {
        [SerializeField] private List<CleaningPoint> _cleaningPoints;
        
        [Inject]
        public void Initialize(CleanerConfig cleanerConfig)
        {
            StaffConfig = cleanerConfig;

            StaffPresenter = new CleanerPresenter(StaffConfig, Agent, ContaminationPresenter, _cleaningPoints);
        }
        
        [Serializable]
        public class CleaningPoint
        {
            [SerializeField] private Transform _pointTransform;
            [SerializeField] private float _pointRadius;

            public Transform PointTransform => _pointTransform;
            public float PointRadius => _pointRadius;
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

    }
}