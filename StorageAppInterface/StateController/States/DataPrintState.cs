using StorageAppInterface.UIHandlers;
using StorageAppInterface.StateController.States.Intefaces;
using StorageAppLogic.DataManagers;
using StorageAppLogic.StateController;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageAppInterface.StateController.States
{
    public class DataPrintState : IState
    {
        const string MenuName = "Вывод списка паллет";
        const string PrintPalleteListCommandString = "1";
        const string PrintGroupedListCommandString = "2";
        const string Print3TopPalletesCommandString = "3";
        const string ExitCommandString = "4";
        Dictionary<string, Command> _commands;
        UIStateManager _initializer;
        bool _isWorkContinue;
        public DataPrintState(UIStateManager initializer)
        {
            _initializer = initializer;
            BindCommands();
        }
        private void BindCommands()
        {
            //100% можно сделать всё производительнее и не копировать этот код в других состояниях, но 
            //я не знаю как это адекватно реализовать, прошу понять и простить
            _commands = new Dictionary<string, Command>
            {
                [PrintPalleteListCommandString] = new Command("Вывод списка всех паллет"),
                [PrintGroupedListCommandString] = new Command("Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу"),
                [Print3TopPalletesCommandString] = new Command("3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема"),
                [ExitCommandString] = new Command("Вернуться в меню")
            };
            _commands[PrintPalleteListCommandString].OnCommandTrigger += PrintPalletes;
            _commands[PrintGroupedListCommandString].OnCommandTrigger += PrintGroupedList;
            _commands[Print3TopPalletesCommandString].OnCommandTrigger += Print3TopPalletes;
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
        void PrintPalletes()
        {
            PalleteListPrinter.DrawPalleteList(StorageManager.Instance.Palletes);
            Console.ReadKey();
        }
        void PrintGroupedList()
        {
            var sortedPalletes = StorageManager.Instance.Palletes
                .GroupBy(p => p.ExpirationDate.Date)
                .SelectMany(p => p.OrderBy(p => p.Weight))
                .OrderBy(p=> p.ExpirationDate.Date)
                .ToList()
                .AsReadOnly();
            PalleteListPrinter.DrawPalleteList(sortedPalletes);
            Console.ReadKey();
        }
        void Print3TopPalletes()
        {
            var sortedPalletes = StorageManager.Instance.Palletes
                .OrderByDescending(p => p.ExpirationDate.Date)
                .Take(3)
                .OrderBy(p => p.Volume)
                .ToList()
                .AsReadOnly();
            PalleteListPrinter.DrawPalleteList(sortedPalletes);
            Console.ReadKey();
        }
        private void OnExitCommandCommandTrigger()
        {
            _isWorkContinue = false;
            _initializer.ChangeState<MainMenuState>();
        }
        #endregion
    }
}
