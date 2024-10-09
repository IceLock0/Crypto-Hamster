using UnityEngine;
using Views.Empty.Electricity;
using Zenject;

namespace Installers.GameObjectInstallers.Electricity
{
    public class ElectricityInstaller : MonoInstaller<ElectricityInstaller>
    {
        [SerializeField] private ElectricityFillView _electricityFillView;
        [SerializeField] private ElectricityIconView _electricityIconView;
        public override void InstallBindings()
        {
            BindElectricityFillView();
            BindElectricityIconView();
        }

        private void BindElectricityIconView()
        {
            Container.Bind<ElectricityIconView>()
                .FromInstance(_electricityIconView)
                .AsSingle()
                .NonLazy();
        }

        private void BindElectricityFillView()
        {
            Container.Bind<ElectricityFillView>()
                .FromInstance(_electricityFillView)
                .AsSingle()
                .NonLazy();
        }
    }
}