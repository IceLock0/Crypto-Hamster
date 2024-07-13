using System;

namespace Views.StateMachine
{

    public interface IGameState
    {
        public event Action<IGameState> Finished;

        public void Enter();
        public void Exit();
    }

}