﻿using System.Linq;
using Model.Exchange;
using Model.Wallet;
using Presenters.Currency;
using Presenters.UI.ExchangeCryptoButton;
using Utils;
using Views.UI.SellButton;
using Views.Wallet;

namespace Presenters.UI.SellCryptoButton
{
    public class SellCryptoButtonPresenter : ExchangeCryptoButtonPresenter
    {
        private SellCryptoButtonView _view;
        public SellCryptoButtonPresenter(WalletModel walletModel, WalletCryptoUIView walletCryptoUIView, ExchangeModel exchangeModel, SellCryptoButtonView view) : base(walletModel, walletCryptoUIView, exchangeModel)
        {
            InvariantChecker.CheckObjectInvariant(view);
            _view = view;
            Subscribe();
        }
        
        protected override void Subscribe()
        {
            _view.SellCryptoButtonClicked += OnExchangeButtonClicked;
        }

        protected override void Unsubscribe()
        {
            _view.SellCryptoButtonClicked -= OnExchangeButtonClicked;
        }

        protected override void ExchangeCash()
        {
            WalletModel.AddCurency(typeof(Cash), TargetExchangeAmount);
        }

        protected override void CalculateExchangeAmount()
        {
            TargetExchangeAmount =
                ExchangeModel.CryptoExchangables.FirstOrDefault(x => x.Key == WalletCryptoUIView.CurrentChosenCrypto).Value.Sell();
        }
    }
}