using System.Collections.Generic;
using System.Linq;
using Model.Exchange;
using Model.Wallet;
using Presenters.Currency;
using Presenters.UI.ExchangeCryptoButton;
using UnityEngine;
using Utils;
using Views.UI.BuyCryptoButton;
using Views.Wallet;

namespace Presenters.UI.BuyCryptoButton
{

    public class BuyCryptoButtonPresenter : ExchangeCryptoButtonPresenter
    {
        private BuyCryptoButtonView _view;
        public BuyCryptoButtonPresenter(WalletModel walletModel, WalletCryptoUIView walletCryptoUIView, ExchangeModel exchangeModel, BuyCryptoButtonView view) : base(walletModel, walletCryptoUIView, exchangeModel)
        {
            InvariantChecker.CheckObjectInvariant(view);
            _view = view;
            Subscribe();
        }

        protected override void Subscribe()
        {
            _view.BuyButtonClicked += OnExchangeButtonClicked;
        }

        protected override void Unsubscribe()
        {
            _view.BuyButtonClicked -= OnExchangeButtonClicked;
        }

        protected override void ExchangeCash()
        {
            ExchangeModel.CryptoExchangables.FirstOrDefault(x => x.Key == WalletCryptoUIView.CurrentChosenCrypto)
                .Value.Buy(TargetExchangeAmount);
        }

        protected override void CalculateExchangeAmount()
        {
            TargetExchangeAmount = WalletModel.Currencies[typeof(Cash)].Amount;
        }
    }

}