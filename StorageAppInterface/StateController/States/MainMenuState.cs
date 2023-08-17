using StorageAppInterface.UIHandlers;
using StorageAppInterface.StateController.States.Intefaces;
using StorageAppLogic.DataManagers;
using StorageAppLogic.Models;
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
        UIStateManager _initializer;
        bool _isWorkContinue;
        public MainMenuState(UIStateManager initializer)
        {
            this._initializer = initializer;
            BindCommands();
        }

        private void BindCommands()
        {
            //100% можно сделать всё производительнее и не копировать этот код в других состояниях, но 
            //я не знаю как это адекватно реализовать, прошу понять и простить
            _commands = new Dictionary<string, Command>
            {
                [PalleteEditCommandString] = new Command("Работа с данными"),
                [PrintDataCommandString] = new Command("Вывод списка паллет"),
                [ExitCommandString] = new Command("Выход")
            };
            _commands[PalleteEditCommandString].OnCommandTrigger += OnPalleteEditCommandTrigger;
            _commands[PrintDataCommandString].OnCommandTrigger += OnPrintDataCommandCommandTrigger;
            _commands[ExitCommandString].OnCommandTrigger += OnExitCommandCommandTrigger;
        }

        public void OnEnter()
        {
            _isWorkContinue = true;
            while (_isWorkContinue)
            {
                MenuWorkHandler.ExecuteOneMenuCycle(_commands, MenuName);
            }
        }
        public void OnExit()
        {
            Console.Clear();
        }

        #region CommandHandlers

        void OnPalleteEditCommandTrigger()
        {
            _initializer.ChangeState<PalletesInteractionState>();
            _isWorkContinue = false;
        }
        void OnPrintDataCommandCommandTrigger()
        {
            _initializer.ChangeState<DataPrintState>();
            _isWorkContinue = false;
        }
        void OnExitCommandCommandTrigger()
        {
            _isWorkContinue = false;
        }
        #endregion
    }
}
