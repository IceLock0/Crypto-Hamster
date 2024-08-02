﻿using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{

    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private List<CryptoConfig> _cryptoConfigs;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private List<ComputerConfig> _computerConfig;
        [SerializeField] private SysAdminConfig _sysAdminConfig;
        [SerializeField] private ElectricityConfig _electricityConfig;
        [SerializeField] private RepairKit _repairKit;
        
        public override void InstallBindings()
        {
            BindPlayerConfig();
            BindCameraConfig();
            BindComputerConfig();
            BindSysAdminConfig();
            BindElectricityConfig();
            BindRepairKit();
            BindCryptoConfigs();
        }

        private void BindCryptoConfigs()
        {
            Container.Bind<List<CryptoConfig>>()
                .FromInstance(_cryptoConfigs)
                .AsSingle()
                .NonLazy();
        }

        private void BindRepairKit()
        {
            Container.Bind<RepairKit>().FromScriptableObject(_repairKit).AsSingle().NonLazy();
        }

        private void BindElectricityConfig()
        {
            Container.Bind<ElectricityConfig>().FromScriptableObject(_electricityConfig).AsSingle().NonLazy();
        }

        private void BindSysAdminConfig()
        {
            Container.Bind<SysAdminConfig>().FromInstance(_sysAdminConfig).AsSingle().NonLazy();
        }

        private void BindComputerConfig()
        {
             Container.Bind<List<ComputerConfig>>().FromInstance(_computerConfig).AsSingle().NonLazy();
        }

        private void BindCameraConfig()
        {
             Container.Bind<CameraConfig>().FromScriptableObject(_cameraConfig).AsSingle().NonLazy();
        }

        private void BindPlayerConfig()
        {
             Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle().NonLazy();
        }
    }

}