using Model.Wallet;
using UnityEngine;
using Views.Wallet;
using Zenject;

namespace Presenters.Wallet
{
    public class WalletPresenter
    {
        private WalletView _view;
        private WalletModel _model;
        
        public WalletPresenter(WalletView view)
        {
            _view = view;

            _model = new WalletModel();
        }

        public void AddCurrency(float amount)
        {
            _model.SetAmount(_model.Amount + amount);
            
            _view.SetCurrencyText(_model.Amount);
        }
    }
}