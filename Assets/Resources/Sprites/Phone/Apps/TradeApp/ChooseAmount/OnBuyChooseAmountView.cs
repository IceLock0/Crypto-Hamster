using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using Model.Wallet;
using Presenters.Currency;
using Presenters.Phone.Apps.TradeApp.ChooseAmount;
using Zenject;

namespace Views.Phone.Apps.TradeApp.ChooseAmount
{
    public class OnBuyChooseAmountView : ChooseAmountView
    {
        [Inject]
        public override void Initialize(ChooseAmountModel model, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel,
            WalletModel walletModel)
        {
            base.Initialize(model, cryptoExchangables, tradeAppModel, walletModel);
        }

        protected override ChooseAmountPresenter CreateChooseAmountPresenter(ChooseAmountModel model, Dictionary<Type, IExchangeable> cryptoExchangables,
            TradeAppModel tradeAppModel, WalletModel walletModel)
        {
            return new OnBuyChooseAmountPresenter(model, this, cryptoExchangables, tradeAppModel, walletModel);
        }
    }
}