using System;
using Model.Wallet;

namespace Presenters.Wallet
{
    public abstract class WalletPresenter
    {
        protected readonly WalletModel Model;
        
        protected WalletPresenter(WalletModel walletModel)
        {
            Model = walletModel;
        }

        public virtual void Enable()
        {
            SetCurrencyText(typeof(Currency.Cash));
            Model.AmountChanged += SetCurrencyText;
        }

        public virtual void Disable()
        {
            Model.AmountChanged -= SetCurrencyText;
        }
        
        protected abstract void SetCurrencyText(Type type);

    }
}