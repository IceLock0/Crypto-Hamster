using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private List<ComputerConfig> _computerConfig;
        [SerializeField] private SysAdminConfig _sysAdminConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle().NonLazy();
            Container.Bind<CameraConfig>().FromScriptableObject(_cameraConfig).AsSingle().NonLazy();
            Container.Bind<List<ComputerConfig>>().FromInstance(_computerConfig).AsSingle().NonLazy();
            Container.Bind<SysAdminConfig>().FromInstance(_sysAdminConfig).AsSingle().NonLazy();
        }
    }

}