using System;
using Views.StateMachine;

namespace Presenters.State
{

    public class GamePlayState : IGameState
    {
        public event EventHandler Finished;
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