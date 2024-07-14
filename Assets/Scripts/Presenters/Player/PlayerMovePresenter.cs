using System;
using System.Collections;
using ScriptableObjects;
using Services;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Presenters.Player
{

    public class PlayerMovePresenter
    {
        private readonly InputService _inputService;
        private readonly Rigidbody _playerRigidbody;
        private readonly PlayerConfig _playerConfig;
        
        private Vector2 _moveDirection;
        
        public PlayerMovePresenter(InputService inputService, PlayerConfig playerConfig, ICoroutineService coroutineService, Rigidbody playerRigidbody)
        {
            InvariantChecker.CheckObjectInvariant(inputService, coroutineService, playerRigidbody);
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerRigidbody = playerRigidbody;
        }
        public void TryMove()
        {
            _moveDirection = _inputService.Player.Movement.ReadValue<Vector2>().normalized * _playerConfig.Speed * Time.fixedDeltaTime;
            _playerRigidbody.linearVelocity =
                new Vector3(_moveDirection.x, _playerRigidbody.linearVelocity.y, _moveDirection.y);
        }

    }

}