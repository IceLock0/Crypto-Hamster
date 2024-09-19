using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using Model.Wallet;
using Presenters.Currency;
using Views.Phone.Apps.TradeApp.ChooseAmount;

namespace Presenters.Phone.Apps.TradeApp.ChooseAmount
{
    public class OnBuyChooseAmountPresenter : ChooseAmountPresenter
    {
        public OnBuyChooseAmountPresenter(ChooseAmountModel model, ChooseAmountView view, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel, WalletModel walletModel) : base(model, view, cryptoExchangables, tradeAppModel, walletModel)
        {
        }

        protected override void CalculateChosenAmount(float value)
        {
            ChosenAmount = WalletModel.Currencies[typeof(Cash)].Amount
                            / CryptoExchangables[TradeAppModel.TargetCrypto].Rate
                            * (value / 100);
        }
    }
}