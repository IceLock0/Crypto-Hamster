using UnityEngine;
using Views.UI.Phone.Apps.HomeButton;
using Zenject;

namespace Installers.GameObjectInstallers.PhoneInstaller
{
    public class PhoneInstaller : MonoInstaller<PhoneInstaller>
    {
        [SerializeField] private HomeButtonView _homeButtonView;

        public override void InstallBindings()
        {
            BindHomeButtonView();
        }

        private void BindHomeButtonView()
        {
            Container.Bind<HomeButtonView>()
                .FromInstance(_homeButtonView)
                .AsSingle()
                .NonLazy();
        }
    }
}