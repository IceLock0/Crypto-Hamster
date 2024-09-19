using Model.Exchange;
using Model.Wallet;
using Presenters.UI.SellCryptoButton;
using Views.UI.ButtonUI;
using Views.Wallet;
using Zenject;

namespace Views.UI.SellButton
{
    public class SellCryptoButtonView : ButtonView
    {
        private SellCryptoButtonPresenter _presenter;

        [Inject]
        public void Initialize(WalletModel walletModel, WalletCryptoUIView walletCryptoUIView, ExchangeModel exchangeModel)
        {
            _presenter = new SellCryptoButtonPresenter(walletModel,walletCryptoUIView,exchangeModel);
        }
        

        protected override void ButtonClicked()
        {
            _presenter.OnExchangeButtonClicked();
        }
    }
}