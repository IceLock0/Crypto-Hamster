using Presenters.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerRotatorView : MonoBehaviour
    {
        [SerializeField] private GameObject _playerGameModel;
        
        private PlayerRotatorPresenter _presenter;

        [Inject]
        public void Initialize(InputService inputService, PlayerConfig playerConfig)
        {
            _presenter = new PlayerRotatorPresenter(inputService, playerConfig, _playerGameModel.transform);
        }

        private void FixedUpdate()
        {
            _presenter.TryRotate();
        }
    }
}