using StorageAppInterface.DrawHandlers;
using StorageAppInterface.StateController.States.Intefaces;
using StorageAppLogic.StateController;
using System;
using System.Collections.Generic;

namespace StorageAppInterface.StateController.States
{
    public class PalletesInteractionState : IState
    {
        const string MenuName = "Редактирование и добавление паллет";
        const string PalleteAddCommandString = "1";
        const string PalleteEditCommandString = "2";
        const string ExitCommandString = "3";
        Dictionary<string, Command> _commands;
        StorageAppUIStateManager _initializer;
        bool _isWorkContinue = false;
        public PalletesInteractionState(StorageAppUIStateManager initializer)
        {
            _initializer = initializer;
            _commands = new Dictionary<string, Command>
            {
                [PalleteAddCommandString] = new Command("Добавление новой паллеты"),
                [PalleteEditCommandString] = new Command("Редактирование паллет"),
                [ExitCommandString] = new Command("Назад")
            };
            _commands[PalleteEditCommandString].OnCommandTrigger += OnPalleteEditCommandTrigger;
            _commands[PalleteAddCommandString].OnCommandTrigger += OnPalleteAddCommandTrigger;
            _commands[ExitCommandString].OnCommandTrigger += OnExitCommandCommandTrigger;
        }

        private void OnExitCommandCommandTrigger()
        {
            _isWorkContinue = false;
        }

        private void OnPalleteAddCommandTrigger()
        {
            throw new NotImplementedException();
        }

        private void OnPalleteEditCommandTrigger()
        {
            throw new NotImplementedException();
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
