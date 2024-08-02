using System.Collections.Generic;
using Model.Exchange;
using Presenters.CryptoCourse.CryptoCourseChange;
using Presenters.Currency;
using ScriptableObjects;

namespace Presenters.CryptoCourse.SolanaCourseCryptoChange
{

    public class SolanaCourseCryptoChangePresenter : CryptoCourseChangePresenter
    {
        public SolanaCourseCryptoChangePresenter(ExchangeModel exchangeModel, List<CryptoConfig> cryptoConfigs) : base(exchangeModel, cryptoConfigs, typeof(Solana))
        {
        }
    }

}