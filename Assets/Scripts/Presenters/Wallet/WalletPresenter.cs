using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Views.Currency;
using Views.Wallet;
using Zenject;

namespace Presenters.Wallet
{
    public class WalletPresenter
    {
        private WalletUIView _uiView;
        private WalletModel _model;
        
        public WalletPresenter(WalletUIView uiView)
        {
            _uiView = uiView;

            _model = new WalletModel();
            
            CreateCurrency();
        }

        public void CreateCurrency()
        {
            // _model.SetAmount(_model.Amount + amount);
            //
            // _view.SetCurrencyText(_model.Amount);
            
            _model.AddCurrency(new Cash());
            _model.AddCurrency(new Bitcoin());
            _model.AddCurrency(new Ethereum());
            _model.AddCurrency(new Solana());
        }

        public void AddCurrencyAmount(ICurrency currency, float amount)
        {
            _model.SetCurrencyAmount( currency, _model.Currencies[currency] + amount);
        }
    }
}