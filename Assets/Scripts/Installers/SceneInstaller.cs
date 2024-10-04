using System.Collections.Generic;
using Model.ComputerCells;
using UnityEngine;
using Views.ComputerCell;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private List<ComputerCellView> _computerCellViews;

        public override void InstallBindings()
        {
            BindComputerCellsModel();
        }

        private void BindComputerCellsModel()
        {
            Container.Bind<ComputerCellsModel>()
                .FromInstance(new ComputerCellsModel(_computerCellViews))
                .AsSingle()
                .NonLazy();
        }
    }
}