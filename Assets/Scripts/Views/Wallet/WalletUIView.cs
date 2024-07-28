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
        
        public event Action Updated;

        private Type _currencyType;

        private WalletPresenter _presenter;

        protected abstract void SetCurrencyAmountText(float amount);

        protected abstract Type GetCurrencyType();
        
        protected virtual void OnEnable()
        {
            _presenter.Enable();
        }
        
        protected virtual void OnDisable()
        {
            _presenter.Disable();
        }
        
        private void Awake()
        {
            _presenter = new WalletPresenter(this);
        }

        private void Update()
        {
            Updated?.Invoke();
            
            _currencyType = GetCurrencyType();
            var amount = _presenter.GetCurrencyAmount(_currencyType);
            SetCurrencyAmountText(amount);
        }
        
    }
}