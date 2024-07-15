using System;
using System.Collections;
using Presenters.Wallet;
using TMPro;
using UnityEngine;
using Views.Currency;

namespace Views.Wallet
{
    public abstract class WalletUIView : MonoBehaviour
    {
        private WalletPresenter _presenter;

        private void Start()
        {
            _presenter = new WalletPresenter(this);
        }

        protected float CurrencyPerSecond;
        protected float TimeBetweenAdding;
        
        private float AddingCounter = 0.0f;

        public abstract void SetCurrencyAmountText(float amount);

        private void Update()
        {
            if (AddingCounter >= TimeBetweenAdding)
            {
               //AddCurrencyAmount();

               AddingCounter = 0.0f;
            }

            AddingCounter += Time.deltaTime;
        }

        private void AddCurrencyAmount(ICurrency currency)
        {
            _presenter.AddCurrencyAmount(currency, CurrencyPerSecond);
        }
    }
}