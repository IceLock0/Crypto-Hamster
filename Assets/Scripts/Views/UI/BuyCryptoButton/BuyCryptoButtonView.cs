using Model.ChooseAmount;
using Model.Exchange;
using Model.Wallet;
using Presenters.UI.BuyCryptoButton;
using Views.UI.ButtonUI;
using Views.Wallet;
using Zenject;

namespace Views.UI.BuyCryptoButton
{
    public class BuyCryptoButtonView : ButtonView
    {
        private BuyCryptoButtonPresenter _presenter;

        [Inject]
        public void Initialize(WalletModel walletModel, WalletCryptoUIView walletCryptoUIView, ExchangeModel exchangeModel, ChooseAmountModel chooseAmountModel)
        {
            _presenter =
                new BuyCryptoButtonPresenter(walletModel, walletCryptoUIView, exchangeModel, chooseAmountModel);
        }
        

        protected override void ButtonClicked()
        {
            _presenter.OnExchangeButtonClicked();
        }
    }
}