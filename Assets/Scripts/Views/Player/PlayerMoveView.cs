using System;
using Presenters.Player;
using ScriptableObjects;
using Services;
using UnityEngine;
using Views.ComputerServant;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveView : MonoBehaviour, IComputerServant
    {
        private PlayerMovePresenter _movePresenter;
        private InputService _inputService;
        
        [Inject]
        public void Initialize(InputService inputService, PlayerConfig playerConfig)
        {
            _movePresenter = new PlayerMovePresenter(inputService, playerConfig, GetComponent<Rigidbody>());
            _inputService = inputService;
        }

        private void OnEnable()
        {
            _inputService.Enable();
        }

        private void OnDisable()
        {
            _inputService.Disable();
        }

        private void FixedUpdate()
        {
            _movePresenter.TryMove();
        }
    }
}