using System;
using Presenters.Currency;
using Views.Wallet.Association_dropdown;

namespace Utils.EnumToTypeService
{
    public static class CryptoEnumToTypeService
    {
        public static Type CryptoToType(CryptoCurrencyIndices crypto)
        {
            switch (crypto)
            {
                case CryptoCurrencyIndices.Bitcoin:
                    return typeof(Bitcoin);
                case CryptoCurrencyIndices.Ethereum:
                    return typeof(Ethereum);
                case CryptoCurrencyIndices.Solana:
                    return typeof(Solana);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}