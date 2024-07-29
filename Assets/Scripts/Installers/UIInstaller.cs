using System.ComponentModel;
using UnityEngine;
using Views.UI.BuyCellButton;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private BuyCellButtonView _buyCellButtonView;
        
        public override void InstallBindings()
        {
            BindBuyCellButton();
        }

        private void BindBuyCellButton()
        {
            Container.Bind<BuyCellButtonView>()
                .FromInstance(_buyCellButtonView)
                .AsSingle()
                .NonLazy();
        }
    }
}