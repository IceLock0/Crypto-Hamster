using System;
using Enums;
using Model.Computer;
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
        private readonly IComputerFabric _computerFabric;
        private readonly Transform _computerParent;
        private readonly GameObjectDestroyerService _gameObjectDestroyerService;
        
        private GameObject _currentComputerModel;

        public ComputerBuilderPresenter(BuyButtonView buyButtonView, IComputerFabric computerFabric,  Transform computersParent, ComputerModel model, GameObjectDestroyerService gameObjectDestroyerServiceService)
        {
            InvariantChecker.CheckObjectInvariant(buyButtonView, computerFabric, computerFabric,
                computersParent, model, gameObjectDestroyerServiceService);

            Model = model;
            _buyButtonView = buyButtonView;
            _computerFabric = computerFabric;
            _computerParent = computersParent;
            _gameObjectDestroyerService = gameObjectDestroyerServiceService;
        }

        public ComputerModel Model { get;  }

        public event Action<ComputerType> ComputerMeshCreated;

        public void Enable()
        {
            _buyButtonView.BuyComputerButtonClicked += BuyComputerComputer;
        }

        public void Disable()
        {
            _buyButtonView.BuyComputerButtonClicked -= BuyComputerComputer;
        }

        private void BuyComputerComputer()
        {
            Model.ChangeType((int)(Model.ComputerType + 1));
            TryDestroyOldComputer();
            TryBuildNewComputer();
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
            _currentComputerModel = _computerFabric.Create(Model.ComputerType, Model.Position, _computerParent) as GameObject;
            ComputerMeshCreated?.Invoke(Model.ComputerType);
        }
    }
}