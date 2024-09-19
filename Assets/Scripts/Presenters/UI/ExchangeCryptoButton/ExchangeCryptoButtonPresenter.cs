using Model.Exchange;
using Model.Wallet;
using Utils;
using Views.Wallet;

namespace Presenters.UI.ExchangeCryptoButton
{

    public abstract class ExchangeCryptoButtonPresenter
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

        public void OnExchangeButtonClicked()
        {
            CalculateExchangeAmount();
            ExchangeCash();
        }

        protected abstract void ExchangeCash();

        protected abstract void CalculateExchangeAmount();
    }

}