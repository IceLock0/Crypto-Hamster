using Services;
using Services.Fabric;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineService _coroutineService;

        public override void InstallBindings()
        {
            BindInputService();
            BindCoroutineService();
            BindFabricService();
        }

        private void BindInputService()
        {
            Container.Bind<InputService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCoroutineService()
        {
            Container.Bind<ICoroutineService>()
                .FromComponentInNewPrefab(_coroutineService)
                .AsSingle()
                .NonLazy();
        }

        private void BindFabricService()
        {
            Container.Bind<IComputerFabric>()
                .To<ComputerFabric>()
                .AsSingle()
                .NonLazy();
        }
    }
}