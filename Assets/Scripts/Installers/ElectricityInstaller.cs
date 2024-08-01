using Model.Electricity;
using Zenject;

namespace Installers
{

    public class ElectricityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ElectricityModel>().AsSingle().NonLazy();
        }
    }

}