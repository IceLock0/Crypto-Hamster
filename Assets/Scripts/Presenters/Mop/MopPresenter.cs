using System.Collections.Generic;
using Presenters.Room;
using ScriptableObjects;
using Services;
using Services.Fabric;
using UnityEngine;
using Utils;
using Views.Mop;
using Views.Staff.Cleaner;

namespace Presenters.Mop
{
    public class MopCleaningPointPresenter
    {
        private readonly MopView _mopView;

        private readonly List<CleanerView.CleaningPoint> _points;
        private readonly ContaminationPresenter _contaminationPresenter;
        private readonly MopConfig _mopConfig;

        private readonly GameObjectDestroyerService _gameObjectDestroyerService;
        private readonly IMopPointFabric _mopPointFabric;
        
        private GameObject _currentPointGO;

        public MopCleaningPointPresenter(MopView mopView, List<CleanerView.CleaningPoint> points,
            ContaminationPresenter contaminationPresenter, MopConfig mopConfig,
            GameObjectDestroyerService gameObjectDestroyerService, IMopPointFabric mopPointFabric)
        {
            InvariantChecker.CheckObjectInvariant(mopView, points, contaminationPresenter, mopConfig,
                gameObjectDestroyerService, mopPointFabric);

            _mopView = mopView;

            _points = points;
            _contaminationPresenter = contaminationPresenter;
            _mopConfig = mopConfig;

            _gameObjectDestroyerService = gameObjectDestroyerService;
            _mopPointFabric = mopPointFabric;
        }

        public void OnEnable()
        {
            _contaminationPresenter.ContaminationChanged += OnContaminationChanged;
        }

        public void OnDisable()
        {
            _contaminationPresenter.ContaminationChanged -= OnContaminationChanged;
        }

        private void OnContaminationChanged(float value)
        {
            if (value <= _mopConfig.Power)
            {
                if (_currentPointGO)
                {
                    _gameObjectDestroyerService.DestroyGameObject(_currentPointGO);
                    _currentPointGO = null;
                }
                
                return;
            }

            if (_currentPointGO)
                return;

            var cleaningPointPosition = GetRandomCleaningPointPosition();

            _currentPointGO = _mopPointFabric.Create(cleaningPointPosition, Quaternion.identity);
        }

        private Vector3 GetRandomCleaningPointPosition()
        {
            var rndPoint = _points[Random.Range(0, _points.Count - 1)];

            var rndOffsetX = Random.Range(0, rndPoint.PointRadius);
            var rndOffsetY = Random.Range(0, rndPoint.PointRadius);

            var offsetVector = new Vector3(rndOffsetX, 0, rndOffsetY);

            var targetPoint = rndPoint.PointTransform.position + offsetVector;

            return targetPoint;
        }
    }
}