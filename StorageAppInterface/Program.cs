using StorageAppInterface.StateController.States;
using StorageAppLogic.DataManagers;
using StorageAppLogic.Models;
using StorageAppLogic.StateController;
using System.Collections.Generic;
using System;

namespace StorageAppInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StorageAppUIStateManager storageStateManager = new StorageAppUIStateManager();
            storageStateManager.ChangeState<InitializingState>();
        }
    }
}
