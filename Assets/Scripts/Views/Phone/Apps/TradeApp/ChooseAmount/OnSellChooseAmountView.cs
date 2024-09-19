using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using Model.Wallet;
using Presenters.Currency;
using Presenters.Phone.Apps.TradeApp.ChooseAmount;
using Utils;
using Views.Currency;
using Zenject;

namespace Views.Phone.Apps.TradeApp.ChooseAmount
{
    public class OnSellChooseAmountView : ChooseAmountView
    {
        private Dictionary<Type, ICurrency> _currencies;
        
        [Inject]
        public void Initialize(ChooseAmountModel model, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel,
            WalletModel walletModel, Dictionary<Type, ICurrency> currencies)
        {
            InvariantChecker.CheckObjectInvariant(currencies);
            _currencies = currencies;
            base.Initialize(model, cryptoExchangables, tradeAppModel, walletModel);
        }

        protected override ChooseAmountPresenter CreateChooseAmountPresenter(ChooseAmountModel model, Dictionary<Type, IExchangeable> cryptoExchangables,
            TradeAppModel tradeAppModel, WalletModel walletModel)
        {
            return new OnSellChooseAmountPresenter(model, this, cryptoExchangables, tradeAppModel, walletModel, _currencies);
        }
    }
}