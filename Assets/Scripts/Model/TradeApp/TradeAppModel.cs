using System;
using Presenters.Currency;

namespace Model.TradeApp
{
    public class TradeAppModel
    {
        public TradeAppModel()
        {
            ChangeTargetCrypto(typeof(Bitcoin));
        }

        public Type TargetCrypto { get; private set; }
        public event Action<Type> TargetCryptoChanged;

        public void ChangeTargetCrypto(Type type)
        {
            TargetCrypto = type;
            TargetCryptoChanged?.Invoke(type);
        }
    }
}