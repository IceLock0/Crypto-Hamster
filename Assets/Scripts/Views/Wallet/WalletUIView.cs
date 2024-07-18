using System;
using Presenters.Currency;
using Presenters.Wallet;
using TMPro;
using UnityEngine;
using Views.Currency;


namespace Views.Wallet
{
    public abstract class WalletUIView : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _currencyAmountTextTMP;
        
        public event Action OnUpdate;

        private Type _currencyType;

        private WalletPresenter _presenter;

        private void Awake()
        {
            _presenter = new WalletPresenter(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
            
            _currencyType = GetCurrencyType();
            var amount = _presenter.GetCurrencyAmount(_currencyType);
            SetCurrencyAmountText(amount);
        }
        
        protected abstract void SetCurrencyAmountText(float amount);

        protected abstract Type GetCurrencyType();
    }
}