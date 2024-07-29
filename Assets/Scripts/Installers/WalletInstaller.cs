using Model.Wallet;
using UnityEngine;
using Views.Wallet;
using Zenject;

namespace Installers
{
    public class WalletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<WalletModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}