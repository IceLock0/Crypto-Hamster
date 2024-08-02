using System;
using System.Linq;
using Model.Exchange;
using Model.Wallet;
using Presenters.Currency;
using Utils;
using Views.UI.ExchangeButton;
using Views.UI.Wallet;
using Zenject;

namespace Presenters.UI.ExchangeButton
{
    public class ExchangeButtonPresenter : IDisposable
    {
        private readonly ExchangeButtonView _view;
        private readonly WalletModel _walletModel;
        private readonly CryptoDropDownHandler _cryptoDropDownHandler;
        private readonly ExchangeModel _exchangeModel;

        private float _targetExchangeAmount;
        public ExchangeButtonPresenter(ExchangeButtonView view, WalletModel walletModel, CryptoDropDownHandler cryptoDropDownHandler, ExchangeModel exchangeModel)
        {
            InvariantChecker.CheckObjectInvariant(view, walletModel, cryptoDropDownHandler, exchangeModel);

            _view = view;
            _walletModel = walletModel;
            _cryptoDropDownHandler = cryptoDropDownHandler;
            _exchangeModel = exchangeModel;
            _view.ExchangeButtonClicked += OnExchangeButtonClicked;
        }
        
        private void OnExchangeButtonClicked()
        {
            CalculateExchangeAmount();
            AddCash();
        }

        private void AddCash()
        {
            _walletModel.AddCurency(typeof(Cash), _targetExchangeAmount);
        }

        private void CalculateExchangeAmount()
        {
            _targetExchangeAmount =
                _exchangeModel.CryptoExchangables.FirstOrDefault(x => x.Key == _cryptoDropDownHandler.CurrentCrypto).Value.Exchange();
        }

        public void Dispose()
        {
            _view.ExchangeButtonClicked -= OnExchangeButtonClicked;
        }

        ~ExchangeButtonPresenter()
        {
            Dispose();
        }
    }
}