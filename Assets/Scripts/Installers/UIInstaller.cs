using System.ComponentModel;
using UnityEngine;
using Views.UI.BuyCellButton;
using Views.UI.Electricity.ButtonPayment;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private BuyCellButtonView _buyCellButtonView;
        [SerializeField] private ElectricityUIButtonPayment _electricityUIButtonPayment;
        
        public override void InstallBindings()
        {
            BindBuyCellButton();
            BindElectricityPaymentButton();
        }

        private void BindBuyCellButton()
        {
            Container.Bind<BuyCellButtonView>()
                .FromInstance(_buyCellButtonView)
                .AsSingle()
                .NonLazy();
        }

        private void BindElectricityPaymentButton()
        {
            Container.Bind<ElectricityUIButtonPayment>()
                .FromInstance(_electricityUIButtonPayment)
                .AsSingle()
                .NonLazy();
        }
    }
}