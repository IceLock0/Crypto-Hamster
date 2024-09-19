using Model.Inventory;
using ScriptableObjects;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMoveView _player;
        [SerializeField] private Transform _playerSpawnPoint;
        
        public override void InstallBindings()
        {
            BindInventoryModel();
            InstantiatePlayer();
            BindComponents();
        }

        private void BindInventoryModel()
        {
            Container.Bind<InventoryModel>()
                .AsSingle()
                .NonLazy();
        }

        private void InstantiatePlayer()
        {
            _player = Container.InstantiatePrefabForComponent<PlayerMoveView>
                (_player, _playerSpawnPoint.position, Quaternion.identity, null);
        }

        private void BindComponents()
        {
            Container.Bind<PlayerMoveView>()
                .FromInstance(_player)
                .AsSingle()
                .NonLazy();
        }
    }
}