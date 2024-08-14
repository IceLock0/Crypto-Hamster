using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.Player
{

    public class PlayerRotatorPresenter
    {
        private readonly InputService _inputService;
        private readonly Transform _playerGameModelTransform;
        private readonly PlayerConfig _playerConfig;

        private Quaternion _lookDirection;
        private Quaternion _targetRotation;
        private Vector2 _moveDirection;
        
        public PlayerRotatorPresenter(InputService inputService, PlayerConfig playerConfig, Transform playerGameModelTransform)
        {
            InvariantChecker.CheckObjectInvariant(inputService, playerGameModelTransform, playerConfig);
            
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerGameModelTransform = playerGameModelTransform;
        }
        
        public void TryRotate()
        {
            _moveDirection = _inputService.Player.Movement.ReadValue<Vector2>();
            if(_moveDirection == Vector2.zero)
                return;
            _lookDirection = Quaternion.LookRotation(new Vector3(_moveDirection.x, 0 , _moveDirection.y), Vector3.up);
            _targetRotation = Quaternion.RotateTowards(
                _playerGameModelTransform.rotation, _lookDirection, _playerConfig.AngularSpeed * Time.fixedDeltaTime);
            _playerGameModelTransform.rotation = _targetRotation;
        }
    }

}