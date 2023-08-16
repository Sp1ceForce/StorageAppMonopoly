using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageController.StateController
{
    public class StorageStateManager
    {
        Dictionary<Type, IState> states;
        IState currentState;
        public StorageStateManager()
        {
            states = new Dictionary<Type, IState>
            {
                [typeof(ServerInitializingState)] = new ServerInitializingState(this),
                [typeof(ConnectionWaitingState)] = new ConnectionWaitingState(this),
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
