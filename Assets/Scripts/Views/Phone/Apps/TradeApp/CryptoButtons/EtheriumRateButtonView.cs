using System;
using Presenters.Currency;

namespace Views.Phone.Apps.TradeApp.CryptoButtons
{
    public class EtheriumRateButtonView : ChooseCryptoRateButtonView
    {
        protected override Type GetCryptoType()
        {
            return typeof(Ethereum);
        }

        protected override string GetCryptoName()
        {
            return "ETC";
        }
    }
}