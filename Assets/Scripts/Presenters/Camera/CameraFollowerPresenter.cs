using System;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Player;

namespace Presenters.Camera
{
    public class CameraFollowerPresenter
    {

        private readonly Transform _playerTransform;
        private readonly Transform _cameraTransform;
        private readonly CameraConfig _cameraConfig;
        
        public CameraFollowerPresenter(PlayerMoveView player, Transform cameraTransform, CameraConfig cameraConfig)
        {
            InvariantChecker.CheckObjectInvariant(player, cameraTransform);
            _cameraConfig = cameraConfig;
            if (_cameraConfig.Smooth <= 0 || _cameraConfig.Smooth > 1)
                throw new ArgumentOutOfRangeException();
            _playerTransform = player.transform;
            _cameraTransform = cameraTransform;
        }

        public void FollowCamera()
        {
            var nextPosition = CalculateNextPosition(_cameraConfig.Smooth, _cameraConfig.Offset);
            _cameraTransform.position = nextPosition;
            _cameraTransform.rotation = Quaternion.Euler(_cameraConfig.Rotation);
        }

        private Vector3 CalculateNextPosition(float smooth, Vector3 offset)
        {
            return Vector3.Lerp(_cameraTransform.position,
                _playerTransform.position + offset,
                smooth * Time.deltaTime);
        }
    }
}