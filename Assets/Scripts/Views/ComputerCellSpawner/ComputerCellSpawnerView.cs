using System;
using System.Collections.Generic;
using Presenters.ComputerCellSpawner;
using UnityEngine;
using Views.ComputerCell;
using Views.UI.BuyCellButton;
using Zenject;

namespace Views.ComputerCellSpawner
{
    public class ComputerCellSpawnerView : MonoBehaviour
    {
        [SerializeField] private List<ComputerCellView> _computerCellViews;

        private ComputerCellSpawnerPresenter _presenter;

        [Inject]
        private void Initialize(BuyCellButtonView buyCellButtonView)
        {
            _presenter = new ComputerCellSpawnerPresenter(_computerCellViews,buyCellButtonView);
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