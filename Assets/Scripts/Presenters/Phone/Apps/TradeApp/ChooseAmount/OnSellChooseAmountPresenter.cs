using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using Model.Wallet;
using Presenters.Currency;
using Utils;
using Views.Currency;
using Views.Phone.Apps.TradeApp.ChooseAmount;

namespace Presenters.Phone.Apps.TradeApp.ChooseAmount
{
    public class OnSellChooseAmountPresenter : ChooseAmountPresenter
    {
        private readonly Dictionary<Type, ICurrency> _cryptoCurrencies;
        public OnSellChooseAmountPresenter(ChooseAmountModel model, ChooseAmountView view, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel, WalletModel walletModel, Dictionary<Type, ICurrency> cryptoCurrencies) : base(model, view, cryptoExchangables, tradeAppModel, walletModel)
        {
            InvariantChecker.CheckObjectInvariant(cryptoCurrencies);
            _cryptoCurrencies = cryptoCurrencies;
        }

        protected override void CalculateChosenAmount(float value)
        {
            ChosenAmount =  _cryptoCurrencies[TradeAppModel.TargetCrypto].Amount * (value / 100);
        }
    }
}