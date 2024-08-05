using System;

namespace Views.Currency
{
    public interface ICurrency
    {
        public float Amount { get; set; }

        public void ChangeAmount(float amount, Action<Type> callback);

        public void Reset(Action<Type> callback);
    }
}