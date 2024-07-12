using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle().NonLazy();
        }
    }

}