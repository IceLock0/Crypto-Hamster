using System;
using System.Collections.Generic;
using Presenters.Currency;
using Presenters.Phone.Apps.TradeApp.CryptoButtons;
using Utils;
using Views.Phone.Apps.TradeApp.Rate;
using Views.UI.ButtonUI;
using Zenject;

namespace Views.Phone.Apps.TradeApp.CryptoButtons
{
    public abstract class ChooseCryptoRateButtonView : ButtonView
    {
        private ChooseCryptoRateButtonPresenter _presenter;

        [Inject]
        public void Initialize(Dictionary<Type, IExchangeable> cryptoExchangables, RatesTextsModel ratesTextsModel)
        {
            _presenter = new ChooseCryptoRateButtonPresenter(cryptoExchangables, ratesTextsModel);
        }

        protected override void ButtonClicked()
        {
            _presenter.ShowCorrectRate(GetCryptoType(), GetCryptoName());
        }

        protected abstract Type GetCryptoType();
        protected abstract string GetCryptoName();
    }
}