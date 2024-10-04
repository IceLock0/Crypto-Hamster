using System.Collections.Generic;
using Model.Exchange;
using Presenters.CryptoCourse.CryptoCourseChange;
using Presenters.Currency;
using ScriptableObjects;

namespace Presenters.CryptoCourse.BitcoinCryptoCourseChange
{

    public class BitcoinCourseCryptoChangePresenter : CryptoCourseChangePresenter
    {
        public BitcoinCourseCryptoChangePresenter(ExchangeModel exchangeModel, List<CryptoConfig> cryptoConfigs) : base(exchangeModel, cryptoConfigs, typeof(Bitcoin))
        {
        }
    }

}