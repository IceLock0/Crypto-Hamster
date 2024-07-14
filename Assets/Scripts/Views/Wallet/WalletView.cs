using System;
using System.Collections;
using Presenters.Wallet;
using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private WalletPresenter _presenter;

        private void Start()
        {
            _presenter = new WalletPresenter(this);
        }

        public void SetCurrencyText(float amount)
        {
            var s_text = "Real bablo " + amount.ToString("#.##");

            _text.text = s_text;
        }

        private void Update()
        {
            if (_addingCounter >= _timeBetweenAdding)
            {
                AddCurrency();

                _addingCounter = 0.0f;
            }

            _addingCounter += Time.deltaTime;
        }

        private float _currencyPerSecond = 0.01f;
        private float _timeBetweenAdding = 0.5f;
        private float _addingCounter = 0.5f;

        private void AddCurrency()
        {
            _presenter.AddCurrency(_currencyPerSecond);
        }
    }
}