using System;
using Presenters.Character.Staff.Cleaner;
using Presenters.Room;
using System.Collections.Generic;
using System.Linq;
using Enums.Staff;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Views.Staff.Cleaner
{
    public class CleanerView : StaffView
    {
        private List<CleaningPoint> _cleaningPoints;

        [Inject]
        public void Initialize(List<CleanerConfig> cleanerConfigs, List<CleaningPoint> cleaningPoints)
        {
            StaffConfig = cleanerConfigs.FirstOrDefault(config => config.UpgradeType == StaffUpgradeType.Common);

            _cleaningPoints = cleaningPoints;

            Agent = GetComponent<NavMeshAgent>();

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
    }
}