using System;
using System.Collections.Generic;
using System.Linq;
using Views.StateMachine;

namespace Model.StateMachine
{
    public class GameStateMachineModel
    {

        public GameStateMachineModel()
        {
            GameStates = new Dictionary<Type, IGameState>();
        }

        public Dictionary<Type, IGameState> GameStates { get; private set; }
        public IGameState ActiveGameState { get; private set; }

        public void AddGameState<T>(T gameState) where T : class, IGameState
        {
            CheckDictionary<T>();
            GameStates.Add(typeof(T), gameState);
        }

        public void SetActiveState<T>() where T : class, IGameState
        {
            CheckDictionary<T>();
            ActiveGameState = GameStates[typeof(T)];
        }

        private void CheckDictionary<T>() where T : class, IGameState
        {
            if (GameStates.Any(kvp => kvp.Key == typeof(T)))
                throw new ArgumentException();
        }
    }
}