using System;
using Views.StateMachine;

namespace Presenters.State
{

    public class GameInitState : IGameState
    {
        public event Action<IGameState> Finished;

        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }

}