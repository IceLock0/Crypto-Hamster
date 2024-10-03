using TMPro;
using Utils;

namespace Views.Phone.Apps.TradeApp.Rate
{
    public class RatesTextsModel
    {
        public RatesTextsModel(TMP_Text cryptoToDollar, TMP_Text dollarToCrypto)
        {
            InvariantChecker.CheckObjectInvariant(cryptoToDollar, dollarToCrypto);
            CryptoToDollar = cryptoToDollar;
            DollarToCrypto = dollarToCrypto;
        }
        
        public TMP_Text CryptoToDollar { get; private set; }
        public TMP_Text DollarToCrypto { get; private set; }
    }
}