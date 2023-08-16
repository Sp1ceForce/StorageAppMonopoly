using StorageAppInterface.StateController.States;
using System;
using System.Collections.Generic;

namespace StorageAppLogic.StateController
{
    /// <summary>
    /// Контроллер машины-состояний, необходим для работы главного меню
    /// </summary>
    public class StorageStateManager
    {
        Dictionary<Type, IState> states;
        IState currentState;
        public StorageStateManager()
        {
            states = new Dictionary<Type, IState>
            {
                [typeof(InitializingState)] = new InitializingState(this),
            };
        }
        public void ChangeState<TState>() where TState : IState
        {
            if (states.TryGetValue(typeof(TState), out IState state))
            {
                currentState?.OnExit();
                currentState = state;
                currentState.OnEnter();
            }
        }
    }

}
