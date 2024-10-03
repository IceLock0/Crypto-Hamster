﻿using System;
using Views.Wallet.Association_dropdown;

namespace Model.Crypto
{
    [Serializable]
    public struct CryptoModel
    {
        public CryptoCurrencyIndices Currency;
        public float Rate;
        public float PerTime;
    }
}