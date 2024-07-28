using System;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Views.Wallet;

namespace Presenters.Wallet
{
    public class WalletPresenter
    {
        private readonly WalletUIView _uiView;
        private readonly WalletModel _model;

        private float _addTimer;
        
        public WalletPresenter(WalletUIView uiView)
        {
            _uiView = uiView;

            _model = new WalletModel();
            
            CreateCurrencies();
        }

        public void Enable()
        {
            _uiView.Updated += UpdatedFromView;
        }

        public void Disable()
        {
            _uiView.Updated -= UpdatedFromView;
        }

        public float GetCurrencyAmount(Type currencyType)
        {
            return _model.Currencies[currencyType].Amount;
        }
        
        private void UpdatedFromView()
        {
            AddCurrencyAmount();
        }

        private void AddCurrencyAmount()
        {
            foreach (var currency in _model.Currencies.Values)
            {
                if (currency.Timer >= currency.TimeToAdding)
                {
                    _model.AddCurrencyAmount(currency.GetType());
                    currency.Timer = 0.0f;
                }
                else currency.Timer += Time.deltaTime;
                // _addTimer = 0.0f;
            }

            //_addTimer += Time.deltaTime;
        }

        private void CreateCurrencies()
        {
            _model.AddCurrency(new Cash());
            _model.AddCurrency(new Bitcoin());
            _model.AddCurrency(new Ethereum());
            _model.AddCurrency(new Solana());
        }
    }
}