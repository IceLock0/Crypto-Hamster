using System;
using System.Collections.Generic;
using Presenters.Currency;
using Views.Currency;
using Zenject;

namespace Installers
{

    public class CurrencyInstaller : MonoInstaller
    {
        private Dictionary<Type, ICurrency> _icurrencyDictionary;
        private Dictionary<Type, IExchangeable> _iexchangableDictionary;

        private Bitcoin _bitcoin;
        private Ethereum _ethereum;
        private Cash _cash;
        private Solana _solana;
        
        public override void InstallBindings()
        {
            BindCrypto();
            ResolveCrypto();
            CreateDictionary();
            BindICurrencyDictionary();
            BindIExchangableDictionary();
        }

        private void BindCrypto()
        {
            Container.Bind<Bitcoin>()
                .AsSingle()
                .NonLazy();
            Container.Bind<Ethereum>()
                .AsSingle()
                .NonLazy();
            Container.Bind<Solana>()
                .AsSingle()
                .NonLazy();
            Container.Bind<Cash>()
                .AsSingle()
                .NonLazy();
        }

        private void ResolveCrypto()
        {
            _bitcoin = Container.Resolve<Bitcoin>();
            _ethereum = Container.Resolve<Ethereum>();
            _solana = Container.Resolve<Solana>();
            _cash = Container.Resolve<Cash>();
        }

        private void CreateDictionary()
        {
            _icurrencyDictionary = new()
            {
                {typeof(Bitcoin), _bitcoin},
                {typeof(Ethereum), _ethereum},
                {typeof(Cash), _cash},
                {typeof(Solana), _solana}
            };
            _iexchangableDictionary = new()
            {
                {typeof(Bitcoin), _bitcoin},
                {typeof(Ethereum), _ethereum},
                {typeof(Solana), _solana}
            };
        }

        private void BindIExchangableDictionary()
        {
            Container.Bind<Dictionary<Type, ICurrency>>()
                .FromInstance(_icurrencyDictionary)
                .AsSingle()
                .NonLazy();
        }

        private void BindICurrencyDictionary()
        {
            Container.Bind<Dictionary<Type, IExchangeable>>()
                .FromInstance(_iexchangableDictionary)
                .AsSingle()
                .NonLazy();
        }
    }

}