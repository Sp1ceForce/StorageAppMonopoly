using StorageAppLogic;
using StorageAppLogic.StateController;
using System;

namespace StorageAppInterface.StateController.States
{
    public class InitializingState : IState
    {
        StorageStateManager initializer;
        public InitializingState(StorageStateManager initializer) 
        {
            this.initializer = initializer;
        }

        public void OnEnter()
        {
            Console.WriteLine("Запуск...");
            StorageManager storageManager = new StorageManager();
            storageManager.LoadData();
            Console.WriteLine("Данные загружены, нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void OnExit()
        {
            Console.Clear();
        }
    }
}
