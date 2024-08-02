using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Model.Exchange;
using Presenters.Currency;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Utils.EnumToTypeService;

namespace Presenters.CryptoCourse.CryptoCourseChange
{
    public abstract class CryptoCourseChangePresenter
    {
        private readonly ExchangeModel _exchangeModel;
        private readonly List<CryptoConfig> _cryptoConfigs;
        private readonly Type _targetType;
        
        private CryptoConfig _targetConfig;
        private IExchangeable _targetExchangable;

        
        public CryptoCourseChangePresenter(ExchangeModel exchangeModel, List<CryptoConfig> cryptoConfigs, Type targetType)
        {
            InvariantChecker.CheckObjectInvariant(exchangeModel, cryptoConfigs, targetType);

            _exchangeModel = exchangeModel;
            _cryptoConfigs = cryptoConfigs;
            _targetType = targetType;
            StartCourseChanges().Forget();
        }

        private async UniTask StartCourseChanges()
        {
            FindConfig();
            FindExchangable();
            if (_targetConfig == null)
                throw new ArgumentNullException();
            while (true)
            {
                Debug.Log($"Crypto {_targetConfig.CryptoCurrency}\nRate {_targetExchangable.Rate}");
                await UniTask.Delay((int) (_targetConfig.RateChangeDelay * 1000));
                _targetExchangable.ChangeRate();
            }
        }
        
        private void FindExchangable()
        {
            _targetExchangable = _exchangeModel.CryptoExchangables.FirstOrDefault(x =>
                x.Key == _targetType).Value;
        }

        private void FindConfig()
        {
            _targetConfig = _cryptoConfigs.FirstOrDefault(x =>
                CryptoEnumToTypeService.CryptoToType(x.CryptoCurrency) == _targetType);
        }
    }
}