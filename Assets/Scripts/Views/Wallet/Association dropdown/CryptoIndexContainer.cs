using System;
using System.Collections.Generic;
using UnityEngine.Rendering.VirtualTexturing;

namespace Views.Wallet
{
    public static class CryptoIndexContainer
    {
        public static Dictionary<int, Type> TypesContainer { get; private set; } = new();

        public static void AddCryptoIndex(CryptoCurrencyIndices cryptoCurrencyIndex, Type cryptoType)
        {
            if (TypesContainer.ContainsKey((int)cryptoCurrencyIndex))
                throw new ArgumentException($"Crypto currency index {cryptoCurrencyIndex} is already contained.");
            
            TypesContainer.Add((int)cryptoCurrencyIndex, cryptoType);
        }
    }
}