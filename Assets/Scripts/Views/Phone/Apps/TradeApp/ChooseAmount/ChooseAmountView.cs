using System;
using System.Collections.Generic;
using Model.ChooseAmount;
using Model.TradeApp;
using Model.Wallet;
using Presenters.Currency;
using Presenters.Phone.Apps.TradeApp.ChooseAmount;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Phone.Apps.TradeApp.ChooseAmount
{
    public abstract class ChooseAmountView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _amountText;

        private ChooseAmountPresenter _presenter;
        
        public virtual void Initialize(ChooseAmountModel model, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel, WalletModel walletModel)
        {
            _presenter = CreateChooseAmountPresenter(model, cryptoExchangables, tradeAppModel, walletModel);
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(_presenter.SliderValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(_presenter.SliderValueChanged);
        }

        public void UpdateVisual(float amount)
        {
            _amountText.text = $"{amount:F2}";
        }

        protected abstract ChooseAmountPresenter CreateChooseAmountPresenter(ChooseAmountModel model, Dictionary<Type, IExchangeable> cryptoExchangables, TradeAppModel tradeAppModel, WalletModel walletModel);
    }
}