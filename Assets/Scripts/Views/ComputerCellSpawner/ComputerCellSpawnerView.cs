using Model.ComputerCells;
using Model.Wallet;
using Presenters.ComputerCellSpawner;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.ComputerCellSpawner
{
    public class ComputerCellSpawnerView : MonoBehaviour
    {
        private ComputerCellSpawnerPresenter _presenter;

        [Inject]
        private void Initialize(ComputerCellsModel computerCellsModel,
            CostConfig costConfig, WalletModel walletModel)
        {
            _presenter =
                new ComputerCellSpawnerPresenter(computerCellsModel, costConfig, walletModel);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}