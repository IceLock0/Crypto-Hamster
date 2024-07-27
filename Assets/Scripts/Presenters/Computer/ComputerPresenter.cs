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
        private readonly ComputerModel _model;
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

            _model = new ComputerModel();
            _view = view;
            _buyButtonView = buyButtonView;
            _computerFabric = computerFabric;
            _computerPosition = computerPosition;
            _computerParent = computersParent;
        }

        public void Enable()
        {
            _buyButtonView.BuyButtonPresenter.OnBuyButtonClicked += BuyComputer;
        }

        public void Disable()
        {
            _buyButtonView.BuyButtonPresenter.OnBuyButtonClicked -= BuyComputer;
        }

        private void BuyComputer()
        {
            _model.ChangeType((int)++_model.ComputerType);
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
            _currentComputerModel = _computerFabric.Create(_model.ComputerType, _computerPosition, _computerParent) as GameObject;
        }
    }
}