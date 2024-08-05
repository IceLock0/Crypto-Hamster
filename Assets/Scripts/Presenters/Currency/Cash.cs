using System;
using Views.Currency;

namespace Presenters.Currency
{
    public class Cash : ICurrency
    {
        public float Amount { get; set; }
        public void ChangeAmount(float amount, Action<Type> callback)
        {
            Amount += amount;
            callback?.Invoke(typeof(Cash));
        }

        public void Reset(Action<Type> callback)
        {
            Amount = 0;
            callback?.Invoke(typeof(Cash));
        }
    }
}