using TMPro;
using UnityEngine;
using Views.Phone.Apps.TradeApp.Rate;
using Zenject;

namespace Installers.GameObjectInstallers.TradeApp
{
    public class TradeAppUIInstaller : MonoInstaller<TradeAppUIInstaller>
    {
        [SerializeField] private TMP_Text _cryptoToDollarText;
        [SerializeField] private TMP_Text _dollarToCryptoText;
        
        public override void InstallBindings()
        {
            BindRatesTextModel();
        }

        private void BindRatesTextModel()
        {
            Container.Bind<RatesTextsModel>()
                .FromInstance(new RatesTextsModel(_cryptoToDollarText, _dollarToCryptoText))
                .AsSingle()
                .NonLazy();
        }
    }
}