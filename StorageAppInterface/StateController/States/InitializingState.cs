using StorageAppInterface.StateController.States.Intefaces;
using StorageAppLogic.DataManagers;
using StorageAppLogic.StateController;
using System;

namespace StorageAppInterface.StateController.States
{
    public class InitializingState : IState
    {
        UIStateManager _initializer;
        public InitializingState(UIStateManager initializer) 
        {
            this._initializer = initializer;
        }

        public void OnEnter()
        {
            Console.WriteLine("Запуск...");
            StorageManager storageManager = new StorageManager();
            storageManager.LoadData();
            Console.WriteLine("Данные загружены, нажмите любую клавишу для продолжения");
            Console.ReadKey();
            _initializer.ChangeState<MainMenuState>();
        }

        public void OnExit()
        {
            Console.Clear();
        }
    }
}
