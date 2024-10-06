using Services;
using Services.Fabric;
using Services.Fabric.Staff;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectDestroyerService _gameObjectDestroyerService;

        public override void InstallBindings()
        {
            BindGameObjectDestroyerService();
            BindFabricService();
            BindInputService();
        }

        private void BindGameObjectDestroyerService()
        {
            Container.Bind<GameObjectDestroyerService>()
                .FromInstance(_gameObjectDestroyerService)
                .AsSingle()
                .NonLazy();
        }

        private void BindInputService()
        {
            Container.Bind<InputService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindFabricService()
        {
            Container.Bind<IComputerFactory>()
                .To<ComputerFactory>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IStaffFactory>()
                .To<StaffFactory>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IMopPointFabric>()
                .To<MopPointFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}