using Model.Computer;
using Presenters.Computer;
using Presenters.Computer.ComputerCryptoChanger;
using Presenters.Computer.ComputerElectricityConsumation;
using Presenters.Computer.ComputerQualityChange;
using Presenters.ComputerMiner;
using Presenters.ComputerRepair;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers.ComputerCell
{

    public class ComputerInstaller : MonoInstaller<ComputerInstaller>
    {
        [SerializeField] private Transform _computerSpawnPoint;
        
        [Header("Parameters will be upload from saves, DEBUG OPTION!!!!!!")] 
        [SerializeField] private int _startComputerType;
        [SerializeField] private float _startQuality;
        public override void InstallBindings()
        {
            BindComputerModel();
            BindComputerSpawnPoint();
            BindComputerBuilderPresenter();
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

        private void BindComputerBuilderPresenter()
        {
            Container.Bind<ComputerBuilderPresenter>()
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