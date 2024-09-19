using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using Model.Wallet;
using Presenters.Currency;
using Utils;
using Views.Phone.Apps.TradeApp.ChooseAmount;

namespace Presenters.Phone.Apps.TradeApp.ChooseAmount
{
    public abstract class ChooseAmountPresenter
    {
        private readonly ChooseAmountModel _model;
        private readonly ChooseAmountView _view;
        protected readonly Dictionary<Type, IExchangeable> CryptoExchangables;
        protected readonly TradeAppModel TradeAppModel;
        protected readonly WalletModel WalletModel;

        protected float ChosenAmount;
        
        public ChooseAmountPresenter(ChooseAmountModel model, ChooseAmountView view, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel, WalletModel walletModel)
        {
            InvariantChecker.CheckObjectInvariant(model, view, tradeAppModel, cryptoExchangables, walletModel);
            _model = model;
            TradeAppModel = tradeAppModel;
            CryptoExchangables = cryptoExchangables;
            _view = view;
            WalletModel = walletModel;
        }
        
        public void SliderValueChanged(float value)
        {
            CalculateChosenAmount(value);
            _model.ChangeAmount(ChosenAmount);
            _view.UpdateVisual(ChosenAmount);
        }

        protected abstract void CalculateChosenAmount(float value);
    }
}