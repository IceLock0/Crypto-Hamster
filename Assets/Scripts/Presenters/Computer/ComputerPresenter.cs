using System;
using Enums;
using Model.Computer;
using Services.Fabric;
using UnityEngine;
using Utils;
using Views.Computer;
using Views.UI.ComputerControlPanel.BuyButton;

namespace Presenters.Computer
{
    public class ComputerPresenter
    {
        private readonly ComputerView _view;

        private readonly BuyButtonView _buyButtonView;
        private readonly IComputerFabric _computerFabric;
        private readonly Vector3 _computerPosition;
        private readonly Transform _computerParent;
        
        private GameObject _currentComputerModel;

        public ComputerPresenter(BuyButtonView buyButtonView, IComputerFabric computerFabric, ComputerView view,
            Vector3 computerPosition, Transform computersParent)
        {
            InvariantChecker.CheckObjectInvariant(buyButtonView, computerFabric, view, computerFabric, computerPosition,
                computersParent);

            Model = new ComputerModel((int)ComputerType.Empty, 100f, 100f, computerPosition);

            _view = view;
            _buyButtonView = buyButtonView;
            _computerFabric = computerFabric;
            _computerPosition = computerPosition;
            _computerParent = computersParent;
        }

        public ComputerModel Model { get; private set; }

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
            _view.DestroyComputer(_currentComputerModel);
        }
        
        private void TryBuildNewComputer()
        {
            //Нехватка бабок и тп обработка невозможности билда
            _currentComputerModel = _computerFabric.Create(Model.ComputerType, _computerPosition, _computerParent) as GameObject;
        }
    }
}