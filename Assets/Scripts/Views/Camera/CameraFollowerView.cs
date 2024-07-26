using Presenters.Camera;
using ScriptableObjects;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Views.Camera
{
    [RequireComponent(typeof(Transform))]
    public class CameraFollowerView : MonoBehaviour
    {
        private CameraFollowerPresenter _presenter;

        [Inject]
        public void Initialize(PlayerMoveView player, CameraConfig cameraConfig)
        {
            _presenter = new CameraFollowerPresenter(player, transform, cameraConfig);
        }

        private void LateUpdate()
        {
            _presenter.FollowCamera();
        }
    }
}