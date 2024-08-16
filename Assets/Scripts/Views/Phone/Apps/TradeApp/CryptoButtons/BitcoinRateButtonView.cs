using System;
using Presenters.Currency;

namespace Views.Phone.Apps.TradeApp.CryptoButtons
{
    public class BitcoinRateButtonView : ChooseCryptoRateButtonView
    {
        protected override Type GetCryptoType()
        {
            return typeof(Bitcoin);
        }

        protected override string GetCryptoName()
        {
            return "BTC";
        }
    }
}