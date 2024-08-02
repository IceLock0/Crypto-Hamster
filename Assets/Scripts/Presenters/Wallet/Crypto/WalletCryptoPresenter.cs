using System;
using Model.Wallet;
using Presenters.Currency;
using UnityEngine;
using Views.Wallet;

namespace Presenters.Wallet.Crypto
{
    public class WalletCryptoPresenter : WalletPresenter
    {
        private readonly WalletCryptoUIView _view;
        
        public WalletCryptoPresenter(WalletCryptoUIView view, WalletModel walletModel) : base(walletModel)
        {
            _view = view;
        }

        private Type _typeToShow = typeof(Bitcoin);
        
        public override void Enable()
        {
            base.Enable();

            _view.CryptoSelected += ChangeSelectedCrypto;
        }

        public override void Disable()
        {
            base.Disable();
            
            _view.CryptoSelected -= ChangeSelectedCrypto;
        }
        
        protected override void SetCurrencyText(Type type)
        {
            if (type != _typeToShow)
                return;
            
            if (type == typeof(Currency.Cash))
                return;
                    
            var amountValue = Model.Currencies[type].Amount;

            _view.SetText(amountValue);
        }

        protected override void CreateCurrencies()
        {
            Model.AddCurrency(new Bitcoin());
            Model.AddCurrency(new Ethereum());
            Model.AddCurrency(new Solana());
        }
        
        private void ChangeSelectedCrypto(Type type)
        {
            _typeToShow = type;
            SetCurrencyText(_typeToShow);
        }
    }
}