using System;
using Model.Wallet;
using Presenters.Currency;

namespace Presenters.Wallet
{
    public abstract class WalletPresenter
    {
        protected readonly WalletModel Model;
        
        protected WalletPresenter(WalletModel walletModel)
        {
            Model = walletModel;
        
            CreateCurrencies();
        }

        public virtual void Enable()
        {
            Model.AmountChanged += SetCurrencyText;
        }

        public virtual void Disable()
        {
            Model.AmountChanged -= SetCurrencyText;
        }
        
        protected abstract void SetCurrencyText(Type type);
        
        protected abstract void CreateCurrencies();

        public float GetCryptoAmount(Type type) => Model.Currencies[type].Amount;
        
    }
}