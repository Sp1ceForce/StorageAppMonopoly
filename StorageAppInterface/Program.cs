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
            UIStateManager storageStateManager = new UIStateManager();
            storageStateManager.ChangeState<InitializingState>();
        }
    }
}
