using StorageController.StateController;

namespace StorageAppInterface.StateController.States
{
    internal class InitializingState
    {
        StorageStateManager initializer;
        public InitializingState(StorageStateManager initializer) 
        {
            this.initializer = initializer;
        }
    }
}
