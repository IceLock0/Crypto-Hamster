using Presenters.StateMachine;
using UnityEngine;

namespace Views.StateMachine
{
    public class GameStateMachineView : MonoBehaviour
    {
        private GameStateMachinePresenter _presenter;
        
        private void Start()
        {
            _presenter = new GameStateMachinePresenter();
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }

        

        
    }
}