using StorageAppInterface.StateController.States;
using StorageAppInterface.StateController.States.Intefaces;
using System;
using System.Collections.Generic;

namespace StorageAppLogic.StateController
{
    /// <summary>
    /// Контроллер машины-состояний, необходим для работы пользовательского интерфейса
    /// </summary>

    //Название такое себе если честно
    public class UIStateManager
    {
        Dictionary<Type, IState> states;
        IState currentState;
        public UIStateManager()
        {
            states = new Dictionary<Type, IState>
            {
                [typeof(InitializingState)] = new InitializingState(this),
                [typeof(MainMenuState)] = new MainMenuState(this),
                [typeof(PalletesInteractionState)] = new PalletesInteractionState(this),
                [typeof(DataPrintState)] = new DataPrintState(this),
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
            else throw new ArgumentException($"There is no corresponding state for {typeof(TState)}");
        }
    }

}
