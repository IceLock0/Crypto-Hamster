using Presenters.Player;
using Presenters.Room;
using ScriptableObjects;
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
        public void Initialize(InputService inputService, PlayerConfig playerConfig, ContaminationPresenter contaminationPresenter)
        {
            _movePresenter = new PlayerMovePresenter(inputService, playerConfig, GetComponent<Rigidbody>(), contaminationPresenter);
            _inputService = inputService;
        }

        private void OnEnable()
        {
            _inputService.Enable();
            _movePresenter.Enable();
        }

        private void OnDisable()
        {
            _inputService.Disable();
            _movePresenter.Disable();
        }

        private void FixedUpdate()
        {
            _movePresenter.TryMove();
        }
    }
}