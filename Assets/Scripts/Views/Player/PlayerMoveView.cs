using System;
using Presenters.Player;
using ScriptableObjects;
using Services;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveView : MonoBehaviour
    {
        private PlayerMovePresenter _movePresenter;
        private InputService _inputService;
        
        [Inject]
        private void Initialize(InputService inputService, PlayerConfig playerConfig, ICoroutineService coroutineService)
        {
            _movePresenter = new PlayerMovePresenter(inputService, playerConfig,
                coroutineService, GetComponent<Rigidbody>());
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