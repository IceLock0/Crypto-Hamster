using System;
using Presenters.Currency;
using Presenters.Wallet;
using UnityEngine;
using Views.Currency;


namespace Views.Wallet
{
    public class WalletUIView : MonoBehaviour
    {
                
        private WalletPresenter _presenter;
        
        private float AddingCounter = 0.0f;
        
        protected float CurrencyPerSecond;
        protected float TimeBetweenAdding;

        protected void Start()
        {
            _presenter = new WalletPresenter(this);
        }

        public virtual void SetCurrencyAmountText(float amount)
        {
        }

        protected bool _isCanAdd;
        //убрать в презентер        
        protected void Update()
        {
            _isCanAdd = false;
            
            if (AddingCounter >= TimeBetweenAdding)
            {
                _isCanAdd = true;

               AddingCounter = 0.0f;
            }

            AddingCounter += Time.deltaTime;
        }

        protected virtual void AddCurrencyAmount(Type currencyType) 
        {
            _presenter.AddCurrencyAmount(currencyType, CurrencyPerSecond);
        }
    }
}