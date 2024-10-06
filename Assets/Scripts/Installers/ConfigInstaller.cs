using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class ConfigInstaller : MonoInstaller
    {
        [Header("Characters")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private List<SysAdminConfig> _sysAdminConfigs;
        [SerializeField] private List<CleanerConfig> _cleanerConfigs;
        
        [Header("Mining & PC")]
        [SerializeField] private List<ComputerConfig> _computerConfigs;
        [SerializeField] private List<CryptoConfig> _cryptoConfigs;
        [SerializeField] private RepairKit _repairKit;
        [SerializeField] private CostConfig _costConfig;
        
        [Header("Environment")]
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private ElectricityConfig _electricityConfig;
        [SerializeField] private ContaminationConfig _contaminationConfig;
        [SerializeField] private MopConfig _mopConfig;
        
        public override void InstallBindings()
        {          
            BindSysAdminConfigs();
            BindCleanerConfigs();
            BindPlayerConfig();
            BindCameraConfig();
            BindComputerConfigs();
            BindElectricityConfig();
            BindRepairKit();
            BindCryptoConfigs();
            BindCostConfig();
            BindContaminationConfig();
            BindMopConfig();
        }

        private void BindCostConfig()
        {
            Container.Bind<CostConfig>().FromScriptableObject(_costConfig).AsSingle() .NonLazy();
        }

        private void BindCryptoConfigs()
        {
            Container.Bind<List<CryptoConfig>>().FromInstance(_cryptoConfigs).AsSingle().NonLazy();
        }

        private void BindContaminationConfig()
        {
            Container.Bind<ContaminationConfig>().FromScriptableObject(_contaminationConfig).AsSingle().NonLazy();
        }
        
        private void BindRepairKit()
        {
            Container.Bind<RepairKit>().FromScriptableObject(_repairKit).AsSingle().NonLazy();
        }

        private void BindElectricityConfig()
        {
            Container.Bind<ElectricityConfig>().FromScriptableObject(_electricityConfig).AsSingle().NonLazy();
        }

        private void BindSysAdminConfigs()
        {
            Container.Bind<List<SysAdminConfig>>().FromInstance(_sysAdminConfigs).AsSingle().NonLazy();
        }

        private void BindComputerConfigs()
        {
             Container.Bind<List<ComputerConfig>>().FromInstance(_computerConfigs).AsSingle().NonLazy();
        }

        private void BindCameraConfig()
        {
             Container.Bind<CameraConfig>().FromScriptableObject(_cameraConfig).AsSingle().NonLazy();
        }

        private void BindPlayerConfig()
        {
             Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle().NonLazy();
        }

        private void BindCleanerConfigs()
        {
            Container.Bind<List<CleanerConfig>>().FromInstance(_cleanerConfigs).AsSingle().NonLazy();
        }

        private void BindMopConfig()
        {
            Container.Bind<MopConfig>().FromInstance(_mopConfig).AsSingle().NonLazy();
        }
    }

}