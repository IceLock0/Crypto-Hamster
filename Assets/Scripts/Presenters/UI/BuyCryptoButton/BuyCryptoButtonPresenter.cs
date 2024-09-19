using System.Linq;
using Model.ChooseAmount;
using Model.Exchange;
using Model.Wallet;
using Presenters.Currency;
using Presenters.UI.ExchangeCryptoButton;
using Utils;
using Views.Wallet;

namespace Presenters.UI.BuyCryptoButton
{

    public class BuyCryptoButtonPresenter : ExchangeCryptoButtonPresenter
    {
        private readonly ChooseAmountModel _chooseAmountModel;

        public BuyCryptoButtonPresenter(WalletModel walletModel, WalletCryptoUIView walletCryptoUIView,
            ExchangeModel exchangeModel, ChooseAmountModel chooseAmountModel) : base(walletModel, walletCryptoUIView,
            exchangeModel)
        {
            InvariantChecker.CheckObjectInvariant(chooseAmountModel);
            _chooseAmountModel = chooseAmountModel;

        }

        protected override void ExchangeCash()
        {
            var targetCrypto = ExchangeModel.CryptoExchangables
                .FirstOrDefault(x => x.Key == WalletCryptoUIView.CurrentChosenCrypto).Value;
            WalletModel.AddCurrency(WalletCryptoUIView.CurrentChosenCrypto, _chooseAmountModel.Amount);
            WalletModel.RemoveCurrency(typeof(Cash), targetCrypto.Rate * _chooseAmountModel.Amount);

        }

        protected override void CalculateExchangeAmount()
        {

        }
    }
}