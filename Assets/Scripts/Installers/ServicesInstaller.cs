using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineService _coroutineService;
        
        public override void InstallBindings()
        {
            Container.Bind<InputService>().FromNew().AsSingle().NonLazy();
            Container.Bind<ICoroutineService>().FromComponentInNewPrefab(_coroutineService).AsSingle().NonLazy();
        }
    }
}