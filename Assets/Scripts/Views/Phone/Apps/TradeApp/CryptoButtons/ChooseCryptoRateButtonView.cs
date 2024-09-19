using System;
using System.Collections.Generic;
using Model.TradeApp;
using Presenters.Currency;
using Presenters.Phone.Apps.TradeApp.CryptoButtons;
using TMPro;
using UnityEngine;
using Utils;
using Views.Phone.Apps.TradeApp.Rate;
using Views.UI.ButtonUI;
using Zenject;

namespace Views.Phone.Apps.TradeApp.CryptoButtons
{
    public abstract class ChooseCryptoRateButtonView : ButtonView
    {
        [SerializeField] private TMP_Text _chooseText;
        private ChooseCryptoRateButtonPresenter _presenter;

        [Inject]
        public void Initialize(Dictionary<Type, IExchangeable> cryptoExchangables, RatesTextsModel ratesTextsModel, TradeAppModel tradeAppModel)
        {
            _presenter = new ChooseCryptoRateButtonPresenter(cryptoExchangables, ratesTextsModel, tradeAppModel);
        }

        protected override void ButtonClicked()
        {
            _presenter.UpdateRate(GetCryptoType(), GetCryptoName());
            _presenter.UpdateChosenCrypto(_chooseText, GetCryptoName());
        }

        protected abstract Type GetCryptoType();
        protected abstract string GetCryptoName();
    }
}