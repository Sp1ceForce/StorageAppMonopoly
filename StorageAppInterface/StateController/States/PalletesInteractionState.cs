using StorageAppInterface.UIHandlers;
using StorageAppInterface.StateController.States.Intefaces;
using StorageAppLogic.StateController;
using System;
using System.Collections.Generic;
using StorageAppLogic.DataManagers;

namespace StorageAppInterface.StateController.States
{
    public class PalletesInteractionState : IState
    {
        const string MenuName = "Генерация и сохранение паллет";
        const string GeneratePalletesCommandString = "1";
        const string SavePalletesCommandString = "2";
        const string ExitCommandString = "3";

        Dictionary<string, Command> _commands;
        UIStateManager _initializer;
        bool _isWorkContinue = false;
        public PalletesInteractionState(UIStateManager initializer)
        {
            _initializer = initializer;
            _commands = new Dictionary<string, Command>
            {
                [GeneratePalletesCommandString] = new Command("Генерация случайных паллет"),
                [SavePalletesCommandString] = new Command("Сохранить все данные"),
                [ExitCommandString] = new Command("Назад")
            };
            _commands[GeneratePalletesCommandString].OnCommandTrigger += OnGeneratePalletesCommandTrigger;
            _commands[ExitCommandString].OnCommandTrigger += OnExitCommandCommandTrigger;
            _commands[SavePalletesCommandString].OnCommandTrigger += OnSavePalletesCommandTrigger;
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
        private void OnExitCommandCommandTrigger()
        {
            _isWorkContinue = false;
            _initializer.ChangeState<MainMenuState>();
        }
        void OnGeneratePalletesCommandTrigger()
        {
            bool continueLoop = true;
            while (continueLoop)
            {
                Console.WriteLine("Введите количество паллет для генерации:");
                string input = Console.ReadLine();
                bool isParsed = int.TryParse(input, out int totalPalletes);
                if (isParsed && totalPalletes > 0)
                {
                    StorageManager.Instance.AddRandomPalletes(totalPalletes);
                    continueLoop = false;
                } 
                else Console.WriteLine("Ошибка при вводе, попробуйте ещё раз");
            }

        }
        void OnSavePalletesCommandTrigger()
        {
            StorageManager.Instance.SaveData();
        }
        #endregion
    }
}
