using StorageAppInterface.StateController.States;
using StorageAppLogic.StateController;

namespace StorageAppInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StorageStateManager storageStateManager = new StorageStateManager();
            storageStateManager.ChangeState<InitializingState>();
        }
    }
}
