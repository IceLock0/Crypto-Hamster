using System;
using System.Collections;
using Model;
using Presenters.Room;
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

        private readonly SpeedModel _speedModel;
        
        private readonly ContaminationPresenter _contaminationPresenter;
        
        private Vector2 _moveDirection;
        
        public PlayerMovePresenter(InputService inputService, PlayerConfig playerConfig, Rigidbody playerRigidbody, ContaminationPresenter contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(inputService, playerRigidbody);
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerRigidbody = playerRigidbody;

            _speedModel = new SpeedModel(_playerConfig.MovementSpeed);
            
            _contaminationPresenter = contaminationPresenter;
        }

        public void Enable()
        {
            _contaminationPresenter.SpeedChanged += ChangeSpeedByContamination;
        }

        public void Disable()
        {
            _contaminationPresenter.SpeedChanged -= ChangeSpeedByContamination;
        }
        
        public void TryMove()
        {
            Debug.Log($"Move with speed = {_speedModel.CurrentSpeed}");
            _moveDirection = _inputService.Player.Movement.ReadValue<Vector2>().normalized * _speedModel.CurrentSpeed * Time.fixedDeltaTime;
            _playerRigidbody.linearVelocity =
                new Vector3(_moveDirection.x, _playerRigidbody.linearVelocity.y, _moveDirection.y);
        }

        private void ChangeSpeedByContamination(float contamination)
        {
            _speedModel.ChangeSpeedByContamination(contamination);
        }
    }

}