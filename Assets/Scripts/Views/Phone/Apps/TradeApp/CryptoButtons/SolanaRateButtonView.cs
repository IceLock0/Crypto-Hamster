using System;
using Presenters.Currency;

namespace Views.Phone.Apps.TradeApp.CryptoButtons
{
    public class SolanaRateButtonView : ChooseCryptoRateButtonView
    {
        protected override Type GetCryptoType()
        {
            return typeof(Solana);
        }

        protected override string GetCryptoName()
        {
            return "SOL";
        }
    }
}