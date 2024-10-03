using Model.StateMachine;
using Presenters.State;
using Views.StateMachine;

namespace Presenters.StateMachine
{
    public class GameStateMachinePresenter
    {
        private GameStateMachineModel _model;
        
        public GameStateMachinePresenter()
        {
            _model = new GameStateMachineModel();
            CreateStates();
            //EnterGameState<GameInitState>();
        }

        public void Enable()
        {
            foreach (var kvp in _model.GameStates)
            {
                kvp.Value.Finished += OnGameStateFinished;
            }
        }

        public void Disable()
        {
            foreach (var kvp in _model.GameStates)
            {
                kvp.Value.Finished -= OnGameStateFinished;
            }
        }

        private void CreateStates()
        {
            _model.AddGameState(new GameInitState());
            _model.AddGameState(new GamePlayState());
        }
        
        private void OnGameStateFinished(IGameState gameState)
        {
            EnterGameState<IGameState>(gameState);
        }
        
        private void EnterGameState<T>(IGameState gameState)
        {
           // _activeGameState?.Exit();
           // _activeGameState = _gameStates[index];
            //_activeGameState.Enter();
        }
    }
}