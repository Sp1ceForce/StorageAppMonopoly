using StorageAppInterface.DrawHandlers;
using StorageAppInterface.StateController.States.Intefaces;
using StorageAppLogic.DataManagers;
using StorageAppLogic.StateController;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageAppInterface.StateController.States
{

    public class MainMenuState : IState
    {
        const string MenuName = "Главное меню";
        const string PalleteEditCommandString = "1";
        const string PrintDataCommandString = "2";
        const string ExitCommandString = "3";
        Dictionary<string, Command> _commands;
        StorageAppUIStateManager _initializer;
        bool _isWorkContinue;
        public MainMenuState(StorageAppUIStateManager initializer)
        {
            this._initializer = initializer;
            //100% можно сделать всё производительнее и не копировать этот код в других состояниях, но 
            //я не знаю как это адекватно реализовать, прошу понять и простить
            _commands = new Dictionary<string, Command>
            {
                [PalleteEditCommandString] = new Command("Редактирование паллет"),
                [PrintDataCommandString] = new Command("Вывод списка всех паллет"),
                [ExitCommandString] = new Command ("Выход")
            };
            _commands[PalleteEditCommandString].OnCommandTrigger += OnPalleteEditCommandTrigger;
            _commands[PrintDataCommandString].OnCommandTrigger += OnPrintDataCommandCommandTrigger;
            _commands[ExitCommandString].OnCommandTrigger += OnExitCommandCommandTrigger;
        }
        void OnPalleteEditCommandTrigger()
        {
            _initializer.ChangeState<PalletesInteractionState>();
        }
        void OnPrintDataCommandCommandTrigger()
        {
            PalleteListPrinter.DrawPalleteList(StorageManager.Instance.Palletes);
        }
        void OnExitCommandCommandTrigger()
        {
            _isWorkContinue = false;
        }
        public void OnEnter()
        {
            _isWorkContinue = true;
            while (_isWorkContinue)
            {
                MenuDrawHandler.ExecuteOneMenuCycle(_commands, MenuName);
            }
        }
        public void OnExit()
        {
            Console.Clear();
        }
    }
}
