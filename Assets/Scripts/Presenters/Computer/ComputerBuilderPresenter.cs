using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Model.Computer;
using Model.Wallet;
using Presenters.Currency;
using ScriptableObjects;
using Services;
using Services.Fabric;
using UnityEngine;
using Utils;
using Views.Computer;
using Views.UI.ComputerControlPanel.BuyButton;

namespace Presenters.Computer
{
    public class ComputerBuilderPresenter
    {
        private readonly BuyButtonView _buyButtonView;
        private readonly IComputerFactory _computerFactory;
        private readonly Transform _computerParent;
        private readonly GameObjectDestroyerService _gameObjectDestroyerService;
        private readonly WalletModel _walletModel;
        private readonly List<ComputerConfig> _computerConfigs;
        
        private GameObject _currentComputerModel;

        public ComputerBuilderPresenter(BuyButtonView buyButtonView, IComputerFactory computerFactory,  
            Transform computersParent, ComputerModel model, 
            GameObjectDestroyerService gameObjectDestroyerServiceService, WalletModel walletModel, List<ComputerConfig> computerConfigs)
        {
            InvariantChecker.CheckObjectInvariant(buyButtonView, computerFactory, computerFactory,
                computersParent, model, gameObjectDestroyerServiceService, walletModel, computerConfigs);

            Model = model;
            _buyButtonView = buyButtonView;
            _computerFactory = computerFactory;
            _computerParent = computersParent;
            _gameObjectDestroyerService = gameObjectDestroyerServiceService;
            _walletModel = walletModel;
            _computerConfigs = computerConfigs;
        }

        public ComputerModel Model { get;  }

        public event Action<ComputerType> ComputerBuilded;

        public void Enable()
        {
            _buyButtonView.BuyComputerButtonClicked += OnBuyComputerButtonClicked;
        }

        public void Disable()
        {
            _buyButtonView.BuyComputerButtonClicked -= OnBuyComputerButtonClicked;
        }

        private void OnBuyComputerButtonClicked()
        {
            TryBuyComputer();
        }

        private void TryBuyComputer()
        {
            var targetComputerType = Model.ComputerType + 1;
            if (!Enum.IsDefined(typeof(ComputerType), targetComputerType))
                throw new ArgumentOutOfRangeException();
            var targetCost = _computerConfigs.FirstOrDefault(x => x.ComputerType == targetComputerType)!.ComputerPrice;
            if (_walletModel.Currencies[typeof(Cash)].Amount < targetCost)
                throw new ArgumentOutOfRangeException("Not enough money");
            BuyComputer(targetCost);
        }

        private void BuyComputer(float cost)
        {
            _walletModel.RemoveCurrency(typeof(Cash), cost);
            ChangeModel();
            TryDestroyOldComputer();
            TryBuildNewComputer();
        }

        private void ChangeModel()
        {
            Model.ChangeType((int) (Model.ComputerType + 1));
        }


        private void TryDestroyOldComputer()
        {
            if (_currentComputerModel == null)
                return;
            _gameObjectDestroyerService.DestroyGameObject(_currentComputerModel);
        }
        
        private void TryBuildNewComputer()
        {
            //Нехватка бабок и тп обработка невозможности билда
            _currentComputerModel = _computerFactory.Create(Model.ComputerType, Model.Position, _computerParent) as GameObject;
            ComputerBuilded?.Invoke(Model.ComputerType);
        }
    }
}