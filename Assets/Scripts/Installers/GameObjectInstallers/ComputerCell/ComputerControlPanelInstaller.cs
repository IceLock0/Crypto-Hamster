using System.Collections.Generic;
using UnityEngine;
using Views.UI.ComputerControlPanel.BuyButton;
using Views.UI.ComputerControlPanel.ChangeCryptoButton;
using Views.UI.ComputerControlPanel.RepairButton;
using Zenject;

namespace Installers.GameObjectInstallers.ComputerCell
{

    public class ComputerControlPanelInstaller : MonoInstaller<ComputerControlPanelInstaller>
    {
        [SerializeField] private BuyButtonView _buyButtonView;
        [SerializeField] private RepairButtonView _repairButtonView;
        [SerializeField] private List<ChangeCryptoButtonView> _cryptoChangeButonViews;
        
        public override void InstallBindings()
        {
            BindButtonView();
            BindRepairButtonView();
            BindCryptoChangeButtonViews();
        }

        private void BindCryptoChangeButtonViews()
        {
            Container.Bind<List<ChangeCryptoButtonView>>()
                .FromInstance(_cryptoChangeButonViews)
                .AsSingle()
                .NonLazy();
        }

        private void BindButtonView()
        {
            Container.Bind<BuyButtonView>().
                FromInstance(_buyButtonView)
                .AsSingle()
                .NonLazy();
        }

        private void BindRepairButtonView()
        {
            Container.Bind<RepairButtonView>()
                .FromInstance(_repairButtonView)
                .AsSingle()
                .NonLazy();
        }
    }

}