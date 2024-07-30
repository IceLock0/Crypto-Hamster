using System;
using System.Collections.Generic;
using Presenters.Computer;
using Presenters.ComputerQualityChange;
using Presenters.ComputerRepair;
using ScriptableObjects;
using Services.Fabric;
using UnityEngine;
using Views.UI.ComputerControlPanel.BuyButton;
using Views.UI.ComputerControlPanel.RepairButton;
using Zenject;

namespace Views.Computer
{
    public class ComputerView : MonoBehaviour
    {
        [SerializeField] private BuyButtonView _buyButtonView;
        [SerializeField] private RepairButtonView _repairButtonView;
        [SerializeField] private Transform _computerSpawnPoint;
        [SerializeField] private RepairKit _repairKit; //Заглушка на время пока нет инвентаря с термопастой/китом

        private ComputerPresenter _computerPresenter;
        private ComputerQualityChangePresenter _computerQualityChangePresenter;
        private ComputerRepairPresenter _computerRepairPresenter;

        [Inject]
        public void Initialize(IComputerFabric computerFabric, List<ComputerConfig> computerConfigs)
        {
            _computerPresenter = 
                new ComputerPresenter(_buyButtonView, computerFabric, this,_computerSpawnPoint.position, _computerSpawnPoint);
            _computerRepairPresenter =
                new ComputerRepairPresenter(_repairButtonView, _computerPresenter.Model, _repairKit);
            _computerQualityChangePresenter = 
                new ComputerQualityChangePresenter(_computerPresenter.Model, computerConfigs, _computerRepairPresenter);
        }

        private void OnEnable()
        {
            _computerPresenter.Enable();
            _computerQualityChangePresenter.Enable();
            _computerRepairPresenter.Enable();
        }

        private void OnDisable()
        {
            _computerPresenter.Disable();
            _computerQualityChangePresenter.Disable();
            _computerRepairPresenter.Disable();
        }

        public void DestroyComputer(GameObject gameObj)
        {
            Destroy(gameObj);
        }
    }
}