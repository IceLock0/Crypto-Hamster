using System;
using System.Linq;
using Model.Exchange;
using Model.Wallet;
using Presenters.Currency;
using Utils;
using Views.UI.SellButton;
using Views.Wallet;

namespace Presenters.UI.ExchangeCryptoButton
{

    public abstract class ExchangeCryptoButtonPresenter : IDisposable
    {
        protected readonly WalletModel WalletModel;
        protected readonly WalletCryptoUIView WalletCryptoUIView;
        protected readonly ExchangeModel ExchangeModel;

        protected float TargetExchangeAmount;
        public ExchangeCryptoButtonPresenter(WalletModel walletModel, WalletCryptoUIView walletCryptoUIView, ExchangeModel exchangeModel)
        {
            InvariantChecker.CheckObjectInvariant(walletModel, walletCryptoUIView, exchangeModel);
            
            WalletModel = walletModel;
            WalletCryptoUIView = walletCryptoUIView;
            ExchangeModel = exchangeModel;
        }

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();

        protected void OnExchangeButtonClicked()
        {
            CalculateExchangeAmount();
            ExchangeCash();
        }

        protected abstract void ExchangeCash();

        protected abstract void CalculateExchangeAmount();

        public void Dispose()
        {
            Unsubscribe();
        }

        ~ExchangeCryptoButtonPresenter()
        {
            Dispose();
        }
    }

}