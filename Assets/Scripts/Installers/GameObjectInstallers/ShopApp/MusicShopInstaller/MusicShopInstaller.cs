using System.Collections.Generic;
using Model.ShopApp.RepairKitShop;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers.ShopApp.MusicShopInstaller
{
    public class MusicShopInstaller : MonoInstaller<MusicShopInstaller>
    {
        [Header("Music shop items")]
        [SerializeField] private List<MusicItem> _musicItems;
        
        public override void InstallBindings()
        {
            BindMusicShopModel();
        }

        private void BindMusicShopModel()
        {
            Container.Bind<MusicShopModel>()
                .FromInstance(new MusicShopModel(_musicItems))
                .AsSingle()
                .NonLazy();
        }
    }
}