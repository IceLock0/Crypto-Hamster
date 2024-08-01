using System.Collections.Generic;
using Presenters.UI.ComputerControlPanel.ComputerHealthbar;
using UnityEngine;
using Views.UI.ComputerControlPanel.BuyButton;
using Views.UI.ComputerControlPanel.ChangeCryptoButton;
using Views.UI.ComputerControlPanel.ComputerHealthbar;
using Views.UI.ComputerControlPanel.RepairButton;
using Zenject;

namespace Installers.GameObjectInstallers.ComputerCell
{

    public class ComputerControlPanelInstaller : MonoInstaller<ComputerControlPanelInstaller>
    {
        [SerializeField] private BuyButtonView _buyButtonView;
        [SerializeField] private RepairButtonView _repairButtonView;
        [SerializeField] private List<ChangeCryptoButtonView> _cryptoChangeButonViews;
        [SerializeField] private ComputerHealthbarView _computerHealthbarView;
        
        public override void InstallBindings()
        {
            BindComputerHealthbarView();
            BindButtonView();
            BindRepairButtonView();
            BindCryptoChangeButtonViews();
            BindComputerHealthbarPresenter();
        }

        private void BindComputerHealthbarPresenter()
        {
            Container.Bind<ComputerHealthbarPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindComputerHealthbarView()
        {
            Container.Bind<ComputerHealthbarView>()
                .FromInstance(_computerHealthbarView)
                .AsSingle()
                .NonLazy();
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