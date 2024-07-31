using System;
using System.Collections.Generic;
using Model.Wallet;
using Presenters.Computer;
using Presenters.ComputerCryptoChanger;
using Presenters.ComputerMiner;
using Presenters.ComputerQualityChange;
using Presenters.ComputerRepair;
using ScriptableObjects;
using Services.Fabric;
using UnityEngine;
using Views.UI.ComputerControlPanel.BuyButton;
using Views.UI.ComputerControlPanel.ChangeCryptoButton;
using Views.UI.ComputerControlPanel.RepairButton;
using Zenject;

namespace Views.Computer
{
    public class ComputerView : MonoBehaviour
    {
        [SerializeField] private BuyButtonView _buyButtonView;
        [SerializeField] private RepairButtonView _repairButtonView;
        [SerializeField] private List<ChangeCryptoButtonView> _cryptoChangeButonViews;
        [SerializeField] private Transform _computerSpawnPoint;
        [SerializeField] private RepairKit _repairKit; //Заглушка на время пока нет инвентаря с термопастой/китом

        private ComputerPresenter _computerPresenter;
        private ComputerQualityChangePresenter _computerQualityChangePresenter;
        private ComputerRepairPresenter _computerRepairPresenter;
        private ComputerMinerPresenter _computerMinerPresenter;
        private ComputerCryptoChangePresenter _cryptoChangePresenter;

        [Inject]
        public void Initialize(IComputerFabric computerFabric, List<ComputerConfig> computerConfigs, WalletModel walletModel)
        {
            _computerPresenter = 
                new ComputerPresenter(_buyButtonView, computerFabric, this,_computerSpawnPoint.position, _computerSpawnPoint);
            _computerRepairPresenter =
                new ComputerRepairPresenter(_repairButtonView, _computerPresenter.Model, _repairKit);
            _computerQualityChangePresenter = 
                new ComputerQualityChangePresenter(_computerPresenter.Model, computerConfigs, _computerRepairPresenter);
            _computerMinerPresenter =
                new ComputerMinerPresenter(_computerPresenter.Model, computerConfigs, _computerRepairPresenter,
                    walletModel);
            _cryptoChangePresenter =
                new ComputerCryptoChangePresenter(_computerPresenter.Model, _cryptoChangeButonViews);
        }

        private void OnEnable()
        {
            _computerPresenter.Enable();
            _computerQualityChangePresenter.Enable();
            _computerRepairPresenter.Enable();
            _computerMinerPresenter.Enable();
            _cryptoChangePresenter.Enable();
        }

        private void OnDisable()
        {
            _computerPresenter.Disable();
            _computerQualityChangePresenter.Disable();
            _computerRepairPresenter.Disable();
            _computerMinerPresenter.Disable();
            _cryptoChangePresenter.Disable();
        }

        public void DestroyComputer(GameObject gameObj)
        {
            Destroy(gameObj);
        }
    }
}