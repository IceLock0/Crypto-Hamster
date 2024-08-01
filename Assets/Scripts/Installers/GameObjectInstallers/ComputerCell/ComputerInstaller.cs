using Model.Computer;
using Presenters.Computer;
using Presenters.ComputerCryptoChanger;
using Presenters.ComputerElectricityConsumation;
using Presenters.ComputerMiner;
using Presenters.ComputerQualityChange;
using Presenters.ComputerRepair;
using UnityEngine;
using Views.Computer;
using Zenject;

namespace Installers.GameObjectInstallers.ComputerCell
{

    public class ComputerInstaller : MonoInstaller<ComputerInstaller>
    {
        [SerializeField] private ComputerView _computerView;
        [SerializeField] private Transform _computerSpawnPoint;
        
        [Header("Parameters will be upload from saves, DEBUG OPTION!!!!!!")] 
        [SerializeField] private int _startComputerType;
        [SerializeField] private float _startQuality;
        public override void InstallBindings()
        {
            BindComputerModel();
            BindComputerSpawnPoint();
            BindComputerView();
            BindComputerPresenter();
            BindComputerRepairPresenter();
            BindQualityChangePresenter();
            BindMinerPresenter();
            BindCryptoChangePresenter();
            BindElectricityConsumationPresenter();
        }

        private void BindElectricityConsumationPresenter()
        {
            Container.Bind<ComputerElectricityConsumationPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCryptoChangePresenter()
        {
            Container.Bind<ComputerCryptoChangePresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMinerPresenter()
        {
            Container.Bind<ComputerMinerPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindQualityChangePresenter()
        {
            Container.Bind<ComputerQualityChangePresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindComputerRepairPresenter()
        {
            Container.Bind<ComputerRepairPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindComputerSpawnPoint()
        {
            Container.BindInstance(_computerSpawnPoint)
                .AsSingle()
                .NonLazy();
        }

        private void BindComputerView()
        {
            Container.Bind<ComputerView>()
                .FromInstance(_computerView)
                .AsSingle();
        }

        private void BindComputerPresenter()
        {
            Container.Bind<ComputerPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindComputerModel()
        {
            Container.Bind<ComputerModel>()
                .FromInstance(new ComputerModel(_startComputerType,_startQuality,_computerSpawnPoint.position))
                .AsSingle()
                .NonLazy();
        }
    }

}