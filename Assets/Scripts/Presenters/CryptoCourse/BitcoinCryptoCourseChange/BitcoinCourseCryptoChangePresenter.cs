using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Model.Exchange;
using Presenters.CryptoCourse.CryptoCourseChange;
using Presenters.Currency;
using ScriptableObjects;
using Utils.EnumToTypeService;

namespace Presenters.CryptoCourse.BitcoinCryptoCourseChange
{

    public class BitcoinCourseCryptoChangePresenter : CryptoCourseChangePresenter
    {
        public BitcoinCourseCryptoChangePresenter(ExchangeModel exchangeModel, List<CryptoConfig> cryptoConfigs) : base(exchangeModel, cryptoConfigs, typeof(Bitcoin))
        {
        }
    }

}