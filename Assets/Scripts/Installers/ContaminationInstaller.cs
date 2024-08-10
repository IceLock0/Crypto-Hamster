using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using Views.Room;
using Zenject;

namespace Installers
{
    public class ContaminationInstaller : MonoInstaller
    {
        [SerializeField] private ContaminationView _contaminationView;

        public override void InstallBindings()
        {
            var contaminationConfig = Container.Resolve<ContaminationConfig>();
            
            Container.Bind<ContaminationView>()
                .FromInstance(_contaminationView)
                .AsSingle();
            
            Container.Bind<ContaminationPresenter>()
                .AsSingle()
                .WithArguments(contaminationConfig, _contaminationView);
        }
    }
}