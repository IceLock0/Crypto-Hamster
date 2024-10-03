using System.Collections.Generic;
using Model.Exchange;
using Presenters.CryptoCourse.CryptoCourseChange;
using Presenters.Currency;
using ScriptableObjects;

namespace Presenters.CryptoCourse.EtheriumCryptoCourseChange
{

    public class EtheriumCourseCryptoChangePresenter : CryptoCourseChangePresenter
    {
        public EtheriumCourseCryptoChangePresenter(ExchangeModel exchangeModel, List<CryptoConfig> cryptoConfigs) : base(exchangeModel, cryptoConfigs, typeof(Ethereum))
        {
        }

    }

}