using System.Collections.Generic;
using Presenters.Mop;
using Presenters.Room;
using ScriptableObjects;
using Services;
using Services.Fabric;
using UnityEngine;
using Views.Staff.Cleaner;
using Zenject;

namespace Views.Mop
{
    public class MopView : MonoBehaviour
    {
        private MopCleaningPointPresenter _mopCleaningPointPresenter;

        [Inject]
        public void Initialize(List<CleanerView.CleaningPoint> cleaningPoints,
            ContaminationPresenter contaminationPresenter, MopConfig mopConfig,
            GameObjectDestroyerService gameObjectDestroyerService, IMopPointFabric mopPointFabric)
        {
            _mopCleaningPointPresenter = new MopCleaningPointPresenter(this, cleaningPoints, contaminationPresenter, mopConfig, gameObjectDestroyerService, mopPointFabric);
            _mopCleaningPointPresenter.OnEnable();
        }

        private void OnDisable()
        {
            _mopCleaningPointPresenter.OnDisable();
        }
    }
}