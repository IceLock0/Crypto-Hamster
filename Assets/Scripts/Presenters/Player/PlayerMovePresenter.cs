﻿using Model;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
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

            _speedModel = new SpeedModel(playerConfig);
            
            _contaminationPresenter = contaminationPresenter;
        }

        public void Enable()
        {
            _contaminationPresenter.ContaminationChanged += ChangeContaminationByContamination;
        }

        public void Disable()
        {
            _contaminationPresenter.ContaminationChanged -= ChangeContaminationByContamination;
        }
        
        public void TryMove()
        {
            _moveDirection = _inputService.Player.Movement.ReadValue<Vector2>().normalized * _speedModel.CurrentSpeed * Time.fixedDeltaTime;
            _playerRigidbody.linearVelocity =
                new Vector3(_moveDirection.x, _playerRigidbody.linearVelocity.y, _moveDirection.y);
        }

        private void ChangeContaminationByContamination(float contamination)
        {
            _speedModel.ChangeSpeedByContamination(contamination);
        }
    }

}