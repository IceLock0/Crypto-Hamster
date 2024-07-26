using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle().NonLazy();
            Container.Bind<CameraConfig>().FromScriptableObject(_cameraConfig).AsSingle().NonLazy();
        }
    }

}